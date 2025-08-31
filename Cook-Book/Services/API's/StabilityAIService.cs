using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cook_Book.Services.API_s
{
    public class StabilityAIService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public event Action<string> ErrorOccurred;

        private void ImageGenerationError(string message, string? exMessage="")
        {
            ErrorOccurred?.Invoke(message);
            if (!string.IsNullOrEmpty(exMessage))
            {
                Logger.Log(exMessage, DateTime.Now);
            }
        }

        public StabilityAIService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public string ConvertBase64ToImageFile(string base64Data, string filePath)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64Data);
                System.IO.File.WriteAllBytes(filePath, imageBytes);
                return filePath;

            }catch (Exception ex)
            {
                ImageGenerationError(ex.Message, ex.StackTrace);
                return null;
            }
        }

        public async Task<string>? GenerateBodyTransformationImage(       
            int age,
            string gender,
            string goal,
            string scenario,
            string currentFitness = "average")
        {
            try
            {
                string prompt = BuildTransformationPrompt(age, gender, goal, scenario, currentFitness);
                string engineId = GetEngineIdForScenario(scenario);

                var requestBody = new
                {
                    text_prompts = new[]
                    {
                        new
                        {
                            text = prompt,
                            weight = 1.0,
                        },
                    },
                    cfg_scale = 7,
                    height = 1024,
                    width = 1024,
                    steps = 25,
                    samples = 1
                };

                var url = $"https://api.stability.ai/v1/generation/{engineId}/text-to-image";
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if(!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"API response Error: {response.StatusCode}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var parsedResponse = JObject.Parse(responseContent);

                var imageData = parsedResponse["artifacts"]?[0]?["base64"]?.ToString();

                if(string.IsNullOrEmpty(imageData))
                {
                    ImageGenerationError("Failed to get Image!");
                    return null;
                }

                return imageData;
            }
            catch (Exception ex)
            {
                ImageGenerationError("Error occurred while generating image.", $"Error occurred while generating image: {ex.Message}");
                return null;
            }
        }

        private string BuildTransformationPrompt(int age, string gender, string goal, string scenario, string currentFitness)
        {
            var prompt = scenario.ToLower() == "success" ?
                BuildSuccessPrompt(age, gender, goal, currentFitness) : BuildFailurePrompt(age, gender, goal, currentFitness);

            return prompt + " professional photography, studio lighting, full body shot, realistic skin texture, detailed clothing, high resolution, 8k";
        }

        private object BuildFailurePrompt(int age, string gender, string goal, string currentFitness)
        {
            return goal.ToLower() switch
            {
                "weight loss" =>
                    $"Unhealthy {age} year old {gender} who failed weight loss goals, " +
                    $"excess body fat, slumped posture, unhappy expression, " +
                    $"loose fitting clothes, low energy appearance, discouraged, " +
                    $"sedentary lifestyle consequences, poor fitness level",

                "muscle gain" =>
                    $"Weak {age} year old {gender} who failed muscle gain goals, " +
                    $"underdeveloped muscles for the specified gender, poor posture, lack of confidence, " +
                    $"thin physique, disappointed expression, missed potential, " +
                    $"inconsistent training results, unrealized fitness goals",

                _ => // Maintenance or default
                    $"Unhealthy {age} year old {gender} who failed fitness maintenance, " +
                    $"declining physique, poor posture, tired appearance, " +
                    $"weight gain, low energy, regretful expression, " +
                    $"lost fitness progress, sedentary lifestyle"
            };
        }

        private object BuildSuccessPrompt(int age, string gender, string goal, string currentFitness)
        {
            return goal.ToLower() switch
            {
                "weight loss" => 
                    $"Fit and healthy {age} year old {gender} after successful weight loss, " +
                    $"toned physique, visible muscle definition for the specified gender, flat stomach, confident posture, " +
                    $"happy expression, wearing fitness attire, athletic body, vibrant energy, " +
                    $"after achieving fitness goals, inspirational transformation",

                "muscle gain" =>
                    $"Muscular {age} year old {gender} after successful muscle gain. " +
                    $"defined muscles, broad shoulders, athletic build, strong physique, " +
                    $"confident stance, proud expression, fitness model appearance, " +
                    $"visible biceps and chest muscles, gym physique",

                _ => // Maintenance or default
                    $"Healthy and fit {age} year old {gender} maintaining excellent physique, " +
                    $"balanced body composition, good posture, energetic appearance, " +
                    $"happy and confident, overall wellness, sustainable fitness"
            };
        }

        private string GetEngineIdForScenario(string scenario)
        {
            // different engines for different scenarios
            return scenario.ToLower() == "success"
               ? "stable-diffusion-xl-1024-v1-0"
               : "stable-diffusion-xl-1024-v1-0";  // stable-diffusion-512-v2-1
        }
        
    }
}
