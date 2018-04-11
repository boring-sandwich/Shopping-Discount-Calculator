using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping_Discount_Calculator.Resources;
using System.Windows.Navigation;

namespace Shopping_Discount_Calculator
{
    class ShoppingNavigationFactory
    {
        NavigationService NavService;

        public ShoppingNavigationFactory(IApplicationBar appBar, NavigationService navService)
        {
            BuildLocalizedApplicationBar(appBar);
            NavService = navService;
        }

        public void BuildLocalizedApplicationBar(IApplicationBar appBar)
        {
            appBar.Opacity = 0;
            appBar.StateChanged += ApplicationBar_StateChanged;

            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(new Uri("/Assets/AppBar/home.png", UriKind.Relative));
            appBarButtonHome.Text = AppResources.AppBarButtonHome;
            appBar.Buttons.Add(appBarButtonHome);
            appBarButtonHome.Click += appBarButtonHome_Click;

            ApplicationBarMenuItem appBarMenuTaxes = new ApplicationBarMenuItem(AppResources.AppBarMenuTaxes);
            appBar.MenuItems.Add(appBarMenuTaxes);
            appBarMenuTaxes.Click += appBarMenuTaxes_Click;

            ApplicationBarMenuItem appBarMenuHowTo = new ApplicationBarMenuItem(AppResources.AppBarMenuHowTo);
            appBar.MenuItems.Add(appBarMenuHowTo);
            appBarMenuHowTo.Click += appBarMenuHowTo_Click;

            ApplicationBarMenuItem appBarMenuAbout = new ApplicationBarMenuItem(AppResources.AppBarMenuAbout);
            appBar.MenuItems.Add(appBarMenuAbout);
            appBarMenuAbout.Click += appBarMenuAbout_Click;
        }
        void ApplicationBar_StateChanged(object sender, ApplicationBarStateChangedEventArgs e)
        {
            ApplicationBar appBar = (ApplicationBar)sender;

            if (appBar.Opacity == 0)
                appBar.Opacity = 100;
            else
                appBar.Opacity = 0;
        }
        void appBarMenuAbout_Click(object sender, EventArgs e)
        {
            NavService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        void appBarMenuHowTo_Click(object sender, EventArgs e)
        {
            NavService.Navigate(new Uri("/HowToUse.xaml", UriKind.Relative));
        }

        void appBarMenuTaxes_Click(object sender, EventArgs e)
        {
            NavService.Navigate(new Uri("/Taxes.xaml", UriKind.Relative));
        }

        void appBarButtonHome_Click(object sender, EventArgs e)
        {
            NavService.Navigate(new Uri("/StartScreen.xaml", UriKind.Relative));
        }

        private void Canvas_Tap1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavService.Navigate(new Uri("/Women.xaml", UriKind.Relative));
        }
        private void Canvas_Tap2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
