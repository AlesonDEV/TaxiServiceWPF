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

namespace Kursova_TaxiServiceWPF.UserControls {
    /// <summary>
    /// Interaction logic for uTextBox.xaml
    /// </summary>
    public partial class uTextBox : UserControl {
        public uTextBox() {
            InitializeComponent();
        }

        public string Hint {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(uTextBox));

        public string Caption {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(uTextBox));

        public string Warning {
            get { return (string)GetValue(WarningProperty); }
            set { SetValue(WarningProperty, value); }
        }

        public static readonly DependencyProperty WarningProperty =
            DependencyProperty.Register("Warning", typeof(string), typeof(uTextBox));

        public event TextChangedEventHandler TextBoxTextChanged {
            add { textBox.TextChanged += value; }
            remove { textBox.TextChanged -= value; }
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
}
