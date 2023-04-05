using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolidGame.SettingsClasses
{
    // Данный класс показывает принцип единой ответственности. В данном случае - за настройки игры.
    public class JsonGameSettings : GameSettingsAbstract
    {
        public override void UpdateSettings(int newTriesCount, int newRangeFrom, int newRangeTo)
        {
            string newConfStr = $@"{{
  ""GameSettings"": {{
    ""RangeFrom"": ""{newRangeFrom}"",
    ""RangeTo"": ""{newRangeTo}"",
    ""TriesCount"": ""{newTriesCount}""
  }}
}} ";

            File.WriteAllText(@$"{AppContext.BaseDirectory}\JsonAppSettings.json", newConfStr);
        }
    }
}
