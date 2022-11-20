using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MacGuffin.Business.Providers
{
    public interface IConfigurationProvider
    {
        string GetAppSetting(string key);
    }

    public class ConfigurationProvider : IConfigurationProvider
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public ConnectionStringSettings GetConnectionString(string key)
        {
            return ConfigurationManager.ConnectionStrings[key];
        }
    }
}
