using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.SettingsClasses
{
    public interface IGameSettings
    {
        Dictionary<string, string> Settings { get; }
        public void ReadSettings();
        public void InitSettings();
        public bool CheckSettings();
        public bool IsNeedToChangeSettings();
        public void ChangeSettings();
        public void PrepairingToGame();
        public void UpdateSettings(Dictionary<string,string> newSettings);
    }
}
