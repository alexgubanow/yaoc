using System;
using System.Windows;
using System.Windows.Data;

namespace ActionEngineModule.Views
{
    class TopicExpressionToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Xml.XmlNode[] a = (System.Xml.XmlNode[])value;
            string b = "";
            foreach (var item in a)
            {
                b += item.InnerText + '|';
            }
            b = b.Remove(b.Length - 1);
            return b;
        }
        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
