using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Shopping_Discount_Calculator.Resources;
using System.Windows.Threading;

namespace Shopping_Discount_Calculator
{
    public partial class StartScreen : PhoneApplicationPage
    {
        private bool _IsInitialized = false;

        public StartScreen()
        {
            InitializeComponent();
            _IsInitialized = true;
        }
        private void Canvas_Tap1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Women.xaml", UriKind.Relative));
        }
        private void Canvas_Tap2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void gridChildrens_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Child.xaml", UriKind.Relative));
        }

        private void gridShoes_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Shoes.xaml", UriKind.Relative));
        }

        private void gridMens_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Men.xaml", UriKind.Relative));
        }

    }
}