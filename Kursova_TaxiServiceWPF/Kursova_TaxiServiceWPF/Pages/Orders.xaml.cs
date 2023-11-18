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
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using Kursova_TaxiServiceWPF.Classes;
using System.Text.RegularExpressions;

namespace Kursova_TaxiServiceWPF.Pages
{
    
    public partial class Orders : Page
    {
        private ObservableCollection<Taxi> membersArray; //members of dataGrid
        private ArrayOfTaxi taxisArray; //class for actions on data grid inforamtion
        public Orders()
        {
            InitializeComponent();
            membersArray = new ObservableCollection<Taxi>();
            taxisArray = new ArrayOfTaxi();
            for (int i = 0; i < 20; i++)
            {
                taxisArray.AddTaxi(new Taxi { Id = i, Surname = "Lukianov", ArrivalTime = DateTime.Now, CarCost = 323, CarModel = "dsfds" + i, Distance = 232, PricePerKm = 232 });
            }
            
            taxisArray.AddTaxi(new Taxi { Id = 1, Surname = "tk", ArrivalTime = DateTime.Now, CarCost = 323, CarModel = "dsfds", Distance = 1, PricePerKm = 1 });
            for (int i = 0; i < 20; i++)
            {
                taxisArray.PeekById(0).Details.Add($"Detail{i + 1} for New Person");
            }
            taxisArray.AddTaxi(new Taxi { Id = 3, Surname = "B", ArrivalTime = DateTime.Now, CarCost = 323, CarModel = "dsfds", Distance = 3, PricePerKm = 1 });
            for (int i = 0; i < taxisArray.GetCount(); i++)
            {
                membersOfDataGrid.Items.Add(taxisArray.PeekById(i));
            }

        }

        //button functionality and more
        private void DisplayChanges()
        {
            membersOfDataGrid.Items.Clear();
            for (int i = 0; i < taxisArray.GetCount(); i++)
            {
                membersOfDataGrid.Items.Add(taxisArray.PeekById(i));
                
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        { 
            membersOfDataGrid.Items.Clear();
            for (int i = 0; i < taxisArray.GetCount(); i++) {
                Taxi tempTaxi = taxisArray.PeekById(i);
                if (tempTaxi.Surname.Contains(txtSearch.Text))
                    membersOfDataGrid.Items.Add(tempTaxi); 
            }
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
            DisplayChanges();
        }

        private void DataGridRow_MouseDown(object sender, RoutedEventArgs e)
        {
            
        }

        

        private void membersOfDataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;

            if (row != null)
            {
                // Unselect the row to hide details
                row.IsSelected = !row.IsSelected;
            }
        }
    }
}
