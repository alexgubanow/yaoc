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
                    break;
                case "http://www.onvif.org/ver10/media/wsdl:GetSnapshotUri":
                    tmp = new trt.GetSnapshotUri();
                    break;
                case "tptz:OperatePresetTour":
                    tmp = new tptz.OperatePresetTour();
                    break;
                case "tptz:GotoPreset":
                    tmp = new tptz.GotoPreset();
                    break;
            }
            XmlElementToObject(xml, ref tmp);
            return tmp;
        }
        public static void XmlElementToObject(string xml, ref object Destinations)
        {
            if (xml.Length > 0 && Destinations != null)
            {
                using (var sr = new StringReader(xml))
                {
                    XmlSerializer xs = new XmlSerializer(Destinations.GetType());
                    try
                    {
                        Destinations = xs.Deserialize(sr);
                    }
                    catch (Exception)
                    {

                    }
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
