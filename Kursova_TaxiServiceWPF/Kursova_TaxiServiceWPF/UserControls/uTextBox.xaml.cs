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

        /* UserContol: for input form, contains:
         * Caption - text above inputTextBox (left);
         * Hint - text inside inputTextBox;
         * Warning - text above inputTextBox (right);
         * inputTextBox - main textBox for input some information;
         * Id - additional user's controller identifier.
         */

        //Initialize all components: inputTextBox and others...
        public uTextBox() {
            InitializeComponent();
        }

        public string Hint {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        //Register HintProperty as dependency for hint
        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(uTextBox));

        public string Caption {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }
        //Register CaptionProperty as dependency for caption
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(uTextBox));

        public string Warning {
            get { return (string)GetValue(WarningProperty); }
            set { SetValue(WarningProperty, value); }
        }
        //Register WarningProperty as dependency for warning
        public static readonly DependencyProperty WarningProperty =
            DependencyProperty.Register("Warning", typeof(string), typeof(uTextBox));

        public System.Int32 Id {
            get { return (System.Int32)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        //Register IdProperty as dependency for id
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(System.Int32), typeof(uTextBox));

        public System.Boolean IsCorrect {
            get { return (System.Boolean)GetValue(IsCorrectProperty); }
            set { SetValue(IsCorrectProperty, value); }
        }
        //Register IsCorrectProperty as dependency for IsCorrect
        public static readonly DependencyProperty IsCorrectProperty =
            DependencyProperty.Register("IsCorrect", typeof(System.Boolean), typeof(uTextBox));

        //Event handler for inputTextBox, that can be changed in palce, where user controller will be used
        public event TextChangedEventHandler inputTextBoxTextChanged {
            add { inputTextBox.TextChanged += value; }
            remove { inputTextBox.TextChanged -= value; }
        }
        private void inputTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            //Main logic in class Orders
        }
    }
}
