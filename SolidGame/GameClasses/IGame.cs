using SolidGame.SettingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.GameClasses
{
    public interface IGame
    {
        IGameSettings GameSettings { get; set; }
        public void StartGame(string GamerName);
    }
}
