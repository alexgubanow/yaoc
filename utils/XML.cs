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
        public static object XmlElementToObject(string xml, string type)
        {
            object tmp = null;
            switch (type)
            {
                case "trt:GetSnapshotUri":
                    tmp = new trt.GetSnapshotUri();
                    XmlElementToObject(xml, ref tmp);
                    break;
                case "tptz:OperatePresetTour":
                    tmp = new tptz.OperatePresetTour();
                    XmlElementToObject(xml, ref tmp);
                    break;
                case "tptz:GotoPreset":
                    tmp = new tptz.GotoPreset();
                    XmlElementToObject(xml, ref tmp);
                    break;
            }
            return tmp;
        }
        public static void XmlElementToObject(string xml, ref object Destinations)
        {
            if (xml.Length > 0)
            {
                using (var sr = new StringReader(xml))
                {
                    XmlSerializer xs = new XmlSerializer(Destinations.GetType());
                    Destinations = xs.Deserialize(sr);
                }
            }
        }
        public static XmlElement ToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            if (o != null)
            {
                using (XmlWriter writer = doc.CreateNavigator().AppendChild())
                {
                    try
                    {
                        new XmlSerializer(o.GetType()).Serialize(writer, o);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            return doc.DocumentElement;
        }
    }
}
