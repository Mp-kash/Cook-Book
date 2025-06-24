using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
// using Microsoft.IdentityModel.Protocols;

namespace DataAccessLayer
{
    internal static class ConnectionHelper
    {
        internal static string ConnectionString
        {
            get
            {
                // Installed a Nuget package called System.Configuration.ConfigurationManager that allows reading from App/Web.config file automatically
                return ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
            }
        }
    }
}
