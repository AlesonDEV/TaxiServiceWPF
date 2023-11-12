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
namespace Kursova_TaxiServiceWPF.Pages
{
    public partial class Orders : Page
    {
        public Orders()
        {
            InitializeComponent();

            var convertor = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            members.Add(new Member { Number = "0", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new Member { Number = "1", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new Member { Number = "2", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new Member { Number = "3", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });
            members.Add(new Member { Number = "4", Surname = "Lukianov", PricePerKilometr = "20", PriceOfCar = "56464", ModelOfCar = "Renault", ArrivalTime = "43343", Distance = "12123", bgColor = (Brush)convertor.ConvertFromString("#1098ad") });

            membersOfDataGrid.ItemsSource = members;
        }
    }

    public class Member
    {
        public string Character { get; set; }
        public string Number { get; set; }
        public string Surname { get; set; }
        public string PricePerKilometr { get; set; }
        public string PriceOfCar { get; set; }
        public string ModelOfCar { get; set; }
        public string ArrivalTime { get; set; }
        public string Distance { get; set; }
        public Brush bgColor { get; set; }
    }
}
