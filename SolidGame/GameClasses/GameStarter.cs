using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidGame.SettingsClasses;

namespace SolidGame.GameClasses
{
    public class GameStarter
    {
        public string PlayerName;
        public IGame Game;
        public GameStarter(string GamerName, IGame game)
        {
            PlayerName = GamerName;
            Game = game;
        }

        public void OkLetsPlay()
        {
            Game.StartGame(PlayerName);
        }
    }
}
