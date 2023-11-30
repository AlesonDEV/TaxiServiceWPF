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
using System.Collections.ObjectModel;
using Kursova_TaxiServiceWPF.Classes;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Windows.Media.Effects;
using Kursova_TaxiServiceWPF.UserControls;

namespace Kursova_TaxiServiceWPF.Pages
{
    
    public partial class Orders : Page
    {
        private ObservableCollection<Taxi> membersArray; //members of dataGrid
        private ArrayOfTaxi taxisArray; //class for actions on data grid inforamtion
        private System.Int32 iSelectedPage, iNumberOfPages, NumbersOfElements;
        private System.Boolean IsLeft = false;
        public Orders()
        {
            
            InitializeComponent();
            taxisArray = new ArrayOfTaxi();
            iSelectedPage = 0;
            SurnamePopUp.textBox.TextChanged += Surname_TextBoxTextChanged;
            PricePerKmPopUp.textBox.TextChanged += Price_Cost_TextBoxTextChanged;
            CarPricePopUp.textBox.TextChanged += Price_Cost_TextBoxTextChanged;
            NumbersOfElements = 0;

           
            for (int i = 0; i < 70; i++) {
                taxisArray.AddTaxi(new Taxi { Id = 1, Surname = "Lukianov" + i, ArrivalTime = DateTime.Now, CarCost = 323, CarModel = "dsfds" + (new Random()).Next(0, 3), Distance = 232, PricePerKm = (new Random()).Next(0, 10), Details = new ObservableCollection<string>(), Is = false });
                taxisArray.PeekById(i).Details.Add("fsdfs");
            }
            for (int i = 0; i < 20; i++) {
                taxisArray.PeekById(0).Details.Add($"Detail{i + 1} for New Person");
            }

            for (int i = 0; i < taxisArray.GetCount(); i++) {
                membersOfDataGrid.Items.Add(taxisArray.PeekById(i));
            }
            System.Int32 iCountOfRecords = taxisArray.GetCount();
            iNumberOfPages = iCountOfRecords / 12;
            NumberOfElements_ComboBox.SelectedIndex = 0;
            DataGridPaginationUpdate();
            DisplayChanges();
        }

        private void DisplayChanges() {
            membersOfDataGrid.Items.Clear();
            for (int i = iSelectedPage * NumbersOfElements; i < (iSelectedPage * NumbersOfElements) + NumbersOfElements && i < taxisArray.GetCount(); i++)
                membersOfDataGrid.Items.Add(taxisArray.PeekById(i));
        }
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            T parent = parentObject as T;
            return parent ?? FindParent<T>(parentObject);
        }

        private void Price_Cost_TextBoxTextChanged(object sender, TextChangedEventArgs e) {
            if (sender is TextBox newTextBox) {
                string pattern = @"[a-zA-Z+=]";
                uTextBox userControl = FindParent<uTextBox>(newTextBox);
                if (userControl != null && Regex.IsMatch(newTextBox.Text, pattern))
                    userControl.WarningText.Text = "*incorrect input";
                else
                    userControl.WarningText.Text = "";
            }
        }

        private void Surname_TextBoxTextChanged(object sender, TextChangedEventArgs e) {
            if (sender is TextBox newTextBox) {
                string pattern = @"[@#$%^&*0-9?.,!:;}{]";
                uTextBox userControl = FindParent<uTextBox>(newTextBox);
                if (userControl != null && Regex.IsMatch(newTextBox.Text, pattern))
                    userControl.WarningText.Text = "*incorrect input";
                else
                    userControl.WarningText.Text = "";
            }
        }
        // Button that do actions from the task
        private void ActionButton_Click(object sender, RoutedEventArgs e) {
            switch (comboBox.SelectedIndex) {
                case 0:
                    taxisArray.QuickSortByPrice();
                    DisplayChanges();
                    break;
                case 1:
                    membersOfDataGrid.Items.Clear();
                    membersOfDataGrid.Items.Add(taxisArray.GetMinimalArrivalTime());
                    break;
                case 5:
                    GroupByModel();
                    break;
                default:
                    break;
            }
            
        }

        // Group by models

        private void GroupByModel() {
            Dictionary<string, List<Taxi>> groupElements = taxisArray.GroupByModel();
            membersOfDataGrid.Items.Clear();
            foreach (var group in groupElements) {
                for (int i = 0; i < group.Value.Count; i++) {
                    membersOfDataGrid.Items.Add(group.Value[i]);
                }
            }
        }

    // Back to normal state
        private void Back_Button_Click(object sender, RoutedEventArgs e) {
            DataGridPaginationUpdate();
            DisplayChanges();
        }

