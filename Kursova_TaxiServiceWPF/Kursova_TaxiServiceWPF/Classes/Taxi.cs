using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Kursova_TaxiServiceWPF.Classes
{
    class Taxi
    {
        //Number Of car + setter and getter
        private int IdOfCar;
        public int ID
        {
            get { return IdOfCar; }
            set {
                if (value < 0) { 
                    IdOfCar = 0;
                    return;
                }
                IdOfCar = value;
            }
        }

        //Driver's SurName + setter and getter
        private string strDriverSurname;
        public string Surname
        {
            get { return strDriverSurname; }
            set {
                if (value == null) {
                    strDriverSurname = " ";
                    return;
                }
                strDriverSurname = value; 
            }
        }

        //Kilometr's price + setter and getter
        private double dPricePerKm;
        public double PricePerKm
        {
            get { return dPricePerKm; }
            set {
                if (value > 0) {
                    dPricePerKm = value;
                    return;
                }
                dPricePerKm = 0.01d;
            }
        }

        public string Details { get; set; }
        public string Is { get; set; }

        //Car's cost + setter and getter
        private double dCarCost;
        public double CarCost
        {
            get { return dCarCost; }
            set {
                if (value > 0)
                {
                    dCarCost = value;
                    return;
                }
                dCarCost = 0.01d;
            }
        }

        //Car's model + setter and getter
        private string strCarModel;
        public string CarModel
        {
            get { return strCarModel; }
            set {
                if (value == null)
                {
                    strCarModel = " ";
                    return;
                }
                strCarModel = value; 
            }
        }

        //Arrival Time + setter and getter
        private DateTime dtArrivalTime;
        public DateTime ArrivalTime
        {
            get { return dtArrivalTime; }
            set { dtArrivalTime = value; }
        }

        //Distance Time + setter and getter
        private double dDistance;
       
        public double Distance
        {
            get { return dDistance; }
            set {
                if (value > 0) {
                    dDistance = value;
                    return;
                }
                dDistance = 0.01d;
            }
        }
        

        //Constructors
        public Taxi() {
            ID = 0;
            Surname = " ";
            PricePerKm = 0.0d;
            CarCost = 0.0d;
            CarModel = " ";
            ArrivalTime = DateTime.Now;
            Distance = 0.0d;
        }

        public Taxi(int IdOfCar,
            string strDriverSurname,
            double dPricePerKm,
            double dCarCost,
            string strCarModel,
            DateTime dArrivalTime,
            double dDistance) {
            ID = IdOfCar;
            Surname = strDriverSurname;
            PricePerKm = dPricePerKm;
            CarCost = dCarCost;
            CarModel = strCarModel;
            ArrivalTime = dArrivalTime;
            Distance = dDistance;
        }

        public Taxi(Taxi other) {
            ID = other.IdOfCar;
            Surname = other.Surname;
            PricePerKm = other.dPricePerKm;
            CarCost = other.CarCost;
            CarModel = other.CarModel;
            ArrivalTime = other.ArrivalTime;
            Distance = other.Distance;
        }

        public System.Double GetPriceOfAllDistance() {
            return PricePerKm * Distance;
        }
    }
}
