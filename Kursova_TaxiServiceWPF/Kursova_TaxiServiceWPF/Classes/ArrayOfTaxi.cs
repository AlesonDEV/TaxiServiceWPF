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
        #region variables and constructors
        private Taxi[] taxisArray;
        private System.Int32 iArraySize, iArrayCapacity;

        public ArrayOfTaxi() {
            taxisArray = null;
            iArrayCapacity = 0;
            iArrayCapacity = 0;
        }
        #endregion

        #region auxiliary private functions
        private System.Boolean IsFull() {
            if (iArrayCapacity >= iArraySize)
                return true;
            return false;
        }

        // Creates a new array from Taxi and transfers elements from the old one there.
        // Wanted to make something like a custom vector.
        private void CreateNewArray() {
            iArraySize += (new Random()).Next(1, 10);
            Taxi[] taxisTempArray = taxisArray;
            taxisArray = new Taxi[iArraySize];
            for (System.Int32 i = 0; i < iArrayCapacity; i++)
                taxisArray[i] = taxisTempArray[i];
        }

        // Recursive Function for quick sorting.
        private void QuickSortRecursion(Taxi[] taxisArray, System.Int32 iLowIndex, System.Int32 iHighIndex) {
            if (iLowIndex < iHighIndex) {
                System.Int32 pivotIndex = Partition(taxisArray, iLowIndex, iHighIndex);
                QuickSortRecursion(taxisArray, iLowIndex, pivotIndex - 1);
                QuickSortRecursion(taxisArray, pivotIndex + 1, iHighIndex);
            }
        }
        private int Partition(Taxi[] taxisArray, System.Int32 iLowIndex, System.Int32 iHighIndex) {
            System.Double dPivot = taxisArray[iHighIndex].GetPriceOfAllDistance();
            System.Int32 i = iLowIndex - 1;
            for (System.Int32 j = iLowIndex; j < iHighIndex; j++)
                if (taxisArray[j].GetPriceOfAllDistance() <= dPivot) {
                    i++;
                    Swap(taxisArray, i, j);
                }
            Swap(taxisArray, i + 1, iHighIndex);
            return i + 1;
        }
        private void Swap(Taxi[] taxisArray, System.Int32 i, System.Int32 j) {
            Taxi tempValue = taxisArray[i];
            taxisArray[i] = taxisArray[j];
            taxisArray[j] = tempValue;
        }

        // Sorts a dictionary with grouped Taxi elements from the GroupByModel method.
        private void SortBySurnameInGroups(Dictionary<string, List<Taxi>> groupsDictionary) {
            foreach (var group in groupsDictionary) {
                System.Int32 sizeOfList = group.Value.Count;
                for (System.Int32 i = 0; i < sizeOfList; i++) {
                    System.Int32 gap = sizeOfList / 2;
                    while (gap > 0) {
                        for (System.Int32 k = gap; i < sizeOfList; i++) {
                            Taxi tempValue = group.Value[i];
                            System.Int32 indexJ = k;
                            while (indexJ >= gap && Convert.ToBoolean(string.Compare(group.Value[indexJ - gap].Surname, tempValue.Surname))) {
                                group.Value[indexJ] = group.Value[indexJ - gap];
                                indexJ -= gap;
                            }
                            group.Value[indexJ] = tempValue;
                        }
                        gap /= 2;
                    }
                }
            }
        }

        private Taxi GetTaxiWithMinimalPrice() {
            Taxi minimalValue = null;
            if (taxisArray != null) {
                minimalValue = taxisArray[0];
                if (iArrayCapacity > 1)
                    for (System.Int32 i = 1; i < iArrayCapacity; i++)
                        if (taxisArray[i].GetPriceOfAllDistance() < minimalValue.GetPriceOfAllDistance())
                            minimalValue = taxisArray[i];
            }
            return minimalValue;
        }
        #endregion

        #region main functional
        /// <summary>
        /// 1. Quick algorithm to sort records by Route Cost.
        /// </summary>
        /// <returns></returns>
        public void QuickSortByPrice() {
            QuickSortRecursion(taxisArray, 0, iArrayCapacity - 1);
        }

        /// <summary>
        /// 2. Determine the car number with the shortest arrival time.
        /// </summary>
        /// <returns></returns>
        public Taxi GetMinimalArrivalTime() {
            if (taxisArray != null) {
                Taxi valueToReturn = taxisArray[0];
                if (iArrayCapacity > 1) {
                    for (System.Int32 i = 1; i < iArrayCapacity; i++)
                        if (taxisArray[i].ArrivalTime < valueToReturn.ArrivalTime)
                            valueToReturn = taxisArray[i];
                }
                return valueToReturn;
            }
            return null;
        }

        /// <summary>
        /// 3. Display the driver's last name, car class and model, transportation cost for the selected car number
        /// </summary>
        /// <param name="IdOfTaxi"></param>
        /// <returns></returns>
        public Taxi PeekById(System.Int32 IdOfTaxi) {
            if (taxisArray != null)
                if (IdOfTaxi < iArrayCapacity && IdOfTaxi > -1)
                    return taxisArray[IdOfTaxi];
            return null;
        }

        /// <summary>
        /// 4. Determine the most expensive cars with the lowest fare.
        /// </summary>
        /// <returns></returns>
        public List<Taxi> GetMostExpensiveWithMinimalPriceOfTrip() {
            List<Taxi> mostExpensive = new List<Taxi>();
            if (taxisArray != null) {
                if (iArrayCapacity > 1) {
                    Taxi minimalPrice = GetTaxiWithMinimalPrice();
                    for (System.Int32 i = 0; i < iArrayCapacity; i++) {
                        if (taxisArray[i].GetPriceOfAllDistance() == minimalPrice.GetPriceOfAllDistance() && mostExpensive.Count > 0) {
                            if (taxisArray[i].CarCost > mostExpensive[0].CarCost) {
                                mostExpensive.Clear();
                                mostExpensive.Add(taxisArray[i]);
                            }
                            else if (taxisArray[i].CarCost == mostExpensive[0].CarCost)
                                mostExpensive.Add(taxisArray[i]);
                        }
                        else
                            mostExpensive.Add(taxisArray[i]);
                    }
                }
                mostExpensive.Add(taxisArray[0]);
            }
            return mostExpensive;
        }

        /// <summary>
        /// 4. Determine the most expensive cars with the shortest arrival time.
        /// </summary>
        /// <returns></returns>
        public List<Taxi> GetMostExpensiveWithMinimalArrivalTime() {
            List<Taxi> mostExpensive = new List<Taxi>();
            if (taxisArray != null) {
                if (iArrayCapacity > 1) {
                    Taxi minimalPrice = GetMinimalArrivalTime();
                    for (System.Int32 i = 0; i < iArrayCapacity; i++) {
                        if (taxisArray[i].ArrivalTime == minimalPrice.ArrivalTime && mostExpensive.Count > 0) {
                            if (taxisArray[i].CarCost > mostExpensive[0].CarCost) {
                                mostExpensive.Clear();
                                mostExpensive.Add(taxisArray[i]);
                            }
                            else if (taxisArray[i].CarCost == mostExpensive[0].CarCost)
                                mostExpensive.Add(taxisArray[i]);
                        }
                        else
                            mostExpensive.Add(taxisArray[i]);
                    }
                }
                mostExpensive.Add(taxisArray[0]);
            }
            return mostExpensive;
        }

        /// <summary>
        /// 5. Group records in which the fare and arrival time match.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Taxi>> GroupByPriceAndArivalTime() {
            Dictionary<string, List<Taxi>> groupsDictionary = new Dictionary<string, List<Taxi>>();
            if (taxisArray != null && iArrayCapacity > 1)
                for (System.Int32 i = 0; i < iArrayCapacity; i++) {
                    if (!groupsDictionary.ContainsKey((taxisArray[i].PricePerKm * taxisArray[i].Distance).ToString() + "_" + taxisArray[i].ArrivalTime.ToString()))
                        groupsDictionary[taxisArray[i].PricePerKm.ToString()] = new List<Taxi>();
                    groupsDictionary[(taxisArray[i].PricePerKm * taxisArray[i].Distance).ToString() + "_" + taxisArray[i].ArrivalTime.ToString()].Add(taxisArray[i]);
                }
            return groupsDictionary;
        }

        /// <summary>
        /// 6. Group cars by model and sort by driver's last name in each group.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Taxi>> GroupByModel() {
            Dictionary<string, List<Taxi>> groupsDictionary = new Dictionary<string, List<Taxi>>();
            if (taxisArray != null && iArrayCapacity > 1) {
                for (System.Int32 i = 0; i < iArrayCapacity; i++) {
                    if (!groupsDictionary.ContainsKey(taxisArray[i].CarModel.ToString()))
                        groupsDictionary[taxisArray[i].CarModel.ToString()] = new List<Taxi>();
                    groupsDictionary[taxisArray[i].CarModel.ToString()].Add(taxisArray[i]);
                }
                SortBySurnameInGroups(groupsDictionary);
            }
            return groupsDictionary;
        }

        // The functional is connected directly to the array
        public void AddTaxi(Taxi newTaxi) {
            if (IsFull())
                CreateNewArray();
            taxisArray[iArrayCapacity] = newTaxi;
            iArrayCapacity++;
        }
        public System.Boolean DeleteTaxi(string strSurnameOfDriver) {
            for (int i = 0; i < iArrayCapacity; i++)
                if (!Convert.ToBoolean(taxisArray[i].Surname.CompareTo(strSurnameOfDriver))) {
                    taxisArray[i] = null;
                    for (int j = i; j < iArrayCapacity - 1; j++)
                        taxisArray[j] = taxisArray[j + 1];
                    iArrayCapacity--;
                    return true;
                }
            return false;
        }
        public System.Int32 GetCount() {
            return iArrayCapacity;
        }
        #endregion
    }
}
