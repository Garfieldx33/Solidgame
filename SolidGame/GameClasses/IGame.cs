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
        public void StartGame(IGameSettings gameSettings);
    }
}
