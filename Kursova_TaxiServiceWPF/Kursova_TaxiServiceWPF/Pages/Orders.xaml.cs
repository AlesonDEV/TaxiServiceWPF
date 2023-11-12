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

namespace Kursova_TaxiServiceWPF.Pages
{
    public partial class Orders : Page
    {
        TechnicalСlass technicalСlass;
        ObservableCollection<MemberOfRowTemplate> members;
        public Orders()
        {
            InitializeComponent();

            var convertor = new BrushConverter();
            members = new ObservableCollection<MemberOfRowTemplate>();
            technicalСlass = new TechnicalСlass(20);


            members.Add(new MemberOfRowTemplate { Number = "0", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "1", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "2", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "3", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new MemberOfRowTemplate { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });

            membersOfDataGrid.ItemsSource = members;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Taxi taxi = new Taxi(1, "dfsdfds", 423, 434, "Dfssf", DateTime.Now, 423);
            //technicalСlass.AddTaxi(taxi);
            //members.Add(taxi);
        }
    }
}
