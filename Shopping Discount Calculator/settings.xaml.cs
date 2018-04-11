using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.IO.IsolatedStorage;
using Shopping_Discount_Calculator.Resources;

namespace Shopping_Discount_Calculator
{
    public partial class settings : PhoneApplicationPage
    {
        private bool IsInitialized = false;

        Settings someSettings = new Settings();

        double dblAns;
        public settings()
        {
            InitializeComponent();
            IsInitialized = true;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RestoreSettings();
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SaveSettings();
        }
        private void SaveSettings()
        {
            //taxes slider and currency
            someSettings.TaxSetting = dblAns;
            someSettings.TaxRadPound = radPound.IsChecked.Value;
            someSettings.TaxRadDollar = radDollar.IsChecked.Value;
            someSettings.TaxRadEuro = radEuro.IsChecked.Value;
            //women
            someSettings.RadWCountryUK = radWomenUK.IsChecked.Value;
            someSettings.RadWCountryUS = radWomenUS.IsChecked.Value;
            someSettings.RadWCountryEU = radWomenEU.IsChecked.Value;
            someSettings.RadWCountryAU = radWomenAUS.IsChecked.Value;
            someSettings.RadWShoeUK = radWomenShoeUK.IsChecked.Value;
            someSettings.RadWShoeUS = radWomenShoeUS.IsChecked.Value;
            someSettings.RadWShoeEU = radWomenShoeEU.IsChecked.Value;
            someSettings.RadWShoeAU = radWomenShoeAUS.IsChecked.Value;
            //men
            someSettings.RadMCountryUS = radMenUKUSAUS.IsChecked.Value;
            someSettings.RadMCountryEU = radMenEU.IsChecked.Value;
            someSettings.RadMShoeUK = radMenShoeUK.IsChecked.Value;
            someSettings.RadMShoeUS = radMenShoeUS.IsChecked.Value;
            someSettings.RadMShoeEU = radMenShoeEU.IsChecked.Value;

            //child
            someSettings.RadCCountryUK = radChildUK.IsChecked.Value;
            someSettings.RadCCountryUS = radChildUS.IsChecked.Value;
            someSettings.RadCCountryEU = radChildEU.IsChecked.Value;
            someSettings.RadCCountryAU = radChildAUS.IsChecked.Value;
            someSettings.RadCShoeUK = radChildShoeUK.IsChecked.Value;
            someSettings.RadCShoeUS = radChildShoeUS.IsChecked.Value;
            someSettings.RadCShoeEU = radChildShoeEU.IsChecked.Value;
        }
        private void RestoreSettings()
        {
            dblAns = someSettings.TaxSetting;
            sldTax.Value = dblAns;
            txbTax.Text = string.Format(dblAns.ToString("n1") + "%");

            radPound.IsChecked = someSettings.TaxRadPound;
            radDollar.IsChecked = someSettings.TaxRadDollar;
            radEuro.IsChecked = someSettings.TaxRadEuro;

            radPound.Content = '\u00A3';
            radEuro.Content = '\u20AC';
            radDollar.Content = '\u0024';

            radWomenUK.IsChecked = someSettings.RadWCountryUK;
            radWomenUS.IsChecked = someSettings.RadWCountryUS;
            radWomenEU.IsChecked = someSettings.RadWCountryEU;
            radWomenAUS.IsChecked = someSettings.RadWCountryAU;
            radWomenShoeUK.IsChecked = someSettings.RadWShoeUK;
            radWomenShoeUS.IsChecked = someSettings.RadWShoeUS;
            radWomenShoeEU.IsChecked = someSettings.RadWShoeEU;
            radWomenShoeAUS.IsChecked = someSettings.RadWShoeAU;
 
            radMenUKUSAUS.IsChecked = someSettings.RadMCountryUS;
            radMenEU.IsChecked = someSettings.RadMCountryEU;
            radMenShoeUK.IsChecked = someSettings.RadMShoeUK;
            radMenShoeUS.IsChecked = someSettings.RadMShoeUS;
            radMenShoeEU.IsChecked = someSettings.RadMShoeEU;

            radChildUK.IsChecked = someSettings.RadCCountryUK;
            radChildUS.IsChecked = someSettings.RadCCountryUS;
            radChildEU.IsChecked = someSettings.RadCCountryEU;
            radChildAUS.IsChecked = someSettings.RadCCountryAU;
            radChildShoeUK.IsChecked = someSettings.RadCShoeUK;
            radChildShoeUS.IsChecked = someSettings.RadCShoeUS;
            radChildShoeEU.IsChecked = someSettings.RadCShoeEU;

        }
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            dblAns = (Math.Floor(sldTax.Value * 10)) / 10;
            txbTax.Text = string.Format(dblAns.ToString("n1") + "%");
        }

        private void WClear_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            radWomenUK.IsChecked = false;
            radWomenUS.IsChecked = false;
            radWomenEU.IsChecked = false;
            radWomenAUS.IsChecked = false;
            radWomenShoeUK.IsChecked = false;
            radWomenShoeUS.IsChecked = false;
            radWomenShoeEU.IsChecked = false;
            radWomenShoeAUS.IsChecked = false;

        }

        private void MClear_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            radMenUKUSAUS.IsChecked = false;
            radMenEU.IsChecked = false;
            radMenShoeUK.IsChecked = false;
            radMenShoeUS.IsChecked = false;
            radMenShoeEU.IsChecked = false;

        }

        private void CClear_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            radChildUK.IsChecked = false;
            radChildUS.IsChecked = false;
            radChildEU.IsChecked = false;
            radChildAUS.IsChecked = false;
            radChildShoeUK.IsChecked = false;
            radChildShoeUS.IsChecked = false;
            radChildShoeEU.IsChecked = false;

        }
    }
}