using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace SolidGame.SettingsClasses
{
    public class XmlGameSettings  : GameSettingsAbstract
    {
        public override void UpdateSettings(int newTriesCount, int newRangeFrom, int newRangeTo)
        {
            XmlGameSettings newSettings= new XmlGameSettings 
            {
                TriesCount= newTriesCount,
                RangeFrom= newRangeFrom,
                RangeTo = newRangeTo
            };

            using (var stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(XmlGameSettings));
                serializer.Serialize(stringwriter, newSettings);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(stringwriter.ToString());
                doc.Save(@$"{AppContext.BaseDirectory}\XmlAppSettings.xml");
            }
        }
    }
}
