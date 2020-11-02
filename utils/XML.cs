using System;
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
        public static XmlElement ToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }
        public static XmlElement ToXmlElement(object o, XmlSerializerNamespaces nsMap)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o, nsMap);
            }
            return doc.DocumentElement;
        }
        public static XmlElement ToXmlElement(object o, string ns)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType(), ns).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }

        public static XmlElement StringToXmlElement(string request)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(request);
            }
            catch (Exception)
            {
            }
            return doc.DocumentElement;
        }
    }
}
