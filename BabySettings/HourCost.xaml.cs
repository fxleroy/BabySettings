using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace BabySettings
{
    public partial class HourCost
    {
        public HourCost()
        {
            InitializeComponent();

            textBoxPrice.InputScope = new System.Windows.Input.InputScope()
                                          {
                                              Names = {new InputScopeName() {NameValue = InputScopeNameValue.Number}}
                                          };
            textBoxHour.InputScope = new System.Windows.Input.InputScope()
                                         {
                                             Names = {new InputScopeName() {NameValue = InputScopeNameValue.Number}}
                                         };

        }

        private void CalcClick(object sender, RoutedEventArgs e)
        {
            var price = textBoxPrice.Text;
            int price1 = int.Parse(price);
            var hour = textBoxHour.Text;
            int hour1 = int.Parse(hour);

            int result = price1/hour1;
            TextBlockResult.Text = result.ToString();
        }

        private void NewHourCostClick(object sender, RoutedEventArgs e)
        {
            string priceText = TextBlockResult.Text;

            //Obtain the virtual store for application
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();

            //Create a new folder and call it "RootFolder"
            myStore.CreateDirectory("settings");

            //Create a new file and assign a StreamWriter to the store and this new file (myFile.txt)
            //Also take the text contents from the textWrite control and write it to myFile.txt

            var writeFile =
                new StreamWriter(new IsolatedStorageFileStream("settings\\hourprice.txt",
                                                               FileMode.OpenOrCreate, myStore));
            writeFile.WriteLine(priceText);

            writeFile.Close();

            Constantes.MyStruct.HourPrice = double.Parse(priceText);

            
        }
    }
}