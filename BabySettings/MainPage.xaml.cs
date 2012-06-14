using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;

namespace BabySettings
{
    public partial class MainPage
    {
        private IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;

        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
            if (Constantes.MyStruct.HourPrice == 0)
            {
                IsHourCostPresent();
            }
        }

        private void IsHourCostPresent()
        {
            try
            {
                //Obtain a virtual store for application
                IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

                //This code will open and read the contents of myFile.txt
                var readFile =
                    new StreamReader(new IsolatedStorageFileStream("settings\\hourprice.txt", FileMode.Open, myStore));
                string fileText = readFile.ReadLine();

                //The control textRead will display the text entered in the file
                IsolatedStorageSettings.ApplicationSettings["isFirstRun"] = fileText;
                readFile.Close();

                Constantes c = new Constantes();
                Constantes.MyStruct.HourPrice = int.Parse(fileText);

                string var = Constantes.MyStruct.HourPrice.ToString();
            }
            catch
            {
                MessageBox.Show("Tarif horaire non spécifié found - creating new one");
                PayePrice.IsEnabled = false;
                calcPrice.IsEnabled = false;
                purposeBabySitting.IsEnabled = false;
            }
        }


        private void PayePriceClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BabySittingCalculator.xaml", UriKind.Relative));
        }

        private void CalcPriceClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HourCost.xaml", UriKind.Relative));
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.Relative));
        }

        private void PurposeBabySittingClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BabySitting/Menu.xaml", UriKind.Relative));
        }
    }
}