using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Shopping_Discount_Calculator.Resources;

namespace Shopping_Discount_Calculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private Settings _Settings = new Settings();

        ApplicationBarIconButton appBarButtonHome;
        ApplicationBarIconButton appBarButtonTick;

        private bool _AppBar = false;

        char currency;
                
        public MainPage()
        {
            InitializeComponent();   
            _IsInitialized = true;
            ApplicationBar = new ApplicationBar();
            BuildLocalizedApplicationBar();
            BuildLocalizedApplicationBarShared();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _AppBar = false;
        }
        private void sldPrice_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SortOutPrice();
        }

        private void sldDiscounts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SortOutDiscount();
        }

        #region Methods
        private void SortOutPrice()
        {
            if (txtPayInput.Text == "")
            { return; }

            int intValue = (int)sldPrice.Value;

            double dblPriceInput;
            if (!double.TryParse(txtPayInput.Text, out dblPriceInput))
            {
                ErrorMessages(0);
                Clear();
                return;
            }

            //validation for the number going above or below a required parameter
            if (dblPriceInput < 0.00 || dblPriceInput > 10000.00)
            {
                ErrorMessages(1);
                Clear();
                return;
            }

            CheckCurrency();

            //shows the discount level
            txbPriceDiscount.Text = intValue.ToString("n0") + "%" + " off";

            //takes the percentage and shows what you pay with the discount
            double dblPrice = DiscountCalculations.DiscountPrice(dblPriceInput, intValue);
            txbYouPay.Text = string.Format("you pay: " + currency + dblPrice.ToString("n2"));
            //shows the price with tax
            txbPriceWithTax.Text = string.Format("price with tax: " + currency + DiscountCalculations.AddTax(dblPrice, _Settings.TaxSetting).ToString("n2"));
            //shows the total saving
            txbYouSave.Text = string.Format("you save: " + currency + DiscountCalculations.YouSave(dblPriceInput, intValue).ToString("n2"));
        }
        private void SortOutDiscount()
        {
            if (txtNewPriceInput.Text == "")
            { return; }

            int intValue = (int)sldDiscounts.Value;

            double dblNewPriceInput;
            if (!double.TryParse(txtNewPriceInput.Text, out dblNewPriceInput))
            {
                ErrorMessages(0);
                ClearDiscounts();
                return;
            }
            if (dblNewPriceInput < 0.00 || dblNewPriceInput > 10000.00)
            {
                ErrorMessages(1);
                ClearDiscounts();
                return;
            }
            CheckCurrency();

            //shows the discount level
            txbDiscounts.Text = intValue.ToString("n0") + "%" + " off";
            //shows the original price
            double dblOriginalPrice = DiscountCalculations.PaidToOriginal(dblNewPriceInput, intValue);
            txbOriginalPrice.Text = string.Format(currency + dblOriginalPrice.ToString("n2"));
            //takes the new price and adds on the tax
            txbYouPayDiscountsWithTax.Text = string.Format("new price with tax");
            txbYouPayDiscountsWithTaxNumbers.Text = string.Format(currency + DiscountCalculations.AddTax(dblNewPriceInput, _Settings.TaxSetting).ToString("n2"));
            //takes the original price and adds on the tax
            txbYouPayOriginalWithTax.Text = string.Format("original price with tax");
            txbYouPayOriginalWithTaxNumbers.Text = string.Format(currency + DiscountCalculations.AddTax(dblOriginalPrice, _Settings.TaxSetting).ToString("n2"));
        }
        private static void ErrorMessages(int errorCode)
        {
            switch (errorCode)
            {
                case 0:
                    MessageBox.Show("please type in a number with only two decimal places", "input error", MessageBoxButton.OK);
                    break;
                case 1:
                    MessageBox.Show("please type in a number greater than 0.01 and less than 10,000", "input error", MessageBoxButton.OK);
                    break;
            }
        }

        private void Clear()
        {
            txtPayInput.Text = "";
            txbPriceDiscount.Text = "";
            txbPriceWithTax.Text = "";
            txbYouPay.Text = "";
            txbYouSave.Text = "";
            txtPayInput.Focus();
        }
        private void ClearDiscounts()
        {
            txtNewPriceInput.Text = "";
            txbOriginalPrice.Text = "";
            txbYouPayDiscountsWithTax.Text = "";
            txbYouPayDiscountsWithTaxNumbers.Text = "";
            txbYouPayOriginalWithTax.Text = "";
            txbYouPayOriginalWithTaxNumbers.Text = "";
            txbDiscounts.Text = "";
            txtNewPriceInput.Focus();
        }
        private void CheckCurrency()
        {
            if (_Settings.TaxRadPound)
            {
                currency = '\u00A3';
            }
            else if (_Settings.TaxRadEuro)
            {
                currency = '\u20AC';
            }
            else
            {
                currency = '\u0024';
            }
        }
        #endregion

        #region Navigation

        private void BuildLocalizedApplicationBar()
        {
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonHome);
            ApplicationBar.Buttons.Remove(appBarButtonTick);

            if (_AppBar)
            {
                //create the tick
                appBarButtonTick = new ApplicationBarIconButton(new Uri("/Assets/AppBar/check.png", UriKind.Relative));
                appBarButtonTick.Text = "submit";
                ApplicationBar.Buttons.Add(appBarButtonTick);
                appBarButtonTick.Click += AppBarButtonTick_Click;

                _AppBar = false;
            }
            else
            {                
                //create home button
                appBarButtonHome = new ApplicationBarIconButton(new Uri("/Assets/AppBar/home.png", UriKind.Relative));
                appBarButtonHome.Text = "home";
                ApplicationBar.Buttons.Add(appBarButtonHome);
                appBarButtonHome.Click += AppBarButtonHome_Click;

                _AppBar = true;
            }

        }
        private void BuildLocalizedApplicationBarShared()
        {
            ApplicationBarMenuItem appBarSettingsMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuTaxes);
            ApplicationBar.MenuItems.Add(appBarSettingsMenuItem);
            appBarSettingsMenuItem.Click += appBarSettingsMenuItem_Click;

            ApplicationBarMenuItem appBarHowToMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuHowTo);
            ApplicationBar.MenuItems.Add(appBarHowToMenuItem);
            appBarHowToMenuItem.Click += appBarHowToMenuItem_Click;

            ApplicationBarMenuItem appBarAboutMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuAbout);
            ApplicationBar.MenuItems.Add(appBarAboutMenuItem);
            appBarAboutMenuItem.Click += appBarAboutMenuItem_Click;
        }

        private void AppBarButtonTick_Click(object sender, EventArgs e)
        {
            //check which pivot page you are on
            if (MyPivot.SelectedIndex == 0)
            {
                SortOutPrice();
            }
            else
            {
                SortOutDiscount();
            }
            BuildLocalizedApplicationBar();
            MyPivot.Focus();
        }

        private void AppBarButtonHome_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/StartScreen.xaml", UriKind.Relative));
        }
        void appBarAboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
        void appBarHowToMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HowToUse.xaml", UriKind.Relative));
        }
        void appBarSettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml", UriKind.Relative));
        }
        #endregion

        private void MyPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _AppBar = false;
            BuildLocalizedApplicationBar();
        }

        private void txtFocus_LostFocus(object sender, RoutedEventArgs e)
        {
            _AppBar = false;
            BuildLocalizedApplicationBar();
        }
        private void txtFocus_GotFocus(object sender, RoutedEventArgs e)
        {
            _AppBar = true;
            BuildLocalizedApplicationBar();
        }

    }
}