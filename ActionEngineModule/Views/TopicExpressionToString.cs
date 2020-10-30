using System;
using System.Windows;
using System.Windows.Data;
using System.Xml;

namespace ActionEngineModule.Views
{
    public class TopicExpressionToString : IValueConverter
    {
        public static string ToString(XmlNode[] value)
        {
            XmlNode[] a = value;
            string b = "";
            foreach (var item in a)
            {
                b += item.InnerText + '|';
            }
            b = b.Remove(b.Length - 1);
            return b;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ToString((XmlNode[])value);
        }
        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
