using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using Shopping_Discount_Calculator.Resources;

namespace Shopping_Discount_Calculator
{
    public partial class Child : PhoneApplicationPage
    {
        private bool _IsInitialzed = false;
        private int _IntValue;
        private bool _DeleteButtonVisible = false;
        private bool _SaveButtonVisible = false;

        private ChildSettings _Settings = new ChildSettings();
        private Settings _AllSettings = new Settings();

        ApplicationBarIconButton appBarButtonEdit;
        ApplicationBarIconButton appBarButtonHome;
        ApplicationBarIconButton appBarButtonDelete;
        ApplicationBarIconButton appBarButtonSave;

        private struct ChildClothesSizes
        {
            public string UKSize, USSize, EUSize, AUSize;
        }

        public Child()
        {
            InitializeComponent();
            _IsInitialzed = true;

            _IntValue = (int)sldChild.Value;
            clothing(child, _IntValue);

            ApplicationBar = new ApplicationBar();
            BuildLocalizedAppBarReadOnly();
            BuildLocalizedApplicationBarShared();

            HideCheckBoxes();
            MakeReadOnly();

        }
        #region Protected Events
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RestoreAll();

            string strItemIndex;
            if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndex))
                MyPivot.SelectedIndex = Convert.ToInt32(strItemIndex);
        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (_DeleteButtonVisible || _SaveButtonVisible)
            {
                RestoreAll();
                if (_SaveButtonVisible)
                {
                    MakeReadOnly();
                    HideCheckBoxes();
                    ApplicationBar.Buttons.Remove(appBarButtonSave);
                    BuildLocalizedAppBarReadOnly();
                    BuildLocalizedAppBarEditReadOnly();
                    _SaveButtonVisible = false;
                }
                else
                {
                    CheckedFalse();
                    _SaveButtonVisible = true;
                    _DeleteButtonVisible = false;
                    ApplicationBar.Buttons.Remove(appBarButtonDelete);
                }
                e.Cancel = true;
            }
            else
            {
                SaveAll();
            }
        }
        #endregion

        private void SelectAll_Focus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        #region child sizes
        private readonly ChildClothesSizes[] child = new ChildClothesSizes[]
        {
            new ChildClothesSizes
            {
                UKSize = "12m",
                USSize = "12-18m",
                EUSize = "80cm",
                AUSize = "-",
            },
            new ChildClothesSizes
            {
                UKSize = "18m",
                USSize = "18-24m",
                EUSize = "80-86cm",
                AUSize = "18m",
},
new ChildClothesSizes
{
                UKSize = "24m",
                USSize = "23/24m",
                EUSize = "86-92cm",
                AUSize = "2",
},
new ChildClothesSizes
{
                UKSize = "2-3",
                USSize = "2T",
                EUSize = "92-98cm",
                AUSize = "3",
},
new ChildClothesSizes
{
                UKSize = "3-4",
                USSize = "4T",
                EUSize = "98-104cm",
                AUSize = "4",
},
new ChildClothesSizes
{
                UKSize = "4-5",
                USSize = "5",
                EUSize = "104-110cm",
                AUSize = "5",
},
new ChildClothesSizes
{
                UKSize = "5-6",
                USSize = "6",
                EUSize = "110-116cm",
                AUSize = "6",
},
new ChildClothesSizes
{
                UKSize = "6-7",
                USSize = "6X-7",
                EUSize = "116-122cm",
                AUSize = "7",
},
new ChildClothesSizes
{
                UKSize = "7-8",
                USSize = "7-8",
                EUSize = "122-128cm",
                AUSize = "8",
},
new ChildClothesSizes
{
                UKSize = "8-9",
                USSize = "9-10",
                EUSize = "128-134cm",
                AUSize = "9",
},
new ChildClothesSizes
{
                UKSize = "8-10",
                USSize = "10",
                EUSize = "134-140cm",
                AUSize = "10",
},
new ChildClothesSizes
{
                UKSize = "10-11",
                USSize = "11",
                EUSize = "104-146cm",
                AUSize = "11",
},
new ChildClothesSizes
{
                UKSize = "11-12",
                USSize = "14",
                EUSize = "146-152cm",
                AUSize = "12",
},
        };
        #endregion
        private void clothing(ChildClothesSizes[] child, int intValue)
        {
            txbUK.Text = child[intValue].UKSize;
            txbUS.Text = child[intValue].UKSize;
            txbEU.Text = child[intValue].EUSize;
            txbAU.Text = child[intValue].AUSize;
        }
        private void sldChild_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _IntValue = (int)sldChild.Value;
            clothing(child, _IntValue);
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
            MyPivot.SelectedIndex = 1;

            switch (slot)
            {
                case 1:
                    txtName01.Text = _Settings.CName01;
                    txtSize01.Text = _Settings.CSize01;
                    break;
                case 2:
                    txtName02.Text = _Settings.CName02;
                    txtSize02.Text = _Settings.CSize02;
                    break;
                case 3:
                    txtName03.Text = _Settings.CName03;
                    txtSize03.Text = _Settings.CSize03;
                    break;
                case 4:
                    txtName04.Text = _Settings.CName04;
                    txtSize04.Text = _Settings.CSize04;
                    break;
                case 5:
                    txtName05.Text = _Settings.CName05;
                    txtSize05.Text = _Settings.CSize05;
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
            if (_Settings.CName01 == "default name 01" && _Settings.CSize01 == "default size 01")
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
            if (_Settings.CName02 == "default name 02" && _Settings.CSize02 == "default size 02")
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
            if (_Settings.CName03 == "default name 03" && _Settings.CSize03 == "default size 03")
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
            if (_Settings.CName04 == "default name 04" && _Settings.CSize04 == "default size 04")
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
            if (_Settings.CName05 == "default name 05" && _Settings.CSize05 == "default size 05")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #region Save
        private void SaveCustomAll()
        {
            SaveCustom01();
            SaveCustom02();
            SaveCustom03();
            SaveCustom04();
            SaveCustom05();
        }
        private void SaveCustom01()
        {
            _Settings.CName01 = txtName01.Text;
            _Settings.CSize01 = txtSize01.Text;
        }
        private void SaveCustom02()
        {
            _Settings.CName02 = txtName02.Text;
            _Settings.CSize02 = txtSize02.Text;
        }
        private void SaveCustom03()
        {
            _Settings.CName03 = txtName03.Text;
            _Settings.CSize03 = txtSize03.Text;
        }
        private void SaveCustom04()
        {
            _Settings.CName04 = txtName04.Text;
            _Settings.CSize04 = txtSize04.Text;
        }
        private void SaveCustom05()
        {
            _Settings.CName05 = txtName05.Text;
            _Settings.CSize05 = txtSize05.Text;
        }

        private void SaveAll()
        {
            Save01();
            Save02();
            Save03();
            Save04();
            Save05();
        }
        private void Save01()
        {
            if (!_AllSettings.RadCCountryUK && !_AllSettings.RadCCountryUS &&
                !_AllSettings.RadCCountryEU && !_AllSettings.RadCCountryAU)
            {
                _Settings.CSize01 = "UK: " + child[_IntValue].UKSize +
                Environment.NewLine + "US: " + child[_IntValue].USSize +
                Environment.NewLine + "EU: " + child[_IntValue].EUSize +
                Environment.NewLine + "AUS: " + child[_IntValue].AUSize;
            }
            else if (_AllSettings.RadCCountryUK)
            {
                _Settings.CSize01 = "UK: " + child[_IntValue].UKSize;
            }
            else if (_AllSettings.RadCCountryUS)
            {
                _Settings.CSize01 = "US: " + child[_IntValue].USSize;
            }
            else if (_AllSettings.RadCCountryEU)
            {
                _Settings.CSize01 = "EU: " + child[_IntValue].EUSize;
            }
            else if (_AllSettings.RadCCountryAU)
            {
                _Settings.CSize01 = "AUS: " + child[_IntValue].AUSize;
            }
        }
        private void Save02()
        {
            if (_AllSettings.RadCCountryUK)
            {
                _Settings.CSize02 = "UK: " + child[_IntValue].UKSize;
            }
            else if (_AllSettings.RadCCountryUS)
            {
                _Settings.CSize02 = "US: " + child[_IntValue].USSize;
            }
            else if (_AllSettings.RadCCountryEU)
            {
                _Settings.CSize02 = "EU: " + child[_IntValue].EUSize;
            }
            else if (_AllSettings.RadCCountryAU)
            {
                _Settings.CSize02 = "AUS: " + child[_IntValue].AUSize;
            }
            else
            {
                _Settings.CSize02 = "UK: " + child[_IntValue].UKSize +
                    Environment.NewLine + "US: " + child[_IntValue].USSize +
                    Environment.NewLine + "EU: " + child[_IntValue].EUSize +
                    Environment.NewLine + "AUS: " + child[_IntValue].AUSize;
            }
        }
        private void Save03()
        {
            if (_AllSettings.RadCCountryUK)
            {
                _Settings.CSize03 = "UK: " + child[_IntValue].UKSize;
            }
            else if (_AllSettings.RadCCountryUS)
            {
                _Settings.CSize03 = "US: " + child[_IntValue].USSize;
            }
            else if (_AllSettings.RadCCountryEU)
            {
                _Settings.CSize03 = "EU: " + child[_IntValue].EUSize;
            }
            else if (_AllSettings.RadCCountryAU)
            {
                _Settings.CSize03 = "AUS: " + child[_IntValue].AUSize;
            }
            else
            {
                _Settings.CSize03 = "UK: " + child[_IntValue].UKSize +
                    Environment.NewLine + "US: " + child[_IntValue].USSize +
                    Environment.NewLine + "EU: " + child[_IntValue].EUSize +
                    Environment.NewLine + "AUS: " + child[_IntValue].AUSize;
            }
        }
        private void Save04()
        {
            if (_AllSettings.RadCCountryUK)
            {
                _Settings.CSize04 = "UK: " + child[_IntValue].UKSize;
            }
            else if (_AllSettings.RadCCountryUS)
            {
                _Settings.CSize04 = "US: " + child[_IntValue].USSize;
            }
            else if (_AllSettings.RadCCountryEU)
            {
                _Settings.CSize04 = "EU: " + child[_IntValue].EUSize;
            }
            else if (_AllSettings.RadCCountryAU)
            {
                _Settings.CSize04 = "AUS: " + child[_IntValue].AUSize;
            }
            else
            {
                _Settings.CSize04 = "UK: " + child[_IntValue].UKSize +
                    Environment.NewLine + "US: " + child[_IntValue].USSize +
                    Environment.NewLine + "EU: " + child[_IntValue].EUSize +
                    Environment.NewLine + "AUS: " + child[_IntValue].AUSize;
            }
        }
        private void Save05()
        {
            if (_AllSettings.RadCCountryUK)
            {
                _Settings.CSize05 = "UK: " + child[_IntValue].UKSize;
            }
            else if (_AllSettings.RadCCountryUS)
            {
                _Settings.CSize05 = "US: " + child[_IntValue].USSize;
            }
            else if (_AllSettings.RadCCountryEU)
            {
                _Settings.CSize05 = "EU: " + child[_IntValue].EUSize;
            }
            else if (_AllSettings.RadCCountryAU)
            {
                _Settings.CSize05 = "AUS: " + child[_IntValue].AUSize;
            }
            else
            {
                _Settings.CSize05 = "UK: " + child[_IntValue].UKSize +
                    Environment.NewLine + "US: " + child[_IntValue].USSize +
                    Environment.NewLine + "EU: " + child[_IntValue].EUSize +
                    Environment.NewLine + "AUS: " + child[_IntValue].AUSize;
            }
        }
        #endregion

        private void RestoreAll()
        {
            txtName01.Text = _Settings.CName01;
            txtName02.Text = _Settings.CName02;
            txtName03.Text = _Settings.CName03;
            txtName04.Text = _Settings.CName04;
            txtName05.Text = _Settings.CName05;

            txtSize01.Text = _Settings.CSize01;
            txtSize02.Text = _Settings.CSize02;
            txtSize03.Text = _Settings.CSize03;
            txtSize04.Text = _Settings.CSize04;
            txtSize05.Text = _Settings.CSize05;
        }
        private void KeyDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == txtName01)
                {
                    txtSize01.Focus();
                }
                else if (sender == txtSize01)
                {
                    txtName02.Focus();
                }
                else if (sender == txtName02)
                {
                    txtSize02.Focus();
                }
                else if (sender == txtSize02)
                {
                    txtName03.Focus();
                }
                else if (sender == txtName03)
                {
                    txtSize03.Focus();
                }
                else if (sender == txtSize03)
                {
                    txtName04.Focus();
                }
                else if (sender == txtName04)
                {
                    txtSize04.Focus();
                }
                else if (sender == txtSize04)
                {
                    txtName05.Focus();
                }
                else if (sender == txtSize05)
                {
                    txtName01.Focus();
                }
            }
            else
            {
                return;
            }
        }
        #region visibility methods
        private void ShowCheckBoxes()
        {
            cbxSave01.Visibility = System.Windows.Visibility.Visible;
            cbxSave02.Visibility = System.Windows.Visibility.Visible;
            cbxSave03.Visibility = System.Windows.Visibility.Visible;
            cbxSave04.Visibility = System.Windows.Visibility.Visible;
            cbxSave05.Visibility = System.Windows.Visibility.Visible;
        }
        private void MakeEditable()
        {
            txtName01.IsReadOnly = false;
            txtSize01.IsReadOnly = false;
            txtSize02.IsReadOnly = false;
            txtName02.IsReadOnly = false;
            txtName03.IsReadOnly = false;
            txtSize03.IsReadOnly = false;
            txtName04.IsReadOnly = false;
            txtSize04.IsReadOnly = false;
            txtName05.IsReadOnly = false;
            txtSize05.IsReadOnly = false;

            txtName01.IsEnabled = true;
            txtSize01.IsEnabled = true;
            txtSize02.IsEnabled = true;
            txtName02.IsEnabled = true;
            txtName03.IsEnabled = true;
            txtSize03.IsEnabled = true;
            txtName04.IsEnabled = true;
            txtSize04.IsEnabled = true;
            txtName05.IsEnabled = true;
            txtSize05.IsEnabled = true;

        }
        private void HideCheckBoxes()
        {
            cbxSave01.Visibility = System.Windows.Visibility.Collapsed;
            cbxSave02.Visibility = System.Windows.Visibility.Collapsed;
            cbxSave03.Visibility = System.Windows.Visibility.Collapsed;
            cbxSave04.Visibility = System.Windows.Visibility.Collapsed;
            cbxSave05.Visibility = System.Windows.Visibility.Collapsed;

            CheckedFalse();

            _DeleteButtonVisible = false;
        }

        private void CheckedFalse()
        {
            cbxSave01.IsChecked = false;
            cbxSave02.IsChecked = false;
            cbxSave03.IsChecked = false;
            cbxSave04.IsChecked = false;
            cbxSave05.IsChecked = false;
        }
        private void MakeReadOnly()
        {
            txtName01.IsReadOnly = true;
            txtSize01.IsReadOnly = true;
            txtSize02.IsReadOnly = true;
            txtName02.IsReadOnly = true;
            txtName03.IsReadOnly = true;
            txtSize03.IsReadOnly = true;
            txtName04.IsReadOnly = true;
            txtSize04.IsReadOnly = true;
            txtName05.IsReadOnly = true;
            txtSize05.IsReadOnly = true;

            txtName01.IsEnabled = false;
            txtSize01.IsEnabled = false;
            txtSize02.IsEnabled = false;
            txtName02.IsEnabled = false;
            txtName03.IsEnabled = false;
            txtSize03.IsEnabled = false;
            txtName04.IsEnabled = false;
            txtSize04.IsEnabled = false;
            txtName05.IsEnabled = false;
            txtSize05.IsEnabled = false;

        }
        #endregion
        private void Clear()
        {
            if (cbxSave01.IsChecked == true)
            {
                txtName01.Text = "default name 01";
                txtSize01.Text = "default size 01";

                SaveCustom01();
            }
            if (cbxSave02.IsChecked == true)
            {
                txtName02.Text = "default name 02";
                txtSize02.Text = "default size 02";
                
                SaveCustom02();
            }
            if (cbxSave03.IsChecked == true)
            {
                txtName03.Text = "default name 03";
                txtSize03.Text = "default size 03";
                
                SaveCustom03();
            }
            if (cbxSave04.IsChecked == true)
            {
                txtName04.Text = "default name 04";
                txtSize04.Text = "default size 04";

                SaveCustom04();
            }
            if (cbxSave05.IsChecked == true)
            {
                txtName05.Text = "default name 05";
                txtSize05.Text = "default size 05";

                SaveCustom05();
            }
        }

        #region navigation bar
        private void BuildLocalizedAppBarReadOnly()
        {
            _SaveButtonVisible = false;
            _DeleteButtonVisible = false;
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonDelete);
            ApplicationBar.Buttons.Remove(appBarButtonSave);

            //create a new button and set the text value to localized string from AppResources.
            appBarButtonHome = new ApplicationBarIconButton(new Uri("/Assets/AppBar/home.png", UriKind.Relative));
            appBarButtonHome.Text = AppResources.AppBarButtonHome;
            ApplicationBar.Buttons.Add(appBarButtonHome);
            appBarButtonHome.Click += appBarButtonHome_Click;

        }
        private void BuildLocalizedAppBarEditReadOnly()
        {
            appBarButtonEdit = new ApplicationBarIconButton(new Uri("/Assets/AppBar/edit.png", UriKind.Relative));
            appBarButtonEdit.Text = AppResources.AppBarButtonEdit;
            ApplicationBar.Buttons.Add(appBarButtonEdit);
            appBarButtonEdit.Click += appBarButtonEdit_Click;
        }
        void appBarButtonHome_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/StartScreen.xaml", UriKind.Relative));
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
        private void BuildLocalizedApplicationBarDelete()
        {
            _SaveButtonVisible = false;
            _DeleteButtonVisible = true;
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            ApplicationBar.Buttons.Remove(appBarButtonHome);
            ApplicationBar.Buttons.Remove(appBarButtonSave);
            //create a new button. delete
            appBarButtonDelete = new ApplicationBarIconButton(new Uri("/Assets/AppBar/delete.png", UriKind.Relative));
            appBarButtonDelete.Text = "delete";
            ApplicationBar.Buttons.Add(appBarButtonDelete);
            appBarButtonDelete.Click += appBarButtonDelete_Click;
        }
        private void BuildLocalizedApplicationBarSave()
        {
            _SaveButtonVisible = true;
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            ApplicationBar.Buttons.Remove(appBarButtonHome);
            //create a new button. save
            appBarButtonSave = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButtonSave.Text = "save";
            ApplicationBar.Buttons.Add(appBarButtonSave);
            appBarButtonSave.Click += appBarButtonSave_Click;
        }

        private void appBarButtonDelete_Click(object sender, EventArgs e)
        {
            //delete the ones that are checked
            Clear();
            //hide the checkboxes
            HideCheckBoxes();
            MakeReadOnly();
            //reset the navigation bar
            ApplicationBar.Buttons.Remove(appBarButtonDelete);
            ApplicationBar.Buttons.Remove(appBarButtonSave);
            BuildLocalizedAppBarReadOnly();
            BuildLocalizedAppBarEditReadOnly();
        }

        private void appBarAboutMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
        private void appBarHowToMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HowToUse.xaml", UriKind.Relative));
        }
        private void appBarSettingsMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/settings.xaml", UriKind.Relative));
        }
        private void appBarButtonEdit_Click(object sender, EventArgs e)
        {
            //show save button
            BuildLocalizedApplicationBarSave();
            ShowCheckBoxes();
            MakeEditable();
        }
        private void appBarButtonSave_Click(object sender, EventArgs e)
        {
            SaveCustomAll();

            _DeleteButtonVisible = false;

            HideCheckBoxes();
            BuildLocalizedAppBarReadOnly();
            BuildLocalizedAppBarEditReadOnly();
            ApplicationBar.Buttons.Remove(appBarButtonSave);
            MakeReadOnly();
            this.Focus();
        }
        #endregion

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            ApplicationBar.Buttons.Remove(appBarButtonDelete);
            ApplicationBar.Buttons.Remove(appBarButtonSave);
            ApplicationBar.Buttons.Remove(appBarButtonHome);

            if (MyPivot.SelectedIndex == 1)
            {
                BuildLocalizedAppBarReadOnly();
                BuildLocalizedAppBarEditReadOnly();
            }
            else
            {
                ApplicationBar.Buttons.Remove(appBarButtonHome);
                HideCheckBoxes();
                MakeReadOnly();
                ApplicationBar.Buttons.Remove(appBarButtonDelete);
                ApplicationBar.Buttons.Remove(appBarButtonSave);
                BuildLocalizedAppBarReadOnly();
            }
        }

        private void checkBoxAction_Checked(object sender, RoutedEventArgs e)
        {
            ApplicationBar.Buttons.Remove(appBarButtonSave);

            if (cbxSave01.IsChecked == true || cbxSave02.IsChecked == true || 
                cbxSave03.IsChecked == true || cbxSave04.IsChecked == true || cbxSave05.IsChecked == true )
            {
                if (!_DeleteButtonVisible)
                {
                    BuildLocalizedApplicationBarDelete();            
                }
            }
        }

        private void checkBoxAction_UnChecked(object sender, RoutedEventArgs e)
        {
            if (cbxSave01.IsChecked == false && cbxSave02.IsChecked == false &&
                cbxSave03.IsChecked == false && cbxSave04.IsChecked == false && cbxSave05.IsChecked == false)
            {
                _DeleteButtonVisible = false;
                ApplicationBar.Buttons.Remove(appBarButtonDelete);
                BuildLocalizedAppBarReadOnly();
                BuildLocalizedApplicationBarSave();
            }
        }
    }
}