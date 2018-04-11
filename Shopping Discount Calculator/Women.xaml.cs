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
using System.Windows.Input;

namespace Shopping_Discount_Calculator
{
    public partial class Women : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private bool _CmToInches = false;
        private int _IntValue;
        private bool _IsEditOn = false;

        private WomenSettings _Settings = new WomenSettings();
        private Settings _AllSettings = new Settings();

        //structures
        private struct WomensClothesSizes
        {
            public int UKSize;
            public int USSize;
            public int EUROSize;
            public int AUSSize;
            public string SizeName;
            public double BustInches;
            public double WaistInches;
            public double HipInches;
            public double BustCMS;
            public double WaistCMS;
            public double HipCMS;
        }
        public Women()
        {
            InitializeComponent();
            _IsInitialized = true;

            _IntValue = (int)sldWomen.Value;
            Clothing(women, _IntValue);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RestoreAll();
        }
        #region structure instances and info allocation
        private readonly WomensClothesSizes[] women = new WomensClothesSizes[]
            {        
        new WomensClothesSizes
            {
            //Women's information allocated
            UKSize = 6,
            USSize = 2,
            EUROSize = 34,
            AUSSize = 4,
            SizeName = "x-small",
            BustInches = 31.5,
            WaistInches = 25.5,
            HipInches = 34.5,
            BustCMS = 80,
            WaistCMS = 65,
            HipCMS = 87.5
    },
    new WomensClothesSizes
{
            UKSize = 8,
            USSize = 4,
            EUROSize = 36,
            AUSSize = 6,
            SizeName = "small",
            BustInches = 33,
            WaistInches = 26.5,
            HipInches = 36,
            BustCMS = 84,
            WaistCMS = 67.5,
            HipCMS = 91.5
},
    new WomensClothesSizes
{
            UKSize = 10,
            USSize = 6,
            EUROSize = 38,
            AUSSize = 8,
            SizeName = "small",
            BustInches = 34,
            WaistInches = 28,
            HipInches = 37.5,
            BustCMS = 86.5,
            WaistCMS = 71,
            HipCMS = 95
},
new WomensClothesSizes
{
            UKSize = 12,
            USSize = 8,
            EUROSize = 40,
            AUSSize = 10,
            SizeName = "medium",
            BustInches = 35.5,
            WaistInches = 29,
            HipInches = 39,
            BustCMS = 90,
            WaistCMS = 74,
            HipCMS = 99
},
new WomensClothesSizes
{
            UKSize = 14,
            USSize = 10,
            EUROSize = 42,
            AUSSize = 12,
            SizeName = "medium",
            BustInches = 37,
            WaistInches = 31,
            HipInches = 41.5,
            BustCMS = 94,
            WaistCMS = 79,
            HipCMS = 105.5
},
new WomensClothesSizes
{
            UKSize = 16,
            USSize = 12,
            EUROSize = 44,
            AUSSize = 14,
            SizeName = "large",
            BustInches = 39,
            WaistInches = 33,
            HipInches = 43.5,
            BustCMS = 99,
            WaistCMS = 84,
            HipCMS = 110.5
},
new WomensClothesSizes
{
            UKSize = 18,
            USSize = 14,
            EUROSize = 46,
            AUSSize = 16,
            SizeName = "large",
            BustInches = 41,
            WaistInches = 36,
            HipInches = 46,
            BustCMS = 104,
            WaistCMS = 91.5,
            HipCMS = 117
},
new WomensClothesSizes
{
            UKSize = 20,
            USSize = 16,
            EUROSize = 48,
            AUSSize = 18,
            SizeName = "x-large",
            BustInches = 43,
            WaistInches = 39,
            HipInches = 48.5,
            BustCMS = 109,
            WaistCMS = 99,
            HipCMS = 123
},
new WomensClothesSizes
{
            UKSize = 22,
            USSize = 18,
            EUROSize = 50,
            AUSSize = 20,
            SizeName = "1X",
            BustInches = 45,
            WaistInches = 40.5,
            HipInches = 50,
            BustCMS = 114,
            WaistCMS = 103,
            HipCMS = 127
},
new WomensClothesSizes
{
            UKSize = 24,
            USSize = 20,
            EUROSize = 52,
            AUSSize = 22,
            SizeName = "1X",
            BustInches = 48.5,
            WaistInches = 43,
            HipInches = 51.5,
            BustCMS = 123,
            WaistCMS = 109,
            HipCMS = 131
},
new WomensClothesSizes
{
            UKSize = 26,
            USSize = 22,
            EUROSize = 54,
            AUSSize = 24,
            SizeName = "2X",
            BustInches = 50.5,
            WaistInches = 45.75,
            HipInches = 54,
            BustCMS = 128,
            WaistCMS = 116,
            HipCMS = 137
},
new WomensClothesSizes
{
            UKSize = 28,
            USSize = 24,
            EUROSize = 56,
            AUSSize = 26,
            SizeName = "2X",
            BustInches = 52.5,
            WaistInches = 48.25,
            HipInches = 56.75,
            BustCMS = 133,
            WaistCMS = 123,
            HipCMS = 144
}
};
        #endregion
        private void sldWomen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _IntValue = (int)sldWomen.Value;
            Clothing(women, _IntValue);
        }
        private void Clothing(WomensClothesSizes[] women, int intValue)
        {
            txbWUKSize.Text = women[intValue].UKSize.ToString();
            txbWUSSize.Text = women[intValue].USSize.ToString();
            txbWEUROSize.Text = women[intValue].EUROSize.ToString();
            txbWAUSSize.Text = women[intValue].AUSSize.ToString();
            txbWName.Text = women[intValue].SizeName;
            if (!_CmToInches)
            {
                txbWBust.Text = women[intValue].BustInches.ToString() + "in";
                txbWWaist.Text = women[intValue].WaistInches.ToString() + "in";
                txbWHip.Text = women[intValue].HipInches.ToString() + "in";
            }
            else
            {
                txbWBust.Text = women[intValue].BustCMS.ToString() + "cm";
                txbWWaist.Text = women[intValue].WaistCMS.ToString() + "cm";
                txbWHip.Text = women[intValue].HipCMS.ToString() + "cm";
            }
        }
        private void btnWMeasurementChange_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (_CmToInches)
            {
                _CmToInches = false;
                btnWMeasurementChange.Content = "inches";
            }
            else
            {
                _CmToInches = true;
                btnWMeasurementChange.Content = "cm";
            }
            Clothing(women, _IntValue);
        }
        private void btnSave_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //check to see if there are any free spots
            int slot = IsThereASlotFree();
            if (slot == 0)
            {
                MessageBox.Show("all slots are full, please delete some data and try again", "warning", MessageBoxButton.OK);
                return;
            }
            switch (slot)
            {
                case 1:
                    NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=0", UriKind.Relative));
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=1", UriKind.Relative));
                    break;
                case 3:
                    NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=2", UriKind.Relative));
                    break;
                case 4:
                    NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=3", UriKind.Relative));
                    break;
                case 5:
                    NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=4", UriKind.Relative));
                    break;
            }
        }
        private int IsThereASlotFree()
        {
            if (!HasGroup01BeenSavedIn())
            {
                Save01();
                return 1;
            }
            if (!HasGroup02BeenSavedIn())
            {
                Save02();
                return 2;
            }
            if (!HasGroup03BeenSavedIn())
            {
                Save03();
                return 3;
            }
            if (!HasGroup04BeenSavedIn())
            {
                Save04();
                return 4;
            }
            if (!HasGroup05BeenSavedIn())
            {
                Save05();
                return 5;
            }
            return 0;
        }
        private bool HasGroup01BeenSavedIn()
        {
            if (_Settings.Name01 == "default name 01" && _Settings.Size01 == "default size 01"
                && _Settings.Bust01 == "00" && _Settings.Waist01 == "00" && _Settings.Hip01 == "00")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool HasGroup02BeenSavedIn()
        {
            if (_Settings.Name02 == "default name 02" && _Settings.Size02 == "default size 02"
                && _Settings.Bust02 == "00" && _Settings.Waist02 == "00" && _Settings.Hip02 == "00")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool HasGroup03BeenSavedIn()
        {
            if (_Settings.Name03 == "default name 03" && _Settings.Size03 == "default size 03"
                && _Settings.Bust03 == "00" && _Settings.Waist03 == "00" && _Settings.Hip03 == "00")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool HasGroup04BeenSavedIn()
        {
            if (_Settings.Name04 == "default name 04" && _Settings.Size04 == "default size 04"
                && _Settings.Bust04 == "00" && _Settings.Waist04 == "00" && _Settings.Hip04 == "00")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool HasGroup05BeenSavedIn()
        {
            if (_Settings.Name05 == "default name 05" && _Settings.Size05 == "default size 05"
                && _Settings.Bust05 == "00" && _Settings.Waist05 == "00" && _Settings.Hip05 == "00")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Save01()
        {
            _Settings.Name01 = women[_IntValue].SizeName.ToString() + "@ ";

            if (!_AllSettings.RadWCountryUK && !_AllSettings.RadWCountryUS &&
                !_AllSettings.RadWCountryEU && !_AllSettings.RadWCountryAU)
            {
                _Settings.Size01 = string.Format("UK: {0} US: {1}" + Environment.NewLine + "EU: {2} AUS: {3}",
                                    women[_IntValue].UKSize.ToString(), women[_IntValue].USSize.ToString(),
                                    women[_IntValue].EUROSize.ToString(), women[_IntValue].AUSSize.ToString());

                _Settings.Bust01 = (_CmToInches) ? women[_IntValue].BustCMS.ToString() + "cm" : women[_IntValue].BustInches.ToString() + "in";
                _Settings.Waist01 = (_CmToInches) ? women[_IntValue].WaistCMS.ToString() + "cm" : women[_IntValue].WaistInches.ToString() + "in";
                _Settings.Hip01 = (_CmToInches) ? women[_IntValue].HipCMS.ToString() + "cm" : women[_IntValue].HipInches.ToString() + "in";

            }
            else
            {
                if (_AllSettings.RadWCountryUK)
                {
                    _Settings.Size01 = string.Format("UK: " + women[_IntValue].UKSize.ToString());
                }
                else if (_AllSettings.RadWCountryUS)
                {
                    _Settings.Size01 = string.Format("US: " + women[_IntValue].USSize.ToString());
                }
                else if (_AllSettings.RadWCountryEU)
                {
                    _Settings.Size01 = string.Format("EURO: " + women[_IntValue].EUROSize.ToString());
                }
                else if (_AllSettings.RadWCountryAU)
                {
                    _Settings.Size01 = string.Format("AU: " + women[_IntValue].AUSSize.ToString());
                }
            }

            _Settings.Bust01 = (_CmToInches) ? women[_IntValue].BustCMS.ToString() + "cm" : women[_IntValue].BustInches.ToString() + "in";
            _Settings.Waist01 = (_CmToInches) ? women[_IntValue].WaistCMS.ToString() + "cm" : women[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip01 = (_CmToInches) ? women[_IntValue].HipCMS.ToString() + "cm" : women[_IntValue].HipInches.ToString() + "in";

        }
        private void Save02()
        {
            _Settings.Name02 = women[_IntValue].SizeName.ToString() + "@ ";

            if (!_AllSettings.RadWCountryUK && !_AllSettings.RadWCountryUS &&
                !_AllSettings.RadWCountryEU && !_AllSettings.RadWCountryAU)
            {
                _Settings.Size02 = string.Format("UK: {0} US: {1}" + Environment.NewLine + "EU: {2} AUS: {3}",
                                    women[_IntValue].UKSize.ToString(), women[_IntValue].USSize.ToString(),
                                    women[_IntValue].EUROSize.ToString(), women[_IntValue].AUSSize.ToString());
            }
            else
            {
                if (_AllSettings.RadWCountryUK)
                {
                    _Settings.Size02 = string.Format("UK: " + women[_IntValue].UKSize.ToString());
                }
                else if (_AllSettings.RadWCountryUS)
                {
                    _Settings.Size02 = string.Format("US: " + women[_IntValue].USSize.ToString());
                }
                else if (_AllSettings.RadWCountryEU)
                {
                    _Settings.Size02 = string.Format("EURO: " + women[_IntValue].EUROSize.ToString());
                }
                else if (_AllSettings.RadWCountryAU)
                {
                    _Settings.Size02 = string.Format("AU: " + women[_IntValue].AUSSize.ToString());
                }
            }

            _Settings.Bust02 = (_CmToInches) ? women[_IntValue].BustCMS.ToString() + "cm" : women[_IntValue].BustInches.ToString() + "in";
            _Settings.Waist02 = (_CmToInches) ? women[_IntValue].WaistCMS.ToString() + "cm" : women[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip02 = (_CmToInches) ? women[_IntValue].HipCMS.ToString() + "cm" : women[_IntValue].HipInches.ToString() + "in";

        }
        private void Save03()
        {
            _Settings.Name03 = women[_IntValue].SizeName.ToString() + "@ ";

            if (!_AllSettings.RadWCountryUK && !_AllSettings.RadWCountryUS &&
                !_AllSettings.RadWCountryEU && !_AllSettings.RadWCountryAU)
            {
                _Settings.Size03 = string.Format("UK: {0} US: {1}" + Environment.NewLine + "EU: {2} AUS: {3}",
                                    women[_IntValue].UKSize.ToString(), women[_IntValue].USSize.ToString(),
                                    women[_IntValue].EUROSize.ToString(), women[_IntValue].AUSSize.ToString());
            }
            else
            {
                if (_AllSettings.RadWCountryUK)
                {
                    _Settings.Size03 = string.Format("UK: " + women[_IntValue].UKSize.ToString());
                }
                else if (_AllSettings.RadWCountryUS)
                {
                    _Settings.Size03 = string.Format("US: " + women[_IntValue].USSize.ToString());
                }
                else if (_AllSettings.RadWCountryEU)
                {
                    _Settings.Size03 = string.Format("EURO: " + women[_IntValue].EUROSize.ToString());
                }
                else if (_AllSettings.RadWCountryAU)
                {
                    _Settings.Size03 = string.Format("AU: " + women[_IntValue].AUSSize.ToString());
                }
            }

            _Settings.Bust03 = (_CmToInches) ? women[_IntValue].BustCMS.ToString() + "cm" : women[_IntValue].BustInches.ToString() + "in";
            _Settings.Waist03 = (_CmToInches) ? women[_IntValue].WaistCMS.ToString() + "cm" : women[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip03 = (_CmToInches) ? women[_IntValue].HipCMS.ToString() + "cm" : women[_IntValue].HipInches.ToString() + "in";

        }
        private void Save04()
        {
            _Settings.Name04 = women[_IntValue].SizeName.ToString() + "@ ";

            if (!_AllSettings.RadWCountryUK && !_AllSettings.RadWCountryUS &&
                !_AllSettings.RadWCountryEU && !_AllSettings.RadWCountryAU)
            {
                _Settings.Size04 = string.Format("UK: {0} US: {1}" + Environment.NewLine + "EU: {2} AUS: {3}",
                                    women[_IntValue].UKSize.ToString(), women[_IntValue].USSize.ToString(),
                                    women[_IntValue].EUROSize.ToString(), women[_IntValue].AUSSize.ToString());
            }
            else
            {
                if (_AllSettings.RadWCountryUK)
                {
                    _Settings.Size04 = string.Format("UK: " + women[_IntValue].UKSize.ToString());
                }
                else if (_AllSettings.RadWCountryUS)
                {
                    _Settings.Size04 = string.Format("US: " + women[_IntValue].USSize.ToString());
                }
                else if (_AllSettings.RadWCountryEU)
                {
                    _Settings.Size04 = string.Format("EURO: " + women[_IntValue].EUROSize.ToString());
                }
                else if (_AllSettings.RadWCountryAU)
                {
                    _Settings.Size04 = string.Format("AU: " + women[_IntValue].AUSSize.ToString());
                }

                _Settings.Bust04 = (_CmToInches) ? women[_IntValue].BustCMS.ToString() + "cm" : women[_IntValue].BustInches.ToString() + "in";
                _Settings.Waist04 = (_CmToInches) ? women[_IntValue].WaistCMS.ToString() + "cm" : women[_IntValue].WaistInches.ToString() + "in";
                _Settings.Hip04 = (_CmToInches) ? women[_IntValue].HipCMS.ToString() + "cm" : women[_IntValue].HipInches.ToString() + "in";
            }
        }
        private void Save05()
        {
            _Settings.Name05 = women[_IntValue].SizeName.ToString() + "@ ";

            if (!_AllSettings.RadWCountryUK && !_AllSettings.RadWCountryUS &&
                !_AllSettings.RadWCountryEU && !_AllSettings.RadWCountryAU)
            {
                _Settings.Size05 = string.Format("UK: {0} US: {1}" + Environment.NewLine + "EU: {2} AUS: {3}",
                                    women[_IntValue].UKSize.ToString(), women[_IntValue].USSize.ToString(),
                                    women[_IntValue].EUROSize.ToString(), women[_IntValue].AUSSize.ToString());
            }
            else
            {
                if (_AllSettings.RadWCountryUK)
                {
                    _Settings.Size05 = string.Format("UK: " + women[_IntValue].UKSize.ToString());
                }
                else if (_AllSettings.RadWCountryUS)
                {
                    _Settings.Size05 = string.Format("US: " + women[_IntValue].USSize.ToString());
                }
                else if (_AllSettings.RadWCountryEU)
                {
                    _Settings.Size05 = string.Format("EURO: " + women[_IntValue].EUROSize.ToString());
                }
                else if (_AllSettings.RadWCountryAU)
                {
                    _Settings.Size05 = string.Format("AU: " + women[_IntValue].AUSSize.ToString());
                }
            }

            _Settings.Bust05 = (_CmToInches) ? women[_IntValue].BustCMS.ToString() + "cm" : women[_IntValue].BustInches.ToString() + "in";
            _Settings.Waist05 = (_CmToInches) ? women[_IntValue].WaistCMS.ToString() + "cm" : women[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip05 = (_CmToInches) ? women[_IntValue].HipCMS.ToString() + "cm" : women[_IntValue].HipInches.ToString() + "in";

        }
        private void RestoreAll()
        {
            txbName01.Text = _Settings.Name01;
            txbName02.Text = _Settings.Name02;
            txbName03.Text = _Settings.Name03;
            txbName04.Text = _Settings.Name04;
            txbName05.Text = _Settings.Name05;
        }
        private void navigation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (sender == txbName01)
            {
                NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=0", UriKind.Relative));
            }
            else if (sender == txbName02)
            {
                NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=1", UriKind.Relative));
            }
            else if (sender == txbName03)
            {
                NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=2", UriKind.Relative));
            }
            else if (sender == txbName04)
            {
                NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=3", UriKind.Relative));
            }
            else if (sender == txbName05)
            {
                NavigationService.Navigate(new Uri("/WomenSaves.xaml?goto=4", UriKind.Relative));
            }
            else
            {
                return;
            }
        }
    }
}