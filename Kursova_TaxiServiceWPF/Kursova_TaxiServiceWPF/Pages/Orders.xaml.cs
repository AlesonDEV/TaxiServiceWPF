using Kursova_TaxiServiceWPF.Classes;
using Kursova_TaxiServiceWPF.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Kursova_TaxiServiceWPF.Pages {

    public partial class Orders : Page
    {
        private ArrayOfTaxi controllerOfTaxis;
        private ObservableCollection<Taxi> observableCollectionOfTaxis;
        private System.Int32 iSelectedPage, iNumberOfPages, iNumbersOfElements, iNumberOfVariables;
        private System.Boolean IsLeft, isDragging;
        private string[] strPatterns = new string[] {
            @"[@#$%^&*0-9?.,!:;}{<>/\'`~]",
            @"[a-zA-Z+=@#$%^&*!:;}{<>/\'`~]",
            @"[@#$%^&*?,!:;}{<>/\'`~]",
            @"[@#$%^&*?!,;}{<>/\'`~]"
        };
        private Point startPoint;

        // Contructor for page
        public Orders()
        {
            InitializeComponent();
            controllerOfTaxis = new ArrayOfTaxi();
            observableCollectionOfTaxis = new ObservableCollection<Taxi>();

            iSelectedPage = 0;
            iNumberOfVariables = 8;
            iNumbersOfElements = 0;
            iNumberOfPages = controllerOfTaxis.GetCount() / 12;
            NumberOfElements_ComboBox.SelectedIndex = 0;

            SurnamePopUp.inputTextBox.TextChanged += UserControl_TextBoxTextChanged; 
            PricePerKmPopUp.inputTextBox.TextChanged += UserControl_TextBoxTextChanged; 
            CarPricePopUp.inputTextBox.TextChanged += UserControl_TextBoxTextChanged;
            CarModelPopUp.inputTextBox.TextChanged += UserControl_TextBoxTextChanged;
            ArrivallTimePopUp.inputTextBox.TextChanged += UserControl_TextBoxTextChanged;
            DistancePopUp.inputTextBox.TextChanged += UserControl_TextBoxTextChanged;
            IdSearch.inputTextBox.TextChanged += UserControl_TextBoxTextChanged;

            SurnamePopUp.IsCorrect = false;
            PricePerKmPopUp.IsCorrect = false;
            CarPricePopUp.IsCorrect = false;
            CarModelPopUp.IsCorrect = false;
            ArrivallTimePopUp.IsCorrect = false;
            DistancePopUp.IsCorrect = false;
            IdSearch.IsCorrect = false;

            SurnamePopUp.Id = 0;
            PricePerKmPopUp.Id = 1;
            CarPricePopUp.Id = 1;
            CarModelPopUp.Id = 2;
            ArrivallTimePopUp.Id = 3;
            DistancePopUp.Id = 1;
            IdSearch.Id = 1;

            PutTaxisInCollection();
            DataGridPaginationUpdate();
            DisplayChanges();
        }


        
        // Sorting taxis form controller by quickSort and display in dataGrid
        private void QuickSortTaxisByPriceOfTrip() {
            try {
                if (controllerOfTaxis.QuickSortByPrice()) {
                    WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                   " | Succesfully sorting by price of trip");
                    PutTaxisInCollection();
                    DisplayChanges();
                    MessageBox.Show("Succesfully sorting by price of trip",
                    "Sorting taxis",
                     MessageBoxButton.OK,
                     MessageBoxImage.Information);
                    return;
                }
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                   " | Theare are not taxis for sorting");
                MessageBox.Show("Theare are not taxis for sorting!",
                 "Empty dataGrid",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
            }
            catch (Exception exception) {
                WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() +
                       " | Not succesfully sorting. Details - " +
                       exception.Message.ToString());
                MessageBox.Show("Something went wrong. Details - " + exception.Message.ToString(),
                        "Unexpected error",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
            }
        }



        // Identifying and adding the most expensive car with the lowest trip price
        private void DetectMostExpensiveWithMinimalPriceOfTrip() {
            List<Taxi> minimalPriceOfTrip = controllerOfTaxis.GetMostExpensiveWithMinimalPriceOfTrip();
            if (minimalPriceOfTrip.Count > 0) {
                observableCollectionOfTaxis.Clear();
                for (int i = 0; i < minimalPriceOfTrip.Count; i++)
                    observableCollectionOfTaxis.Add(minimalPriceOfTrip[i]);
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                    " | Succesfully detecting most expensive car with minimal price of trip. Detected - " +
                    minimalPriceOfTrip.Count);
                DataGridPaginationUpdate();
                DisplayChanges();
                return;
            }
            WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() + 
                " | Not succesfully detecting most expensive car with minimal price of trip. Details - there are not elements with such condition");
            MessageBox.Show("Theare are not cars with such conditions!",
                 "Empty dataGrid",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
        }



        // Identifying and adding the most expensive car with the shortest arrival time
        private void DetectMostExpensiveWithMinimalArrivalTime() {
            List<Taxi> minimalTimeOfTrip = controllerOfTaxis.GetMostExpensiveWithMinimalArrivalTime();
            if (minimalTimeOfTrip.Count > 0) {
                observableCollectionOfTaxis.Clear();
                for (int i = 0; i < minimalTimeOfTrip.Count; i++)
                    observableCollectionOfTaxis.Add(minimalTimeOfTrip[i]);
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() + 
                    " | Succesfully detecting most expensive car with minimal arrival time. Detected - " +
                    minimalTimeOfTrip.Count);
                DataGridPaginationUpdate();
                DisplayChanges();
                return;
            }
            WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() + 
                " | Not succesfully detecting most expensive car with minimal arrival time. Details - there are not elements with such condition");
            MessageBox.Show("Theare are not cars with such conditions!",
                 "Empty dataGrid",
                  MessageBoxButton.OK,
                  MessageBoxImage.Error);
        }



        // Determining the car with the shortest arrival time using the method from the ArrayOfTAxi class
        private void PrintTaxisWithMinimalArrivalTime() {
            List<Taxi> taxisWithMinimalArrivalTime = controllerOfTaxis.GetMinimalArrivalTime();
            if (taxisWithMinimalArrivalTime != null) {
                observableCollectionOfTaxis.Clear();
                for (int i = 0; i < taxisWithMinimalArrivalTime.Count; i++)
                    observableCollectionOfTaxis.Add(taxisWithMinimalArrivalTime[0]);
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() + 
                    " | Succesfully serached and showed car with minimal arrival time. Detected - " 
                    + taxisWithMinimalArrivalTime.Count);
                DataGridPaginationUpdate();
                DisplayChanges();
                return;
            }
            WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() + 
                " | Not succesfully detecting with minimal arrival time. Details - there are not elements with such condition");
            MessageBox.Show("There are not elements in dataGrid!",
              "Empty dataGrid",
               MessageBoxButton.OK,
               MessageBoxImage.Information);
        }



        // Opening the form for entering the vehicle ID and applying the blur effect
        private void PrintOrderWithId() {
            IdSearchPopUp.IsOpen = true;
            mainBorder.Effect = new BlurEffect { Radius = 5 };
        }

        // Output of information about the car with the corresponding number
        private void SumbitIdPopUp_Click(object sender, RoutedEventArgs e) {
            try {
                if (IdSearch.IsCorrect) {
                    Taxi searchedTaxi = controllerOfTaxis.PeekById(Convert.ToInt32(IdSearch.inputTextBox.Text));
                    if (searchedTaxi != null) {
                        WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                                " | Succesfully serached and showed car with such id");
                        MessageBox.Show("The information about car with id " + searchedTaxi.Id +
                            ":\nSurname - " + searchedTaxi.Surname +
                            "\nModel of car - " + searchedTaxi.CarModel +
                            "\nPrice of all journey - " + searchedTaxi.GetPriceOfAllDistance(),
                        "Finding car with ID",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
                        IdSearchPopUp.IsOpen = false;
                        mainBorder.Effect = new BlurEffect { Radius = 0 };
                        return;
                    }
                    WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() +
                        " | Not succesfully detecting car with such id. Details - there are not elements with such condition");
                    MessageBox.Show("The information about car with id " + Convert.ToInt32(IdSearch.inputTextBox.Text) +
                            ": does not exist with such id",
                        "Failed finding car with ID",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
                }
            }
            catch (Exception exception) {
                WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() +
                        " | Not succesfully detecting car with such id. Details - " + 
                        exception.Message.ToString());
                MessageBox.Show("Something went wrong. Details - " + exception.Message.ToString() ,
                        "Unexpected error",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
            }
            
        }

        // Closing the PopUp and turning off the blur effect
        private void BackIdSearchButton_Click(object sender, RoutedEventArgs e) {
            IdSearchPopUp.IsOpen = false;
            mainBorder.Effect = new BlurEffect { Radius = 0 };
        }



        // Group by Price and ArrivalTime, using method Of ArrayOfTaxi
        private void GroupByPriceAndArivalTime() {
            try {
                Dictionary<string, List<Taxi>> groupOfPriceAndArrivalTime = controllerOfTaxis.GroupByPriceAndArivalTime();
                if (groupOfPriceAndArrivalTime.Count != 0 ) {
                    observableCollectionOfTaxis.Clear();
                    foreach (var group in groupOfPriceAndArrivalTime)
                        for (int i = 0; i < group.Value.Count; i++)
                            observableCollectionOfTaxis.Add(group.Value[i]);
                    WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                        " | Succesfully group taxis by price and arrival time. Count of groups - " +
                        groupOfPriceAndArrivalTime.Count);
                    DisplayChanges();
                    MessageBox.Show("The taxis have been grouped succesfully!",
                        "Grouping car",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
                    return;
                }
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                       " | Not Succesfully group taxis by price and arrival time. Details - there are not taxis in datGrid");
                MessageBox.Show("The taxis have not been grouped! Details - there are not elements..",
                        "Grouping car",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
            }
            catch (Exception exception) {
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                       " | Not Succesfully group taxis by price and arrival time. Details - " 
                       + exception.Message.ToString());
                MessageBox.Show("Unexpected error! Details - " 
                        + exception.Message.ToString(),
                        "Grouping car",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
            }
        }



        // Group by models, using method Of ArrayOfTaxi
        private void GroupByModel() {
            try {
                Dictionary<string, List<Taxi>> groupOfModels = controllerOfTaxis.GroupByModel();
                if (groupOfModels.Count != 0) {
                    observableCollectionOfTaxis.Clear();
                    foreach (var group in groupOfModels)
                        for (int i = 0; i < group.Value.Count; i++)
                            observableCollectionOfTaxis.Add(group.Value[i]);
                    WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                            " | Succesfully group taxis by model. Count of groups - " +
                            groupOfModels.Count);
                    DisplayChanges();
                    MessageBox.Show("The taxis have been grouped succesfully!",
                        "Grouping car",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
                    return;
                }
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                      " | Not Succesfully group taxis by model. Details - there are not taxis in datGrid");
                MessageBox.Show("The taxis have not been grouped! Details - there are not elements..",
                        "Grouping car",
                         MessageBoxButton.OK,
                         MessageBoxImage.Information);
            }
            catch (Exception exception) {
                WriteInLog(Enums.Enums.Operations.FunctionOperation.ToString() +
                       " | Not Succesfully group taxis by model. Details - "
                       + exception.Message.ToString());
                MessageBox.Show("Unexpected error! Details - "
                        + exception.Message.ToString(),
                        "Grouping car",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
            }
        }



        // Checking if there are elements in datgrid
        private void checkingIfElementExist () {
            if (membersOfDataGrid.Items.Count != 0)
                EmpytNotification.Visibility = Visibility.Hidden;
            else
                EmpytNotification.Visibility = Visibility.Visible;
        }

        // Displaying changes in the dataGrid
        private void DisplayChanges() {
            membersOfDataGrid.Items.Clear();
            for (int i = iSelectedPage * iNumbersOfElements; i < (iSelectedPage * iNumbersOfElements) + iNumbersOfElements && i < observableCollectionOfTaxis.Count; i++)
                membersOfDataGrid.Items.Add(observableCollectionOfTaxis[i]);
            checkingIfElementExist();
        }

        // Transferring the elements of the main array to the ObservableCollection
        private void PutTaxisInCollection() {
            observableCollectionOfTaxis.Clear();
            for (int i = 0; i < controllerOfTaxis.GetCount(); i++)
                observableCollectionOfTaxis.Add(controllerOfTaxis.PeekByIndex(i));
        }

        // Back to normal state
        private void Back_Button_Click(object sender, RoutedEventArgs e) {
            // The elements in the datagrid are updated
            PutTaxisInCollection();
            DisplayChanges();
        }

        // Removing items from a collection and displaying it in a dataGrid
        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            Button clickedButton = sender as Button;
            Taxi clickedDataItem = clickedButton?.DataContext as Taxi;
            if (clickedDataItem != null) {
                controllerOfTaxis.DeleteTaxi(clickedDataItem.Surname);
                WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() +
                      " | Succesfully deleting element from dataFrid");
                PutTaxisInCollection();
                DataGridPaginationUpdate();                    
                DisplayChanges();
                return;
            }
            WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() +
                      " | Not Succesfully deleting element from dataFrid. Details - null element");
        }

        // Button that do actions from the task
        private void ActionButton_Click(object sender, RoutedEventArgs e) {
            // We take the selected action from the combo box and run it
            switch (actionComboBox.SelectedIndex) {
                case 0:
                    QuickSortTaxisByPriceOfTrip();
                    break;
                case 1:
                    PrintTaxisWithMinimalArrivalTime();
                    break;
                case 2:
                    PrintOrderWithId();
                    break;
                case 3:
                    DetectMostExpensiveWithMinimalArrivalTime();
                    break;
                case 4:
                    DetectMostExpensiveWithMinimalPriceOfTrip();
                    break;
                case 5:
                    GroupByPriceAndArivalTime();
                    break;
                case 6:
                    GroupByModel();
                    break;
                default:
                    break;
            }
        }

        // Restore selection of row
        private void membersOfDataGrid_MouseDown(object sender, MouseButtonEventArgs e) {
            DataGridRow row = ItemsControl.ContainerFromElement((DataGrid)sender, e.OriginalSource as DependencyObject) as DataGridRow;
            if (row != null && !(sender is Button))
                row.IsSelected = !row.IsSelected;
        }

        // Search by surname using TextBox
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e) {
            membersOfDataGrid.Items.Clear();
            for (int i = 0; i < observableCollectionOfTaxis.Count; i++) {
                Taxi tempTaxi = observableCollectionOfTaxis[i];
                // We check whether the corresponding last name contains already entered characters
                if (tempTaxi.Surname.Contains(txtSearch.Text))
                    membersOfDataGrid.Items.Add(tempTaxi);
            }
        }



        // PopUp movement logic
        private void inputPopup_MouseMove(object sender, MouseEventArgs e) {
            if (isDragging) {
                // Window displacement using offset and support displacement tracking functions
                Point currentPosition = e.GetPosition(this);
                double horizontalOffset = currentPosition.X - startPoint.X;
                double verticalOffset = currentPosition.Y - startPoint.Y;
                inputPopup.HorizontalOffset += horizontalOffset;
                inputPopup.VerticalOffset += verticalOffset;
                startPoint = currentPosition;
            }
        }

        // Detecting the hovering of the add element window
        private void inputPopup_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            isDragging = true;
            startPoint = e.GetPosition(this);
        }

        // Detecting the hovering of the add element window
        private void inputPopup_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            isDragging = false;
        }



        // Removing the blur and closing the form to add an element
        private void Back_ButtonInput_Click(object sender, RoutedEventArgs e) {
            inputPopup.IsOpen = false;
            mainBorder.Effect = new BlurEffect { Radius = 0 };
        }

        // Overlay of blur when clicking on the button to add elements
        private void AddingButton_Click(object sender, RoutedEventArgs e) {
            inputPopup.IsOpen = true;
            mainBorder.Effect = new BlurEffect { Radius = 5 };
        }



        // Logic for switching pages
        private void DataGridPaginationUpdate() {
            iNumberOfPages = controllerOfTaxis.GetCount() / iNumbersOfElements;

            //Calculation of the number of pages
            if (iNumberOfPages >= 2 && iSelectedPage == 0) {
                FirstButton.Content = iSelectedPage + 1;
                SecondButton.Content = (iSelectedPage + 2).ToString();
                ThirdButton.Content = "...";

                FirstButton.Style = (Style)FindResource("SelectedButton");
                SecondButton.Style = (Style)FindResource("pagingButton");
                ThirdButton.Style = (Style)FindResource("pagingButton");
                SetNormal(SecondButton);
                SetNormal(ThirdButton);
            }
            else if (iNumberOfPages == 1 && iSelectedPage == 0) {
                FirstButton.Content = (iSelectedPage + 1);
                SecondButton.Content = (iSelectedPage + 2).ToString();

                FirstButton.Style = (Style)FindResource("SelectedButton");
                SecondButton.Style = (Style)FindResource("pagingButton");
                SetMinimal(ThirdButton);
            }
            else if (iNumberOfPages == 0 && iSelectedPage == 0) {
                FirstButton.Content = iSelectedPage + 1;
                FirstButton.Style = (Style)FindResource("SelectedButton");

                SetMinimal(SecondButton);
                SetMinimal(ThirdButton);
            }

            // The logic of switching pages. Styles are used to display the current page
            if (iSelectedPage == iNumberOfPages && iNumberOfPages > 1) {
                FirstButton.Content = "...";
                SecondButton.Content = iSelectedPage;
                ThirdButton.Content = iSelectedPage + 1;

                FirstButton.Style = (Style)FindResource("pagingButton");
                SecondButton.Style = (Style)FindResource("pagingButton");
                ThirdButton.Style = (Style)FindResource("SelectedButton");
            }
            else if ((iNumberOfPages - iSelectedPage) == 1 && iNumberOfPages > 1) {
                ThirdButton.Content = iSelectedPage + 2;
                ThirdButton.Style = (Style)FindResource("pagingButton");
                FirstButton.Content = "...";
                FirstButton.Style = (Style)FindResource("pagingButton");
                SecondButton.Content = iSelectedPage + 1;
                SecondButton.Style = (Style)FindResource("SelectedButton");
            }
            else if (iSelectedPage >= 2 && iSelectedPage < iNumberOfPages - 1) {
                if (IsLeft) {
                    FirstButton.Content = "...";
                    SecondButton.Style = (Style)FindResource("SelectedButton");
                    FirstButton.Style = (Style)FindResource("pagingButton");
                    SecondButton.Content = iSelectedPage + 1;
                    ThirdButton.Content = iSelectedPage + 2;
                }
                else {
                    FirstButton.Content = iSelectedPage + 1;
                    SecondButton.Content = iSelectedPage + 2;
                    ThirdButton.Content = "...";
                }
            }
            else if (iSelectedPage == 1) {
                if (IsLeft) {
                    FirstButton.Content = iSelectedPage;
                    SecondButton.Content = (iSelectedPage + 1).ToString();
                    if (iNumberOfPages == 1)
                        SetMinimal(ThirdButton);
                    else
                        ThirdButton.Content = "...";
                }
                else if (iNumberOfPages == 1) {
                    FirstButton.Content = iSelectedPage;
                    SecondButton.Content = (iSelectedPage + 1).ToString();

                    SecondButton.Style = (Style)FindResource("SelectedButton");
                    FirstButton.Style = (Style)FindResource("pagingButton");
                    SetMinimal(ThirdButton);
                }
                else {
                    FirstButton.Content = (iSelectedPage + 1);
                    SecondButton.Content = (iSelectedPage + 2).ToString();
                    ThirdButton.Content = "...";

                    SecondButton.Style = (Style)FindResource("pagingButton");
                    FirstButton.Style = (Style)FindResource("SelectedButton");
                }
            }
            else if (iSelectedPage == 0) {
                FirstButton.Content = (iSelectedPage + 1);
                SecondButton.Content = (iSelectedPage + 2).ToString();
                ThirdButton.Content = "...";

                SecondButton.Style = (Style)FindResource("pagingButton");
                FirstButton.Style = (Style)FindResource("SelectedButton");
            }
        }

        // Change the numbers of element on each page
        private void NumberOfElements_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ComboBoxItem selectedObject = (ComboBoxItem)NumberOfElements_ComboBox.SelectedItem;
            iNumbersOfElements = Convert.ToInt32(selectedObject.Content);
            iSelectedPage = 0;
            DataGridPaginationUpdate();
            DisplayChanges();
        }

        // Toggles the page number for the DataGrid
        private void LeftArrow_Click(object sender, RoutedEventArgs e) {
            if (--iSelectedPage < 0)
                iSelectedPage = 0;
            IsLeft = true;
            DataGridPaginationUpdate();
            DisplayChanges();
        }

        // Toggles the page number for the DataGrid
        private void RightArrow_Click(object sender, RoutedEventArgs e) {
            if (++iSelectedPage > iNumberOfPages)
                iSelectedPage = iNumberOfPages;
            IsLeft = false;
            DataGridPaginationUpdate();
            DisplayChanges();
        }

        // Setting the minimum size for the page switch button
        private void SetMinimal(Button button) {
            button.Visibility = Visibility.Hidden;
            button.IsEnabled = false;
            button.Width = 0;
            button.Margin = new Thickness(0, 0, 0, 0);
        }

        // Return the button to its normal size
        private void SetNormal(Button button) {
            button.Visibility = Visibility.Visible;
            button.IsEnabled = true;
            button.Width = 17;
            button.Margin = new Thickness(2, 0, 2, 0);
        }



        // Adding elements to the array of objects with format checking for text boxes for entering information
        private void Sumbit_Click(object sender, RoutedEventArgs e) {
            // IsCorrect - userController field for checking the text in the corresponding text boxes,
            // that defined in the UserControl_TextBoxTextChanged method
            if (SurnamePopUp.IsCorrect &&
                PricePerKmPopUp.IsCorrect &&
                CarPricePopUp.IsCorrect &&
                CarModelPopUp.IsCorrect &&
                ArrivallTimePopUp.IsCorrect &&
                DistancePopUp.IsCorrect) {
                try {
                    controllerOfTaxis.AddTaxi(new Taxi {
                        Surname = SurnamePopUp.inputTextBox.Text,
                        PricePerKm = Convert.ToDouble(PricePerKmPopUp.inputTextBox.Text),
                        CarCost = Convert.ToDouble(CarPricePopUp.inputTextBox.Text),
                        CarModel = CarModelPopUp.inputTextBox.Text,
                        ArrivalTime = DateTime.ParseExact(ArrivallTimePopUp.inputTextBox.Text, "yyyy-MM-dd HH:mm:ss", null),
                        Distance = Convert.ToDouble(DistancePopUp.inputTextBox.Text)
                    });
                    WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() + " | Succesfully adding a new element to dataGrid");
                    // Updating the page numbers
                    PutTaxisInCollection();
                    DataGridPaginationUpdate();
                    DisplayChanges();
                    // Removing background blur
                    inputPopup.IsOpen = false;
                    mainBorder.Effect = new BlurEffect { Radius = 0 };
                    SurnamePopUp.inputTextBox.Text = "";
                    PricePerKmPopUp.inputTextBox.Text = "";
                    CarPricePopUp.inputTextBox.Text = "";
                    CarModelPopUp.inputTextBox.Text = "";
                    ArrivallTimePopUp.inputTextBox.Text = "";
                    DistancePopUp.inputTextBox.Text = "";
                }
                catch (Exception exception) {
                    WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() + " | Not succesfully adding a new element to dataGrid. Details - " + exception.Message.ToString());
                    MessageBox.Show("Oops, something went wrong! Details - " + exception.Message.ToString(),
                    "Error occured while adding a new order",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                }
            }
            else {
                WriteInLog(Enums.Enums.Operations.DataGridOperation.ToString() + " | Not succesfully adding a new element to dataGrid. Details - incorrect format of input information!");
                MessageBox.Show("Check the data you have entered in the fields and make sure that they are allowed!",
                    "Incorrect input in field/fields",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        // Finding the userController for the corresponding textbox
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;
            T parent = parentObject as T;
            return parent ?? FindParent<T>(parentObject);
        }

        // Check for correct input in the corresponding textBox
        private void UserControl_TextBoxTextChanged(object sender, TextChangedEventArgs e) {
            if (sender is TextBox newTextBox) {
                uTextBox userControl = FindParent<uTextBox>(newTextBox);
                // Regex is a method for checking the presence of appropriate characters in the text box
                if (userControl != null && Regex.IsMatch(newTextBox.Text, strPatterns[userControl.Id])) {
                    userControl.warningTextBox.Text = "*incorrect input";
                    userControl.IsCorrect = false;
                }
                else {
                    userControl.warningTextBox.Text = "";
                    userControl.IsCorrect = userControl.inputTextBox.Text.Length == 0 ? false : true;
                    if (userControl.Name == "ArrivallTimePopUp") {
                        if (DateTime.TryParse(userControl.inputTextBox.Text, out DateTime result)) {
                            if (result < DateTime.Now) {
                                userControl.warningTextBox.Text = "*incorrect input";
                                userControl.IsCorrect = false;
                                return;
                            }
                            userControl.warningTextBox.Text = "";
                            userControl.IsCorrect = true;
                            return;
                        }
                        userControl.warningTextBox.Text = "*incorrect input";
                        userControl.IsCorrect = false;
                    }
                }
            }
        }



        // Write logs to the file defined in App.xaml
        private void WriteInLog(string logContent) {
            try {
                // File reference for logging in App.xaml
                using (StreamWriter writer = new StreamWriter((string)Application.Current.Resources["LogFileName"]))
                    // logContent - message from the corresponding method
                    writer.WriteLine(DateTime.Now + " " + logContent);
            }
            catch (Exception exception) {
                MessageBox.Show("Oops, something went wrong with writing logs. Details - " + exception.Message.ToString(),
                    "Error occured while writing logs",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        // Writing elements to a file in the appropriate format specified in the Taxi class
        private void WriteButton_Click(object sender, RoutedEventArgs e) {
            try {
                for (System.Int32 i = 0; i < observableCollectionOfTaxis.Count; i++)
                    observableCollectionOfTaxis[i].WriteInFile(FileTextBox.Text);
                WriteInLog(Enums.Enums.Operations.FileOperation.ToString() + " | The information was succesful write in file " + FileTextBox.Text);
                MessageBox.Show("Information has succesfully written!",
                   "Succesful operation",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
            // A specific catch to catch errors related to writing to a file
            catch (IOException exception) {
                WriteInLog(Enums.Enums.Operations.FileOperation.ToString() + " | Something went wrong with writing in file  " + FileTextBox.Text);
                MessageBox.Show("Something went wrong with writing in file. Details - " + exception.Message.ToString(),
                   "Error while writing in file",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
            catch (Exception exception) {
                WriteInLog(Enums.Enums.Operations.FileOperation.ToString() + " | Unknown error. File " + FileTextBox.Text + ". Details - " + exception.Message.ToString());
                MessageBox.Show("Unknown error, check details. Details - " + exception.Message.ToString(),
                   "Unknown error",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }

        // Reading from a file and adding these elements to the data grid
        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            try {
                System.Int32 indexOfCurrentLine = 0;
                System.Boolean isEndOfFile = false;
                // numberOfVariables - the number of fields in the Taxi class
                while (!isEndOfFile) {
                    Taxi newTaxi = new Taxi();
                    // The starting and ending lines in the file to be read are passed to the function
                    isEndOfFile = newTaxi.ReadFromFile(FileTextBox.Text, indexOfCurrentLine * iNumberOfVariables, (indexOfCurrentLine + 1) * iNumberOfVariables);
                    controllerOfTaxis.AddTaxi(newTaxi);
                    indexOfCurrentLine++;
                }
                PutTaxisInCollection();
                DataGridPaginationUpdate();
                DisplayChanges();
                WriteInLog(Enums.Enums.Operations.FileOperation.ToString() + " | The information was succesful read from file " + FileTextBox.Text);
                MessageBox.Show("Information has succesfully read!",
                   "Succesful operation",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
            // A specific catch to catch errors related to reading from a file
            catch (IOException exception) {
                WriteInLog(Enums.Enums.Operations.FileOperation.ToString() + " | The information wasn't succesful read from file " + FileTextBox.Text + ". Details - " + exception.Message.ToString());
                MessageBox.Show("An error occurred while reading the file! Details - " + exception.Message.ToString(),
                   "File reading error",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
            catch (Exception exception) {
                WriteInLog(Enums.Enums.Operations.FileOperation.ToString() + " | An unexpected error occurred " + FileTextBox.Text + ". Details - " + exception.Message.ToString());
                MessageBox.Show("An unexpected error occurred. Details - " + exception.Message.ToString(),
                   "Unexpected error",
                   MessageBoxButton.OK,
                   MessageBoxImage.Error);
            }
        }
    }
}
