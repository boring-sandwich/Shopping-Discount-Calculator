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

namespace Shopping_Discount_Calculator
{
    public partial class Men : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private bool _CmToInches = false;
        private int _IntValue;

        private MenSettings _Settings = new MenSettings();
        private Settings _AllSettings = new Settings();
        private struct MensClothesSizes
        {
            public int UKUSAUSSize;
            public int EUROSize;
            public string SizeName;
            public double ChestInches;
            public double WaistInches;
            public double HipInches;
            public double ChestCMS;
            public double WaistCMS;
            public double HipCMS;
        }
        public Men()
        {
            InitializeComponent();
            _IsInitialized = true;

            _IntValue = (int)sldMen.Value;
            Clothing(men, _IntValue);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RestoreAll();
        }
        #region men clothing sizes
        private readonly MensClothesSizes[] men = new MensClothesSizes[]
            {
    new MensClothesSizes
            {
            UKUSAUSSize = 32,
            EUROSize = 42,
            SizeName = "small",
            ChestInches = 36,
            WaistInches = 27,
            HipInches = 38,
            ChestCMS = 91,
            WaistCMS = 67,
            HipCMS = 96.5,
    },
     new MensClothesSizes
            {
            UKUSAUSSize = 34,
            EUROSize = 44,
            SizeName = "small",
            ChestInches = 37,
            WaistInches = 29,
            HipInches = 39,
            ChestCMS = 94,
            WaistCMS = 74,
            HipCMS = 99,
    },
        new MensClothesSizes
            {
            UKUSAUSSize = 36,
            EUROSize = 46,
            SizeName = "small",
            ChestInches = 38,
            WaistInches = 31,
            HipInches = 40,
            ChestCMS = 96,
            WaistCMS = 79,
            HipCMS = 102,
    },
    new MensClothesSizes
{
            UKUSAUSSize = 38,
            EUROSize = 48,
            SizeName = "medium",
            ChestInches = 39.4,
            WaistInches = 33,
            HipInches = 41,
            ChestCMS = 100,
            WaistCMS = 84,
            HipCMS = 104,

},
    new MensClothesSizes
{
            UKUSAUSSize = 40,
            EUROSize = 50,
            SizeName = "medium",
            ChestInches = 41,
            WaistInches = 35,
            HipInches = 42,
            ChestCMS = 104,
            WaistCMS = 89,
            HipCMS = 107,
},
new MensClothesSizes
{
            UKUSAUSSize = 42,
            EUROSize = 52,
            SizeName = "large",
            ChestInches = 42.6,
            WaistInches = 37,
            HipInches = 44,
            ChestCMS = 108,
            WaistCMS = 94,
            HipCMS = 112,
},
new MensClothesSizes
{
            UKUSAUSSize = 44,
            EUROSize = 54,
            SizeName = "large",
            ChestInches = 44.2,
            WaistInches = 39,
            HipInches = 46,
            ChestCMS = 112,
            WaistCMS = 99,
            HipCMS = 117,
},
new MensClothesSizes
{
            UKUSAUSSize = 46,
            EUROSize = 56,
            SizeName = "x-large",
            ChestInches = 45.8,
            WaistInches = 41,
            HipInches = 48,
            ChestCMS = 116,
            WaistCMS = 104,
            HipCMS = 122,
},
new MensClothesSizes
{
            UKUSAUSSize = 48,
            EUROSize = 58,
            SizeName = "x-large",
            ChestInches = 47.5,
            WaistInches = 43,
            HipInches = 50,
            ChestCMS = 121,
            WaistCMS = 109,
            HipCMS = 127,
},
new MensClothesSizes
{
            UKUSAUSSize = 50,
            EUROSize = 60,
            SizeName = "xx-large",
            ChestInches = 49.2,
            WaistInches = 45,
            HipInches = 52,
            ChestCMS = 125,
            WaistCMS = 114,
            HipCMS = 132,
},
new MensClothesSizes
{
            UKUSAUSSize = 52,
            EUROSize = 62,
            SizeName = "xx-large",
            ChestInches = 50.9,
            WaistInches = 47,
            HipInches = 54,
            ChestCMS = 129,
            WaistCMS = 119,
            HipCMS = 137,
},
};
        #endregion
        private void Clothing(MensClothesSizes[] men, int intValue)
        {
            txbMUKUSAUSSize.Text = men[intValue].UKUSAUSSize.ToString();
            txbMEUROSize.Text = men[intValue].EUROSize.ToString();
            txbMName.Text = men[intValue].SizeName;
            if (!_CmToInches)
            {
                txbMBust.Text = men[intValue].ChestInches.ToString() + "in";
                txbMWaist.Text = men[intValue].WaistInches.ToString() + "in";
                txbMHip.Text = men[intValue].HipInches.ToString() + "in";
            }
            else
            {
                txbMBust.Text = men[intValue].ChestCMS.ToString() + "cm";
                txbMWaist.Text = men[intValue].WaistCMS.ToString() + "cm";
                txbMHip.Text = men[intValue].HipCMS.ToString() + "cm";
            }
        }
        private void sldMen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _IntValue = (int)sldMen.Value;
            Clothing(men, _IntValue);
        }
        private void btnMMeasurementChange_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (_CmToInches)
            {
                _CmToInches = false;
                btnMMeasurementChange.Content = "inches";
            }
            else
            {
                _CmToInches = true;
                btnMMeasurementChange.Content = "cm";
            }
            Clothing(men, _IntValue);
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
                    NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=0", UriKind.Relative));
                    break;
                case 2:
                    NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=1", UriKind.Relative));
                    break;
                case 3:
                    NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=2", UriKind.Relative));
                    break;
                case 4:
                    NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=3", UriKind.Relative));
                    break;
                case 5:
                    NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=4", UriKind.Relative));
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
            if (_Settings.MName01 == "default name 01" && _Settings.MSize01 == "default size 01"
                && _Settings.MChest01 == "00" && _Settings.MWaist1 == "00" && _Settings.MHip1 == "00")
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
                && _Settings.Chest02 == "00" && _Settings.Waist2 == "00" && _Settings.Hip2 == "00")
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
                && _Settings.Chest03 == "00" && _Settings.Waist3 == "00" && _Settings.Hip3 == "00")
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
                && _Settings.Chest04 == "00" && _Settings.Waist4 == "00" && _Settings.Hip4 == "00")
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
                && _Settings.Chest05 == "00" && _Settings.Waist5 == "00" && _Settings.Hip5 == "00")
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
            _Settings.MName01 = men[_IntValue].SizeName.ToString() + "@ ";

            if (!_AllSettings.RadMCountryUS && !_AllSettings.RadMCountryEU)
            {
                _Settings.MSize01 = string.Format("UK/US/AUS: {0}" + Environment.NewLine + "EU: {1}",
                            men[_IntValue].UKUSAUSSize.ToString(), men[_IntValue].EUROSize.ToString());
            }
            else
            {
                if (_AllSettings.RadMCountryUS)
                {
                    _Settings.MSize01 = string.Format("UK/US/AUS:: " + men[_IntValue].UKUSAUSSize.ToString());
                }
                else if (_AllSettings.RadMCountryEU)
                {
                    _Settings.MSize01 = string.Format("EU: " + men[_IntValue].EUROSize.ToString());
                }
            }
            _Settings.MChest01 = (_CmToInches) ? men[_IntValue].ChestCMS.ToString() + "cm" : men[_IntValue].ChestInches.ToString() + "in";
            _Settings.MWaist1 = (_CmToInches) ? men[_IntValue].WaistCMS.ToString() + "cm" : men[_IntValue].WaistInches.ToString() + "in";
            _Settings.MHip1 = (_CmToInches) ? men[_IntValue].HipCMS.ToString() + "cm" : men[_IntValue].HipInches.ToString() + "in";

        }
        private void Save02()
        {
            _Settings.Name02 = men[_IntValue].SizeName.ToString() + "@ ";
            if (!_AllSettings.RadMCountryUS && !_AllSettings.RadMCountryEU)
            {
                _Settings.Size02 = string.Format("UK/US/AUS: {0}" + Environment.NewLine + "EU: {1}",
                            men[_IntValue].UKUSAUSSize.ToString(), men[_IntValue].EUROSize.ToString());
            }
            else
            {
                if (_AllSettings.RadMCountryUS)
                {
                    _Settings.Size02 = string.Format("UK/US/AUS:: " + men[_IntValue].UKUSAUSSize.ToString());
                }
                else if (_AllSettings.RadMCountryEU)
                {
                    _Settings.Size02 = string.Format("EU: " + men[_IntValue].EUROSize.ToString());
                }
            }

            _Settings.Chest02 = (_CmToInches) ? men[_IntValue].ChestCMS.ToString() + "cm" : men[_IntValue].ChestInches.ToString() + "in";
            _Settings.Waist2 = (_CmToInches) ? men[_IntValue].WaistCMS.ToString() + "cm" : men[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip2 = (_CmToInches) ? men[_IntValue].HipCMS.ToString() + "cm" : men[_IntValue].HipInches.ToString() + "in";

        }
        private void Save03()
        {
            _Settings.Name03 = men[_IntValue].SizeName.ToString() + "@ ";
            if (!_AllSettings.RadMCountryUS && !_AllSettings.RadMCountryEU)
            {
                _Settings.Size03 = string.Format("UK/US/AUS: {0}" + Environment.NewLine + "EU: {1}",
                            men[_IntValue].UKUSAUSSize.ToString(), men[_IntValue].EUROSize.ToString());
            }
            else
            {
                if (_AllSettings.RadMCountryUS)
                {
                    _Settings.Size03 = string.Format("UK/US/AUS:: " + men[_IntValue].UKUSAUSSize.ToString());
                }
                else if (_AllSettings.RadMCountryEU)
                {
                    _Settings.Size03 = string.Format("EU: " + men[_IntValue].EUROSize.ToString());
                }
            }
            _Settings.Chest03 = (_CmToInches) ? men[_IntValue].ChestCMS.ToString() + "cm" : men[_IntValue].ChestInches.ToString() + "in";
            _Settings.Waist3 = (_CmToInches) ? men[_IntValue].WaistCMS.ToString() + "cm" : men[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip3 = (_CmToInches) ? men[_IntValue].HipCMS.ToString() + "cm" : men[_IntValue].HipInches.ToString() + "in";
        }
        private void Save04()
        {
            _Settings.Name04 = men[_IntValue].SizeName.ToString() + "@ ";
            if (!_AllSettings.RadMCountryUS && !_AllSettings.RadMCountryEU)
            {
                _Settings.Size04 = string.Format("UK/US/AUS: {0}" + Environment.NewLine + "EU: {1}",
                            men[_IntValue].UKUSAUSSize.ToString(), men[_IntValue].EUROSize.ToString());
            }
            else
            {
                if (_AllSettings.RadMCountryUS)
                {
                    _Settings.Size04 = string.Format("UK/US/AUS:: " + men[_IntValue].UKUSAUSSize.ToString());
                }
                else if (_AllSettings.RadMCountryEU)
                {
                    _Settings.Size04 = string.Format("EU: " + men[_IntValue].EUROSize.ToString());
                }
            }
            _Settings.Chest04 = (_CmToInches) ? men[_IntValue].ChestCMS.ToString() + "cm" : men[_IntValue].ChestInches.ToString() + "in";
            _Settings.Waist4 = (_CmToInches) ? men[_IntValue].WaistCMS.ToString() + "cm" : men[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip4 = (_CmToInches) ? men[_IntValue].HipCMS.ToString() + "cm" : men[_IntValue].HipInches.ToString() + "in";
        }
        private void Save05()
        {
            _Settings.Name05 = men[_IntValue].SizeName.ToString() + "@ ";
            if (!_AllSettings.RadMCountryUS && !_AllSettings.RadMCountryEU)
            {
                _Settings.Size05 = string.Format("UK/US/AUS: {0}" + Environment.NewLine + "EU: {1}",
                            men[_IntValue].UKUSAUSSize.ToString(), men[_IntValue].EUROSize.ToString());
            }
            else
            {
                if (_AllSettings.RadMCountryUS)
                {
                    _Settings.Size05 = string.Format("UK/US/AUS:: " + men[_IntValue].UKUSAUSSize.ToString());
                }
                else if (_AllSettings.RadMCountryEU)
                {
                    _Settings.Size05 = string.Format("EU: " + men[_IntValue].EUROSize.ToString());
                }
            }
            _Settings.Chest05 = (_CmToInches) ? men[_IntValue].ChestCMS.ToString() + "cm" : men[_IntValue].ChestInches.ToString() + "in";
            _Settings.Waist5 = (_CmToInches) ? men[_IntValue].WaistCMS.ToString() + "cm" : men[_IntValue].WaistInches.ToString() + "in";
            _Settings.Hip5 = (_CmToInches) ? men[_IntValue].HipCMS.ToString() + "cm" : men[_IntValue].HipInches.ToString() + "in";

        }
        private void RestoreAll()
        {
            txbMName01.Text = _Settings.MName01;
            txbMName02.Text = _Settings.Name02;
            txbMName03.Text = _Settings.Name03;
            txbMName04.Text = _Settings.Name04;
            txbMName05.Text = _Settings.Name05;
        }
        private void navigation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (sender == txbMName01)
            {
                NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=0", UriKind.Relative));
            }
            else if (sender == txbMName02)
            {
                NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=1", UriKind.Relative));
            }
            else if (sender == txbMName03)
            {
                NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=2", UriKind.Relative));
            }
            else if (sender == txbMName04)
            {
                NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=3", UriKind.Relative));
            }
            else if (sender == txbMName05)
            {
                NavigationService.Navigate(new Uri("/MenSaves.xaml?goto=4", UriKind.Relative));
            }
            else
            {
                return;
            }
        }

    }
}