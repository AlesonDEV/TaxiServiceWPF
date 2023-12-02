using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Kursova_TaxiServiceWPF.Classes
{
    class Taxi
    {
        #region variables
        //Number Of car + setter and getter
        private int IdOfCar;
        public int Id
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
        #endregion

        #region constructors

        //default constructor with zero values
        public Taxi() {
            Id = 0;
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
            Id = IdOfCar;
            Surname = strDriverSurname;
            PricePerKm = dPricePerKm;
            CarCost = dCarCost;
            CarModel = strCarModel;
            ArrivalTime = dArrivalTime;
            Distance = dDistance;
        }

        public Taxi(Taxi other) {
            Id = other.IdOfCar;
            Surname = other.Surname;
            PricePerKm = other.dPricePerKm;
            CarCost = other.CarCost;
            CarModel = other.CarModel;
            ArrivalTime = other.ArrivalTime;
            Distance = other.Distance;
        }
        #endregion

        #region functionality
        public System.Double GetPriceOfAllDistance() {
            return PricePerKm * Distance;
        }
        
        public void WriteInFile(string fileName) {
            using (StreamWriter writer = new StreamWriter(fileName, true)) {
                string content = "------------------\n" + 
                    "Id -" + Id + '\n' +
                    "Surname -" + Surname + '\n' +
                    "Price perkilometre -" + PricePerKm.ToString() + '\n' +
                    "Car cost -" + CarCost.ToString() + '\n' +
                    "Car model -" + CarModel + '\n' +
                    "Arrival time -" + ArrivalTime.ToString() + '\n' +
                    "Distance -" + Distance.ToString() + '\n' +
                    "Price for all journey -" + GetPriceOfAllDistance() + '\n';
                writer.Write(content);
            }
        }

        private void PutInfoInVariables(string[] linesFromFile) {
            Id = Convert.ToInt32((linesFromFile[1].Split('-'))[1].Trim());
            Surname = (linesFromFile[2].Split('-'))[1].Trim();
            PricePerKm = Convert.ToDouble((linesFromFile[3].Split('-'))[1].Trim());
            CarCost = Convert.ToDouble((linesFromFile[4].Split('-'))[1].Trim());
            CarModel = (linesFromFile[5].Split('-'))[1].Trim();
            ArrivalTime = DateTime.Parse((linesFromFile[6].Split('-'))[1]);
            Distance = Convert.ToDouble((linesFromFile[7].Split('-'))[1].Trim());
        }

        public bool ReadFromFile(string fileName , System.Int32 startLine, System.Int32 endLine) {
            using (StreamReader reader = new StreamReader(fileName)) {
                string[] linesFromFile = new string[endLine - startLine];
                System.Int32 currentLine = 0, indexForLines = 0;
                while (currentLine < endLine && !reader.EndOfStream) {
                    string content = reader.ReadLine();
                    if (currentLine >= startLine) {
                        linesFromFile[indexForLines] = content;
                        indexForLines++;
                    }
                    currentLine++;
                }
                PutInfoInVariables(linesFromFile);
                return reader.EndOfStream;
            }
        }
        #endregion
    }
}
