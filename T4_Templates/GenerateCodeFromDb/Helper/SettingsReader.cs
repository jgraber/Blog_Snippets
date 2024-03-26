using System;
using Microsoft.Extensions.Configuration;

namespace GenerateCodeFromDb.Helper
{
    public class SettingsReader
    {
        public static IConfiguration ReadSettings()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true);
            return (IConfiguration)builder.Build();
        }
    }
}
