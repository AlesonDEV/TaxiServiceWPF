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

namespace Kursova_TaxiServiceWPF.Pages
{
    
    public partial class Orders : Page
    {
        private ObservableCollection<Taxi> membersArray; //members of dataGrid
        private ArrayOfTaxi taxisArray; //class for actions on data grid inforamtion
        private System.Int32 iSelectedPage, iNumberOfPages;
        private System.Boolean IsLeft = false;
        public Orders()
        {
            
            InitializeComponent();
            membersArray = new ObservableCollection<Taxi>();
            taxisArray = new ArrayOfTaxi();
            iSelectedPage = 0;
            iNumberOfPages = 0;
            for (int i = 0; i < 20; i++) {
                taxisArray.AddTaxi(new Taxi { Id = i, Surname = "Lukianov" + i, ArrivalTime = DateTime.Now, CarCost = 323, CarModel = "dsfds" + i, Distance = 232, PricePerKm = 232, Details = new ObservableCollection<string>(), Is = false});
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
            DataGridPaginationUpdate();
        }

        private void DisplayChanges() {
            membersOfDataGrid.Items.Clear();
            for (int i = iSelectedPage * 12; i < (iSelectedPage * 12) + 12 && i < taxisArray.GetCount(); i++)
                membersOfDataGrid.Items.Add(taxisArray.PeekById(i));
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Int32 indexOfSelected = comboBox.SelectedIndex;
            switch (indexOfSelected)
            {
                case 0:
                    taxisArray.QuickSortByPrice();
                    break;
                case 1:
                    Dictionary<string, List<Taxi>> ar = taxisArray.GroupByModel();
                    break;
                default:
                    break;
            }
            
        }

    // Delete row
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            Button clickedButton = sender as Button;
            Taxi clickedDataItem = clickedButton?.DataContext as Taxi;
            if (clickedDataItem != null) {
                taxisArray.DeleteTaxi(clickedDataItem.Surname);
                DataGridPaginationUpdate();
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
            iNumberOfPages = taxisArray.GetCount() / 12;
            if (iNumberOfPages >= 2 && iSelectedPage == 0) {
                FirstButton.Content = iSelectedPage + 1;
                SecondButton.Content = (iSelectedPage + 2).ToString();
                ThirdButton.Content = "...";

                FirstButton.Style = (Style)FindResource("SelectedButton");
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
                    ThirdButton.Content = "...";
                }
                else if (iNumberOfPages == 1) {
                    FirstButton.Content = iSelectedPage;
                    SecondButton.Content = (iSelectedPage + 1).ToString();

                    SecondButton.Style = (Style)FindResource("SelectedButton");
                    FirstButton.Style = (Style)FindResource("pagingButton");
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
            
            DisplayChanges();
        }
        private void LeftArrow_Click(object sender, RoutedEventArgs e) {
            if (--iSelectedPage < 0) 
                iSelectedPage = 0;
            IsLeft = true;
            DataGridPaginationUpdate();
        }
        private void RightArrow_Click(object sender, RoutedEventArgs e) {
            if (++iSelectedPage >iNumberOfPages)
                iSelectedPage = iNumberOfPages;
            IsLeft = false;
            DataGridPaginationUpdate();
        }
        // end

        // Restore selection of row
        private void membersOfDataGrid_MouseDown(object sender, MouseButtonEventArgs e) {
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row != null && !(sender is Button))
                row.IsSelected = !row.IsSelected;
        }
    }
}
