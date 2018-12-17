using System.Configuration;

namespace Cignium.SearchFight.Services.Models.Config
{
    public class BaseConfig
    {
        private const string MISSING_CONFIGURATION = "There was an isue with the configuration file. (Missing Value: {Key})";

        public static string GetFromConfiguration(string key)
        {
            string configurationValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(configurationValue))
                throw new ConfigurationErrorsException(MISSING_CONFIGURATION.Replace("{Key}", key));

            return configurationValue;
        }
    }
}
