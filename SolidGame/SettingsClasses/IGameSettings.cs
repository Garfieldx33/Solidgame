using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.SettingsClasses
{
    // Интерфейс я сделал для случая когда вместо Json файла конфигурации используется XML
    public interface IGameSettings
    {
        public int TriesCount { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }

        public bool CheckSettings();
        public bool IsNeedToChangeSettings();
        public void ChangeSettings();
        public void PrepairingToGame();
        public void UpdateSettings(int newTriesCount, int newRangeFrom, int newRangeTo);
    }
}
