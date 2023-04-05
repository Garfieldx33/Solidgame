using SolidGame.SettingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidGame.ConfigClasses
{
    public interface IConfigurator
    {
        public GameSettingsAbstract InitGameSettings();
    }
}
