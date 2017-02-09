using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CityInfo.API.Classes
{
    public static class ConfigurationSettingsReader
    {
        private static readonly Dictionary<string, string> LoadedSettings = new Dictionary<string, string>();
        private static readonly Dictionary<string, string> LoadedConnectionStrings = new Dictionary<string, string>();

        public static string GetSetting(string keyName)
        {
            if (!LoadedSettings.ContainsKey(keyName))
            {

                var value = Startup.Configuration[keyName];
                if (value == null)
                    throw new ArgumentException(string.Format(Startup.Configuration["errorMessages:noAppSettingKey"], keyName));

                LoadedSettings.Add(keyName, value);
            }
            return LoadedSettings[keyName];
        }

        public static string GetConnectionString(string keyName)
        {
            if (!LoadedConnectionStrings.ContainsKey(keyName))
            {
                var value = Startup.Configuration.GetConnectionString(keyName);
                if (value == null)
                    throw new ArgumentException(string.Format(Startup.Configuration["errorMessages:noConnectionStringKey"], keyName));

                LoadedConnectionStrings.Add(keyName, value);
            }
            return LoadedConnectionStrings[keyName];
        }
    }
}
