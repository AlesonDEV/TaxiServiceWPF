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
        // Static variable to count the number of class instances created
        private static System.Int32 totalTaxisCreated = 1;

        //Number Of car + setter and getter
        private System.Int32 IdOfCar;
        public System.Int32 Id {
            get { return IdOfCar; }
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
        private System.Double dPricePerKm;
        public System.Double PricePerKm
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
        private System.Double dCarCost;
        public System.Double CarCost
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
        private System.Double dDistance;
        public System.Double Distance
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
            IdOfCar = totalTaxisCreated;
            Surname = " ";
            PricePerKm = 0.0d;
            CarCost = 0.0d;
            CarModel = " ";
            ArrivalTime = DateTime.Now;
            Distance = 0.0d;
            totalTaxisCreated++;
        }

        // Constructor with parameters
        public Taxi(string strDriverSurname,
            System.Double dPricePerKm,
            System.Double dCarCost,
            string strCarModel,
            DateTime dArrivalTime,
            System.Double dDistance) {
            IdOfCar = totalTaxisCreated;
            Surname = strDriverSurname;
            PricePerKm = dPricePerKm;
            CarCost = dCarCost;
            CarModel = strCarModel;
            ArrivalTime = dArrivalTime;
            Distance = dDistance;
            totalTaxisCreated++;
        }

        // Copy constructor
        public Taxi(Taxi other) {
            IdOfCar = totalTaxisCreated;
            Surname = other.Surname;
            PricePerKm = other.dPricePerKm;
            CarCost = other.CarCost;
            CarModel = other.CarModel;
            ArrivalTime = other.ArrivalTime;
            Distance = other.Distance;
            totalTaxisCreated++;
        }
        #endregion

        #region methods
        // Calculates the full cost of the trip
        public System.Double GetPriceOfAllDistance() {
            return PricePerKm * Distance;
        }

        // Writing to a file using a StreamWriter at the end of the file
        public void WriteInFile(string fileName) {
            using (StreamWriter writer = new StreamWriter(fileName, true)) {
                string content = "------------------\n" + 
                    "Surname-" + Surname + '\n' +
                    "Price perkilometre-" + PricePerKm.ToString() + '\n' +
                    "Car cost-" + CarCost.ToString() + '\n' +
                    "Car model-" + CarModel + '\n' +
                    "Arrival time-" + ArrivalTime.ToString() + '\n' +
                    "Distance-" + Distance.ToString() + '\n' +
                    "Price for all journey-" + GetPriceOfAllDistance() + '\n';
                writer.Write(content);
            }
        }

        // Writing data from tapes from a file into class variables
        private void PutInfoInVariables(string[] linesFromFile) {
            Surname = (linesFromFile[1].Split('-'))[1].Trim();
            PricePerKm = Convert.ToDouble((linesFromFile[2].Split('-'))[1].Trim());
            CarCost = Convert.ToDouble((linesFromFile[3].Split('-'))[1].Trim());
            CarModel = (linesFromFile[4].Split('-'))[1].Trim();
            ArrivalTime = DateTime.Parse((linesFromFile[5].Split('-'))[1]);
            Distance = Convert.ToDouble((linesFromFile[6].Split('-'))[1].Trim());
        }

        // Reading tapes from a file starting with the corresponding one and ending with the corresponding one
        public bool ReadFromFile(string fileName , System.Int32 startLine, System.Int32 endLine) {
            using (StreamReader reader = new StreamReader(fileName)) {
                string[] linesFromFile = new string[endLine - startLine];
                System.Int32 currentLine = 0, indexForLines = 0;
                // Access to the relevant feed and further reading
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
