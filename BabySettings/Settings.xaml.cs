using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Input;
using Microsoft.Phone.Controls;

namespace BabySettings
{
    public partial class Settings
    {
        private string _priceText;
        

        public Settings()
        {
            InitializeComponent();
            string var = Constantes.MyStruct.HourPrice.ToString();
            sliderEuros.Value = Constantes.MyStruct.HourPrice;
        }

        private void SavePrice_Click(object sender, RoutedEventArgs e)
        {
            _priceText = textBlockPrice.Text;
            
            //stock les parametre dans un fichier

            //Obtain the virtual store for application
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

            //Create a new folder and call it "RootFolder"
            myStore.CreateDirectory("settings");

            //Create a new file and assign a StreamWriter to the store and this new file (myFile.txt)
            //Also take the text contents from the textWrite control and write it to myFile.txt

            var writeFile =
                new StreamWriter(new IsolatedStorageFileStream("settings\\hourprice.txt",
                                                               FileMode.OpenOrCreate, myStore));
            writeFile.WriteLine(_priceText);

            writeFile.Close();

            Constantes.MyStruct.HourPrice = double.Parse(_priceText);
            
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}