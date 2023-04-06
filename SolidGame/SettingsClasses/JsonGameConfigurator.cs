using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolidGame.SettingsClasses
{
    // Данный класс показывает принцип единой ответственности. В данном случае - за настройки игры.
    public class JsonGameConfigurator : GuessTheNumberGameConfiguratorAbstract
    {
        public override void UpdateSettings(Dictionary<string,string> settings)
        {
            string newConfStr = $@"{{
  ""GameSettings"": {{
    ""RangeFrom"": ""{settings["RangeFrom"]}"",
    ""RangeTo"": ""{settings["RangeTo"]}"",
    ""TriesCount"": ""{settings["TriesCount"]}""
  }}
}} ";

            File.WriteAllText(@$"{AppContext.BaseDirectory}\JsonAppSettings.json", newConfStr);
        }

        public override void ReadSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("JsonAppSettings.json", optional: true);
            IConfiguration config = builder.Build();
            _settings =  config.GetSection("GameSettings").Get<Dictionary<string, string>>();
        }
    }
}
