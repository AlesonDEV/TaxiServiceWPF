using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Kursova_TaxiServiceWPF.Classes
{
    class ArrayOfTaxi
    {
        private Taxi[] taxisArray;
        private System.Int32 iArraySize, iArrayCapacity;

        public ArrayOfTaxi() {
            taxisArray = null;
            iArrayCapacity = 0;
            iArrayCapacity = 0;
        }

        private System.Boolean IsFull() {
            if (iArrayCapacity >= iArraySize)
                return true;
            return false;
        }

        private void CreateNewArray() {
            Random cRandom = new Random();
            iArraySize += cRandom.Next(1, 10);
            Taxi[] taxisTempArray = taxisArray;
            taxisArray = new Taxi[iArraySize];
            for (int i = 0; i < iArrayCapacity; i++)
                taxisArray[i] = taxisTempArray[i];
        }

        public void AddTaxi(Taxi newTaxi) {
            if (IsFull()) 
                CreateNewArray();
            taxisArray[iArrayCapacity] = newTaxi;
            iArrayCapacity++;
        }

        public System.Boolean DeleteTaxi(string strSurnameOfDriver) {
            for (int i = 0; i < iArrayCapacity; i++)
                if (taxisArray[i].Surname == strSurnameOfDriver)
                {
                    taxisArray[i] = null;
                    for (int j = i; j < iArrayCapacity - 1; j++)
                        taxisArray[j] = taxisArray[j + 1];
                    return true;
                }
            return false;
        }

        public System.Int32 GetCount() {
            return iArrayCapacity;
        }

        public Taxi PeekByIndex(System.Int32 indexOfElement) {
            if (indexOfElement < iArrayCapacity && indexOfElement >= 0)
                return taxisArray[indexOfElement];
            return null;
        }

        public void QuickSortByPrice() {
            QuickSortRecursion(taxisArray, 0, iArrayCapacity - 1);
        }

        private void QuickSortRecursion(Taxi[] taxisArray, int iLowIndex, int iHighIndex) {
            if (iLowIndex < iHighIndex)
            {
                int pivotIndex = Partition(taxisArray, iLowIndex, iHighIndex);
                QuickSortRecursion(taxisArray, iLowIndex, pivotIndex - 1);
                QuickSortRecursion(taxisArray, pivotIndex + 1, iHighIndex);
            }
        }

        private int Partition(Taxi[] taxisArray, int iLowIndex, int iHighIndex) {
            System.Double dPivot = taxisArray[iHighIndex].GetPriceOfAllDistance();
            int i = iLowIndex - 1;
            for (int j = iLowIndex; j < iHighIndex; j++)
                if (taxisArray[j].GetPriceOfAllDistance() <= dPivot)
                {
                    i++;
                    Swap(taxisArray, i, j);
                }
            Swap(taxisArray, i + 1, iHighIndex);
            return i + 1;
        }

        private void Swap(Taxi[] taxisArray, int i, int j) {
            Taxi temp = taxisArray[i];
            taxisArray[i] = taxisArray[j];
            taxisArray[j] = temp;
        }
    }
}