    // Change the numbers of element on each page
        private void NumberOfElements_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBoxItem selectedObject = (ComboBoxItem)NumberOfElements_ComboBox.SelectedItem;
            NumbersOfElements = Convert.ToInt32(selectedObject.Content);
            iSelectedPage = 0;
            DataGridPaginationUpdate();
            DisplayChanges();
        }

    // Delete row
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            Button clickedButton = sender as Button;
            Taxi clickedDataItem = clickedButton?.DataContext as Taxi;
            if (clickedDataItem != null) {
                taxisArray.DeleteTaxi(clickedDataItem.Surname);
                DataGridPaginationUpdate();
                DisplayChanges();
            }
        }

    // Searching data among rows
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e) {
            membersOfDataGrid.Items.Clear();
            for (int i = 0; i < taxisArray.GetCount(); i++) {
                Taxi tempTaxi = taxisArray.PeekById(i);
                if (tempTaxi.Surname.Contains(txtSearch.Text))
                    membersOfDataGrid.Items.Add(tempTaxi);
            }
        }

        // The bottom menu of the transition between pages
        private void SetMinimal(Button button) {
            button.Visibility = Visibility.Hidden;
            button.IsEnabled = false;
            button.Width = 0;
            button.Margin = new Thickness(0, 0, 0, 0);
        }
        private void SetNormal(Button button) {
            button.Visibility = Visibility.Visible;
            button.IsEnabled = true;
            button.Width = 17;
            button.Margin = new Thickness(2, 0, 2, 0);
        }
        private void DataGridPaginationUpdate() {
            iNumberOfPages = taxisArray.GetCount() / NumbersOfElements;

            if (iNumberOfPages >= 2 && iSelectedPage == 0) {
                FirstButton.Content = iSelectedPage + 1;
                SecondButton.Content = (iSelectedPage + 2).ToString();
                ThirdButton.Content = "...";

                FirstButton.Style = (Style)FindResource("SelectedButton");
                SecondButton.Style = (Style)FindResource("pagingButton");
                ThirdButton.Style = (Style)FindResource("pagingButton");
                SetNormal(SecondButton);
                SetNormal(ThirdButton);
            }
            else if (iNumberOfPages == 1 && iSelectedPage == 0) {
                FirstButton.Content = (iSelectedPage + 1);
                SecondButton.Content = (iSelectedPage + 2).ToString();

                FirstButton.Style = (Style)FindResource("SelectedButton");
                SecondButton.Style = (Style)FindResource("pagingButton");
                SetMinimal(ThirdButton);
            }
            else if (iNumberOfPages == 0 && iSelectedPage == 0) {
                FirstButton.Content = iSelectedPage + 1;
                FirstButton.Style = (Style)FindResource("SelectedButton");

                SetMinimal(SecondButton);
                SetMinimal(ThirdButton);
            }

            if (iSelectedPage == iNumberOfPages && iNumberOfPages > 1) {
                FirstButton.Content = "...";
                SecondButton.Content = iSelectedPage;
                ThirdButton.Content = iSelectedPage + 1;

                FirstButton.Style = (Style)FindResource("pagingButton");
                SecondButton.Style = (Style)FindResource("pagingButton");
                ThirdButton.Style = (Style)FindResource("SelectedButton");
            }
            else if ((iNumberOfPages - iSelectedPage ) == 1 && iNumberOfPages > 1) {
                ThirdButton.Content = iSelectedPage + 2;
                ThirdButton.Style = (Style)FindResource("pagingButton");
                FirstButton.Content = "...";
                FirstButton.Style = (Style)FindResource("pagingButton");
                SecondButton.Content = iSelectedPage + 1;
                SecondButton.Style = (Style)FindResource("SelectedButton");
            }
            else if (iSelectedPage >= 2 && iSelectedPage < iNumberOfPages - 1) {
                if (IsLeft) {
                    FirstButton.Content = "...";
                    SecondButton.Style = (Style)FindResource("SelectedButton");
                    FirstButton.Style = (Style)FindResource("pagingButton");
                    SecondButton.Content = iSelectedPage + 1;
                    ThirdButton.Content = iSelectedPage + 2;
                }
                else {
                    FirstButton.Content = iSelectedPage + 1;
                    SecondButton.Content = iSelectedPage + 2;
                    ThirdButton.Content = "...";
                }
            }
            else if (iSelectedPage == 1) {
                if (IsLeft) {
                    FirstButton.Content = iSelectedPage;
                    SecondButton.Content = (iSelectedPage + 1).ToString();
                    if (iNumberOfPages == 1)
                        SetMinimal(ThirdButton);
                    else
                        ThirdButton.Content = "...";
                }
                else if (iNumberOfPages == 1) {
                    FirstButton.Content = iSelectedPage;
                    SecondButton.Content = (iSelectedPage + 1).ToString();

                    SecondButton.Style = (Style)FindResource("SelectedButton");
                    FirstButton.Style = (Style)FindResource("pagingButton");
                    SetMinimal(ThirdButton);
                }
                else {
                    FirstButton.Content = (iSelectedPage + 1);
                    SecondButton.Content = (iSelectedPage + 2).ToString();
                    ThirdButton.Content = "...";

                    SecondButton.Style = (Style)FindResource("pagingButton");
                    FirstButton.Style = (Style)FindResource("SelectedButton");
                }
            }
            else if (iSelectedPage == 0)  {
                FirstButton.Content = (iSelectedPage + 1);
                SecondButton.Content = (iSelectedPage + 2).ToString();
                ThirdButton.Content = "...";

                SecondButton.Style = (Style)FindResource("pagingButton");
                FirstButton.Style = (Style)FindResource("SelectedButton");
            }
        }
        private void LeftArrow_Click(object sender, RoutedEventArgs e) {
            if (--iSelectedPage < 0) 
                iSelectedPage = 0;
            IsLeft = true;
            DataGridPaginationUpdate();
            DisplayChanges();
        }

        private void AddingButton_Click(object sender, RoutedEventArgs e) {
            inputPopup.IsOpen = true;
            mainBorder.Effect = new BlurEffect { Radius = 5 };
        }

        private void Back_ButtonInput_Click(object sender, RoutedEventArgs e) {
            inputPopup.IsOpen = false;
            mainBorder.Effect = new BlurEffect { Radius = 0 };
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e) {
            if (++iSelectedPage >iNumberOfPages)
                iSelectedPage = iNumberOfPages;
            IsLeft = false;
            DataGridPaginationUpdate();
            DisplayChanges();
        }
        // end

    // 
        
    // Restore selection of row
        private void membersOfDataGrid_MouseDown(object sender, MouseButtonEventArgs e) {
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row != null && !(sender is Button))
                row.IsSelected = !row.IsSelected;
        }
    }
}
