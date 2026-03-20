// ConfigManager.cs

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Services
{
    public class ConfigManager
    {
        private readonly string _configFilePath;
        private Dictionary<string, string> _configurations;

        public ConfigManager(string configFilePath)
        {
            _configFilePath = configFilePath;
            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            if (File.Exists(_configFilePath))
            {
                var json = File.ReadAllText(_configFilePath);
                _configurations = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                _configurations = new Dictionary<string, string>();
            }
        }

        public string GetConfiguration(string key)
        {
            _configurations.TryGetValue(key, out var value);
            return value;
        }

        public void SetConfiguration(string key, string value)
        {
            _configurations[key] = value;
            SaveConfigurations();
        }

        private void SaveConfigurations()
        {
            var json = JsonConvert.SerializeObject(_configurations, Formatting.Indented);
            File.WriteAllText(_configFilePath, json);
        }
    }
}