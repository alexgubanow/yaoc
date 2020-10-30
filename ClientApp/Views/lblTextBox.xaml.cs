using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApp.Views
{
    /// <summary>
    /// Interaction logic for lblTextBox.xaml
    /// </summary>
    public partial class lblTextBox : UserControl
    {
        public lblTextBox()
        {
            InitializeComponent();
        }
        public string Header { get { return (string)GetValue(HeaderProperty); } set { SetValue(HeaderProperty, value); } }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header", typeof(string),
            typeof(lblTextBox), new UIPropertyMetadata(""));
        public int lblWidth { get { return (int)GetValue(lblWidthProperty); } set { SetValue(lblWidthProperty, value); } }

        public static readonly DependencyProperty lblWidthProperty = DependencyProperty.Register("lblWidth", typeof(int),
            typeof(lblTextBox), new UIPropertyMetadata(0));
        public string lblText { get { return (string)GetValue(lblTextProperty); } set { SetValue(lblTextProperty, value); } }

        public static readonly DependencyProperty lblTextProperty = DependencyProperty.Register("lblText", typeof(string),
            typeof(lblTextBox), new UIPropertyMetadata(""));
    }
}
