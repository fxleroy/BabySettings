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


namespace BabySettings.BabySitting
{
    public partial class Menu : PhoneApplicationPage
    {
        
        public Menu()
        {
            InitializeComponent();
        }

        private void DataForfaitClick(object sender, RoutedEventArgs e)
        {
            TextBox txtBoxName = new TextBox {Name = "txtBoxName", FontSize = 40, Margin = new Thickness(130, 310, 130, 240) };
            ContentGrid.Children.Add(txtBoxName);
            PasswordBox txtBoxPwd = new PasswordBox { Name = "txtBoxPwd", FontSize = 40, Margin = new Thickness(130, 400, 130, 150) };
            ContentGrid.Children.Add(txtBoxPwd);

            Button valider = new Button { Name = "btnValider", Content = "Ok", Margin = new Thickness(150, 480, 150, 80) };
            valider.Click += new RoutedEventHandler(VerifyUser);
            
            ContentGrid.Children.Add(valider);
        }
        private  void VerifyUser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BabySitting/Forfait.xaml", UriKind.Relative));
        }

        private void NoForfaitClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BabySitting/sms.xaml", UriKind.Relative));
        }
    }
}