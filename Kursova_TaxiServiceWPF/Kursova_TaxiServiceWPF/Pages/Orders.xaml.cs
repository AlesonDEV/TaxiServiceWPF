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
        private ObservableCollection<Taxi> membersArray = new ObservableCollection<Taxi>(); //members of dataGrid
        private Taxi[] ddd;
        private int indx;
        public Orders()
        {
            InitializeComponent();
            Random rand = new Random();
            string[] Surname = { "Yaroshovych", "Bodnar", "Vashchuk", "Lukianov" };
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersArray.Add(new Taxi { ID = 1, DriverName = Surname[rand.Next(0, 4)], PricePerKm = 4343, ArrivalTime = DateTime.Now, CarCost = 3443, CarModel = "dfsdfs", Distance = 23 });
            membersOfDataGrid.ItemsSource = membersArray;
        }

        //button functionality and more
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
