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
        public IGameSettings PlayerSettings;
        public IGame Game;
        public GameStarter(string GamerName, IGameSettings GamerSettings, IGame game)
        {
            PlayerName = GamerName;
            PlayerSettings = GamerSettings;
            Game = game;
        }

        public void OkLetsPlay()
        {
            Game.StartGame(PlayerSettings);
        }
    }
}
