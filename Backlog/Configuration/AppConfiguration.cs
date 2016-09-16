using System;
using System.Configuration;

namespace Backlog.Configuration
{
    public class AppConfiguration: ConfigurationSection, IAppConfiguration
    {
        [ConfigurationProperty("baseUri")]
        public string BaseUri
        {
            get { return (string)this["baseUri"]; }
            set { this["baseUri"] = value; }
        }

        public static IAppConfiguration Config
        {
            get { return ConfigurationManager.GetSection("appConfiguration") as IAppConfiguration; }
        }
       
    }
}
