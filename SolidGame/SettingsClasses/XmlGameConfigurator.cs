using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace SolidGame.SettingsClasses
{
    public class XmlGameConfigurator  : GuessTheNumberGameConfiguratorAbstract
    {
        
        public override void UpdateSettings(Dictionary<string,string> setings)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, string>)); // toDo реализовать

            using (TextWriter textWriter = new StreamWriter(@$"{AppContext.BaseDirectory}\XmlAppSettings.xml"))
            {
                serializer.Serialize(textWriter, _settings);

                textWriter.Close();
            }

            /*using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(XmlGameSettings));
                serializer.Serialize(stringwriter, setings);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(stringwriter.ToString());
                doc.Save(@$"{AppContext.BaseDirectory}\XmlAppSettings.xml");
            }*/
        }

        public override void ReadSettings()
        {
            
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            

            string filePath = $"{AppContext.BaseDirectory}\\XmlAppSettings.xml";
            if (File.Exists(filePath))
            {
                var xmlData = File.ReadAllText(filePath);
                XDocument doc = XDocument.Parse(xmlData);
                foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
                {
                    string keyName = element.Name.LocalName;

                    _settings.Add(element.Name.LocalName, element.Value);
                }

            }
            else
            {
                throw new Exception("Файл конфигурации XmlAppSettings.xml не найден.");
            }
        }
    }
}
