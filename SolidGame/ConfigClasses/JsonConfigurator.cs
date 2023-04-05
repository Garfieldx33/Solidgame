using Microsoft.Extensions.Configuration;
using SolidGame.SettingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.ConfigClasses
{
    public class JsonConfigurator : IConfigReader
    {
        public GameSettingsAbstract InitGameSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("JsonAppSettings.json", optional: true);
            IConfiguration config = builder.Build();
            return config.GetSection("GameSettings").Get<JsonGameSettings>();
        }
    }
}
