using Microsoft.Extensions.Configuration;
using SolidGame.SettingsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SolidGame.ConfigClasses
{
    public class XmlConfigurator : IConfigReader
    {
        public GameSettingsAbstract InitGameSettings()
        {
            XmlGameSettings result;
            string filePath = $"{AppContext.BaseDirectory}\\XmlAppSettings.xml";
            if (File.Exists(filePath))
            {
                var xmlData = File.ReadAllText(filePath);
                var serializer = new XmlSerializer(typeof(XmlGameSettings));

                using (var reader = new StringReader(xmlData))
                {
                    result = (XmlGameSettings)serializer.Deserialize(reader);
                }
            }
            else
            {
                throw new Exception("Файл конфигурации XmlAppSettings.xml не найден.");
            }
            return result;
        }
    }
}
