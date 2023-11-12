using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursova_TaxiServiceWPF.Classes;

namespace Kursova_TaxiServiceWPF.Classes
{
    class TechnicalСlass
    {
        private Taxi[] arrTaxi;
        private int iIndex;
        public TechnicalСlass(int Size) {
            arrTaxi = new Taxi[Size];
            iIndex = 0;
        }

        public void AddTaxi(Taxi taxi) {
            arrTaxi[iIndex] = taxi;
            iIndex++;
        }

        public Taxi GetTaxi(int index)
        {
            return arrTaxi[index];
        }

        public int GetCount()
        {
            return iIndex;
        }
    }
}
