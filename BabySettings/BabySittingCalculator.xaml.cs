using System;
using System.Collections.Generic;
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
using System.IO.IsolatedStorage;


namespace BabySettings
{
    public partial class BabySittingCalculator
    {
        DateTime _endTime;
        DateTime _startTime;
        double HourPrice;
        
        
        public BabySittingCalculator()
        {
            InitializeComponent();
            StopButton.IsEnabled = false;
            HourPrice = Constantes.MyStruct.HourPrice;
            txtHourPrice.Text = HourPrice.ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _startTime = DateTime.Now;
            StartButton.IsEnabled = false;
            StopButton.IsEnabled = true;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            _endTime = DateTime.Now;

            TimeSpan ts = new TimeSpan();

            ts = _endTime.Subtract(_startTime);

            decimal decim = ts.Minutes/60m;
            decimal timeElapsed = ts.Hours + decim;

            var tempo = Math.Round(timeElapsed, 2);
            
            double doubleValue = (double) tempo;
            var result = doubleValue * HourPrice;

            Result.Text = result.ToString();
            txtHourNumber.Text = tempo.ToString();
            StopButton.IsEnabled = false;
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = true;
            StopButton.IsEnabled = true;
        }
        private void ChangeHourPrice(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FirstRun.xaml", UriKind.Relative));
        }
    }
}