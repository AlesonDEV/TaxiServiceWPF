using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Kursova_TaxiServiceWPF.Classes
{
    class MemberOfRowTemplate
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
