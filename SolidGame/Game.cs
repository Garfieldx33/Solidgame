using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame
{
    public class Game
    {
        public string PlayerName;
        public IGameSettings PlayerSettings;

        public Game(string GamerName, IGameSettings GamerSettings) 
        {
            PlayerName = GamerName;
            PlayerSettings = GamerSettings;
        }

        public bool OkLetsGo()
        {

            return true;
        }
    }
}
