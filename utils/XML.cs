using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace utils
{
    public class XML
    {
        public static XmlNode[] ToXmlNodeArray(object o)
        {
            return new XmlNode[1] { ToXmlElement(o).LastChild };
        }
        public static void XmlElementToObject(string xml, ref object Destinations)
        {
            using (var sr = new StringReader(xml))
            {
                XmlSerializer xs = new XmlSerializer(Destinations.GetType());
                Destinations = xs.Deserialize(sr);
            }
        }
        public static XmlElement ToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }
    }
}
