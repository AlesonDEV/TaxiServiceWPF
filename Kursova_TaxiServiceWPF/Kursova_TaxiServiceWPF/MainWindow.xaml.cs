﻿using System;
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
using Kursova_TaxiServiceWPF.Pages;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Kursova_TaxiServiceWPF.Classes;


namespace Kursova_TaxiServiceWPF
{
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            frameContent.Navigate(new Orders());
        }

        // Closing this page
        private void btnClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        // Set minimazed state to this window
        private void btnMinimize_Click(object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }
    }
}
