using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cook_Book.Services.API_s
{
    public class GeminiService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public event Action<string>? GeminiError;

        public void errorLogger(string exMessage, string message)
        {
            Logger.Log(exMessage, DateTime.Now);
            GeminiError?.Invoke(message);
        }

        public GeminiService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<string> GetNutritionAdviceAsync(string prompt)
        {
            try
            {
                string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key={_apiKey}";

                var requestBody = new
                {
                    contents = new[]
                    {
                        new
                        {
                            parts = new[]
                            {
                                new { text = prompt }
                            }
                        }
                    },
                    generationConfig = new
                    {
                        temperature = 0.7,
                        maxOutputTokens = 500,
                        topP = 0.8
                    }
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    errorLogger($"Gemini API Error: {response.StatusCode} - " + errorContent, errorContent);
                    throw new HttpRequestException($"API Error: {response.StatusCode} - {errorContent}");
                }

                var result = await response.Content.ReadAsStringAsync();
                var parsed = JObject.Parse(result);

                return parsed["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString()
                       ?? "No response received from Gemini.";
            }
            catch (Exception ex)
            {
                string exMessage = "Error occurred while making request to Gemini. " + ex.Message;
                string message = "Error occurred while making request to Gemini.";
                errorLogger(exMessage, message);
                return message;
            }
        }
    }

}