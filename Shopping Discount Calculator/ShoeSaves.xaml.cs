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
    public partial class ShoeSaves : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private ShoeSettings _ShoeSettings = new ShoeSettings();
        private bool _DeleteButtonVisible = false;
        private bool _SaveButtonVisible = false;

        ApplicationBarIconButton appBarButtonEdit;
        ApplicationBarIconButton appBarButtonHome;
        ApplicationBarIconButton appBarButtonDelete;
        ApplicationBarIconButton appBarButtonSave;

        public ShoeSaves()
        {
            InitializeComponent();
            _IsInitialized = true;
            ApplicationBar = new ApplicationBar();
            BuildLocalizedAppBarReadOnly();
            BuildLocalizedApplicationBarShared();
            RestoreAll();
            HideCheckBoxes();
            MakeReadOnly();
        }
        #region Protected Events        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string strItemIndex;
            if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndex))
                MyPivot.SelectedIndex = Convert.ToInt32(strItemIndex);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SaveAll();
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

        #region KeyDown and Focus
        private void SelectAll_Focus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        //movedown_keydown
        private void KeyDownWomen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == txtWName01)
                {
                    txtWSize01.Focus();
                }
                else if (sender == txtWSize01)
                {
                    txtWName02.Focus();
                }
                else if (sender == txtWName02)
                {
                    txtWSize02.Focus();
                }
                else if (sender == txtWSize02)
                {
                    txtWName03.Focus();
                }
                else if (sender == txtWName03)
                {
                    txtWSize03.Focus();
                }
                else if (sender == txtWSize03)
                {
                    txtWName04.Focus();
                }
                else if (sender == txtWName04)
                {
                    txtWSize04.Focus();
                }
                else if (sender == txtWSize04)
                {
                    txtWName05.Focus();
                }
                else if (sender == txtWSize05)
                {
                    txtWName01.Focus();
                }
            }
            else
            {
                return;
            }
        }
        private void KeyDownMen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == txtMName01)
                {
                    txtMSize01.Focus();
                }
                else if (sender == txtMSize01)
                {
                    txtMName02.Focus();
                }
                else if (sender == txtMName02)
                {
                    txtMSize02.Focus();
                }
                else if (sender == txtMSize02)
                {
                    txtMName03.Focus();
                }
                else if (sender == txtMName03)
                {
                    txtMSize03.Focus();
                }
                else if (sender == txtMSize03)
                {
                    txtMName04.Focus();
                }
                else if (sender == txtMName04)
                {
                    txtMSize04.Focus();
                }
                else if (sender == txtMSize04)
                {
                    txtMName05.Focus();
                }
                else if (sender == txtMSize05)
                {
                    txtMName01.Focus();
                }
            }
            else
            {
                return;
            }
        }
        private void KeyDownChild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (sender == txtCName01)
                {
                    txtCSize01.Focus();
                }
                else if (sender == txtCSize01)
                {
                    txtCName02.Focus();
                }
                else if (sender == txtCName02)
                {
                    txtCSize02.Focus();
                }
                else if (sender == txtCSize02)
                {
                    txtCName03.Focus();
                }
                else if (sender == txtCName03)
                {
                    txtCSize03.Focus();
                }
                else if (sender == txtCSize03)
                {
                    txtCName04.Focus();
                }
                else if (sender == txtCName04)
                {
                    txtCSize04.Focus();
                }
                else if (sender == txtCSize04)
                {
                    txtCName05.Focus();
                }
                else if (sender == txtCSize05)
                {
                    txtCName01.Focus();
                }
            }
            else
            {
                return;
            }
        }
        #endregion
        #region visibility methods
        private void ShowCheckBoxes()
        {
            cbxWSave01.Visibility = System.Windows.Visibility.Visible;
            cbxMSave01.Visibility = System.Windows.Visibility.Visible;
            cbxCSave01.Visibility = System.Windows.Visibility.Visible;
            cbxWSave02.Visibility = System.Windows.Visibility.Visible;
            cbxMSave02.Visibility = System.Windows.Visibility.Visible;
            cbxCSave02.Visibility = System.Windows.Visibility.Visible;
            cbxWSave03.Visibility = System.Windows.Visibility.Visible;
            cbxMSave03.Visibility = System.Windows.Visibility.Visible;
            cbxCSave03.Visibility = System.Windows.Visibility.Visible;
            cbxWSave04.Visibility = System.Windows.Visibility.Visible;
            cbxMSave04.Visibility = System.Windows.Visibility.Visible;
            cbxCSave04.Visibility = System.Windows.Visibility.Visible;
            cbxWSave05.Visibility = System.Windows.Visibility.Visible;
            cbxMSave05.Visibility = System.Windows.Visibility.Visible;
            cbxCSave05.Visibility = System.Windows.Visibility.Visible;
        }
        #region Editables
        
        private void MakeEditable()
        {
            MakeWomenEditable();
            MakeMenEditable();
            MakeChildEditable();
        }
        private void MakeWomenEditable()
        {
            txtWName01.IsReadOnly = false;
            txtWSize01.IsReadOnly = false;
            txtWSize02.IsReadOnly = false;
            txtWName02.IsReadOnly = false;
            txtWName03.IsReadOnly = false;
            txtWSize03.IsReadOnly = false;
            txtWName04.IsReadOnly = false;
            txtWSize04.IsReadOnly = false;
            txtWName05.IsReadOnly = false;
            txtWSize05.IsReadOnly = false;

            txtWName01.IsEnabled = true;
            txtWSize01.IsEnabled = true;
            txtWSize02.IsEnabled = true;
            txtWName02.IsEnabled = true;
            txtWName03.IsEnabled = true;
            txtWSize03.IsEnabled = true;
            txtWName04.IsEnabled = true;
            txtWSize04.IsEnabled = true;
            txtWName05.IsEnabled = true;
            txtWSize05.IsEnabled = true;

        }
        private void MakeMenEditable()
        {
            txtMName01.IsReadOnly = false;
            txtMSize01.IsReadOnly = false;
            txtMSize02.IsReadOnly = false;
            txtMName02.IsReadOnly = false;
            txtMName03.IsReadOnly = false;
            txtMSize03.IsReadOnly = false;
            txtMName04.IsReadOnly = false;
            txtMSize04.IsReadOnly = false;
            txtMName05.IsReadOnly = false;
            txtMSize05.IsReadOnly = false;

            txtMName01.IsEnabled = true;
            txtMSize01.IsEnabled = true;
            txtMSize02.IsEnabled = true;
            txtMName02.IsEnabled = true;
            txtMName03.IsEnabled = true;
            txtMSize03.IsEnabled = true;
            txtMName04.IsEnabled = true;
            txtMSize04.IsEnabled = true;
            txtMName05.IsEnabled = true;
            txtMSize05.IsEnabled = true;

        }
        private void MakeChildEditable()
        {
            txtCName01.IsReadOnly = false;
            txtCSize01.IsReadOnly = false;
            txtCSize02.IsReadOnly = false;
            txtCName02.IsReadOnly = false;
            txtCName03.IsReadOnly = false;
            txtCSize03.IsReadOnly = false;
            txtCName04.IsReadOnly = false;
            txtCSize04.IsReadOnly = false;
            txtCName05.IsReadOnly = false;
            txtCSize05.IsReadOnly = false;

            txtCName01.IsEnabled = true;
            txtCSize01.IsEnabled = true;
            txtCSize02.IsEnabled = true;
            txtCName02.IsEnabled = true;
            txtCName03.IsEnabled = true;
            txtCSize03.IsEnabled = true;
            txtCName04.IsEnabled = true;
            txtCSize04.IsEnabled = true;
            txtCName05.IsEnabled = true;
            txtCSize05.IsEnabled = true;

        }
        #endregion

        private void HideCheckBoxes()
        {
            cbxWSave01.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave01.Visibility = System.Windows.Visibility.Collapsed;
            cbxCSave01.Visibility = System.Windows.Visibility.Collapsed;
            cbxWSave02.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave02.Visibility = System.Windows.Visibility.Collapsed;
            cbxCSave02.Visibility = System.Windows.Visibility.Collapsed;
            cbxWSave03.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave03.Visibility = System.Windows.Visibility.Collapsed;
            cbxCSave03.Visibility = System.Windows.Visibility.Collapsed;
            cbxWSave04.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave04.Visibility = System.Windows.Visibility.Collapsed;
            cbxCSave04.Visibility = System.Windows.Visibility.Collapsed;
            cbxWSave05.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave05.Visibility = System.Windows.Visibility.Collapsed;
            cbxCSave05.Visibility = System.Windows.Visibility.Collapsed;

            CheckedFalse();

            _DeleteButtonVisible = false;

        }

        private void CheckedFalse()
        {
            cbxWSave01.IsChecked = false;
            cbxMSave01.IsChecked = false;
            cbxCSave01.IsChecked = false;
            cbxWSave02.IsChecked = false;
            cbxMSave02.IsChecked = false;
            cbxCSave02.IsChecked = false;
            cbxWSave03.IsChecked = false;
            cbxMSave03.IsChecked = false;
            cbxCSave03.IsChecked = false;
            cbxWSave04.IsChecked = false;
            cbxMSave04.IsChecked = false;
            cbxCSave04.IsChecked = false;
            cbxWSave05.IsChecked = false;
            cbxMSave05.IsChecked = false;
            cbxCSave05.IsChecked = false;
        }
        private void MakeReadOnly()
        {
            txtWName01.IsReadOnly = true;
            txtWSize01.IsReadOnly = true;
            txtWSize02.IsReadOnly = true;
            txtWName02.IsReadOnly = true;
            txtWName03.IsReadOnly = true;
            txtWSize03.IsReadOnly = true;
            txtWName04.IsReadOnly = true;
            txtWSize04.IsReadOnly = true;
            txtWName05.IsReadOnly = true;
            txtWSize05.IsReadOnly = true;

            txtMName01.IsReadOnly = true;
            txtMSize01.IsReadOnly = true;
            txtMSize02.IsReadOnly = true;
            txtMName02.IsReadOnly = true;
            txtMName03.IsReadOnly = true;
            txtMSize03.IsReadOnly = true;
            txtMName04.IsReadOnly = true;
            txtMSize04.IsReadOnly = true;
            txtMName05.IsReadOnly = true;
            txtMSize05.IsReadOnly = true;

            txtCName01.IsReadOnly = true;
            txtCSize01.IsReadOnly = true;
            txtCSize02.IsReadOnly = true;
            txtCName02.IsReadOnly = true;
            txtCName03.IsReadOnly = true;
            txtCSize03.IsReadOnly = true;
            txtCName04.IsReadOnly = true;
            txtCSize04.IsReadOnly = true;
            txtCName05.IsReadOnly = true;
            txtCSize05.IsReadOnly = true;

            txtWName01.IsEnabled = false;
            txtWSize01.IsEnabled = false;
            txtWSize02.IsEnabled = false;
            txtWName02.IsEnabled = false;
            txtWName03.IsEnabled = false;
            txtWSize03.IsEnabled = false;
            txtWName04.IsEnabled = false;
            txtWSize04.IsEnabled = false;
            txtWName05.IsEnabled = false;
            txtWSize05.IsEnabled = false;

            txtMName01.IsEnabled = false;
            txtMSize01.IsEnabled = false;
            txtMSize02.IsEnabled = false;
            txtMName02.IsEnabled = false;
            txtMName03.IsEnabled = false;
            txtMSize03.IsEnabled = false;
            txtMName04.IsEnabled = false;
            txtMSize04.IsEnabled = false;
            txtMName05.IsEnabled = false;
            txtMSize05.IsEnabled = false;

            txtCName01.IsEnabled = false;
            txtCSize01.IsEnabled = false;
            txtCSize02.IsEnabled = false;
            txtCName02.IsEnabled = false;
            txtCName03.IsEnabled = false;
            txtCSize03.IsEnabled = false;
            txtCName04.IsEnabled = false;
            txtCSize04.IsEnabled = false;
            txtCName05.IsEnabled = false;
            txtCSize05.IsEnabled = false;
        }
        #endregion
        #region clear methods
        private void ClearAll()
        {
            WomensClear();
            MensClear();
            ChildClear();
        }
        private void WomensClear()
        {
            if (cbxWSave01.IsChecked == true)
            {
                txtWName01.Text = "default name 01";
                txtWSize01.Text = "00";
            }
            if (cbxWSave02.IsChecked == true)
            {
                txtWName02.Text = "default name 02";
                txtWSize02.Text = "00";
            }
            if (cbxWSave03.IsChecked == true)
            {
                txtWName03.Text = "default name 03";
                txtWSize03.Text = "00";
            }
            if (cbxWSave04.IsChecked == true)
            {
                txtWName04.Text = "default name 04";
                txtWSize04.Text = "00";
            }
            if (cbxWSave05.IsChecked == true)
            {
                txtWName05.Text = "default name 05";
                txtWSize05.Text = "00";
            }
        }
        private void MensClear()
        {
            if (cbxMSave01.IsChecked == true)
            {
                txtMName01.Text = "default name 01";
                txtMSize01.Text = "00";
            }
            if (cbxMSave02.IsChecked == true)
            {
                txtMName02.Text = "default name 02";
                txtMSize02.Text = "00";
            }
            if (cbxMSave03.IsChecked == true)
            {
                txtMName03.Text = "default name 03";
                txtMSize03.Text = "00";
            }
            if (cbxMSave04.IsChecked == true)
            {
                txtMName04.Text = "default name 04";
                txtMSize04.Text = "00";
            }
            if (cbxMSave05.IsChecked == true)
            {
                txtMName05.Text = "default name 05";
                txtMSize05.Text = "00";
            }
        }
        private void ChildClear()
        {
            if (cbxCSave01.IsChecked == true)
            {
                txtCName01.Text = "default name 01";
                txtCSize01.Text = "00";
            }
            if (cbxCSave02.IsChecked == true)
            {
                txtCName02.Text = "default name 02";
                txtCSize02.Text = "00";
            }
            if (cbxCSave03.IsChecked == true)
            {
                txtCName03.Text = "default name 03";
                txtCSize03.Text = "00";
            }
            if (cbxCSave04.IsChecked == true)
            {
                txtCName04.Text = "default name 04";
                txtCSize04.Text = "00";
            }
            if (cbxCSave05.IsChecked == true)
            {
                txtCName05.Text = "default name 05";
                txtCSize05.Text = "00";
            }
        }
        #endregion
        #region restore method
        private void RestoreAll()
        {
            RestoreWomensData();
            RestoreMensData();
            RestoreChildData();
        }
        private void RestoreWomensData()
        {
            txtWName01.Text = _ShoeSettings.WomenName01;
            txtWSize01.Text = _ShoeSettings.WomenSize01;
            txtWName02.Text = _ShoeSettings.WomenName02;
            txtWSize02.Text = _ShoeSettings.WomenSize02;
            txtWName03.Text = _ShoeSettings.WomenName03;
            txtWSize03.Text = _ShoeSettings.WomenSize03;
            txtWName04.Text = _ShoeSettings.WomenName04;
            txtWSize04.Text = _ShoeSettings.WomenSize04;
            txtWName05.Text = _ShoeSettings.WomenName05;
            txtWSize05.Text = _ShoeSettings.WomenSize05;
        }
        private void RestoreMensData()
        {
            txtMName01.Text = _ShoeSettings.MenName01;
            txtMSize01.Text = _ShoeSettings.MenSize01;
            txtMName02.Text = _ShoeSettings.MenName02;
            txtMSize02.Text = _ShoeSettings.MenSize02;
            txtMName03.Text = _ShoeSettings.MenName03;
            txtMSize03.Text = _ShoeSettings.MenSize03;
            txtMName04.Text = _ShoeSettings.MenName04;
            txtMSize04.Text = _ShoeSettings.MenSize04;
            txtMName05.Text = _ShoeSettings.MenName05;
            txtMSize05.Text = _ShoeSettings.MenSize05;
        }
        private void RestoreChildData()
        {
            txtCName01.Text = _ShoeSettings.ChildName01;
            txtCSize01.Text = _ShoeSettings.ChildSize01;
            txtCName02.Text = _ShoeSettings.ChildName02;
            txtCSize02.Text = _ShoeSettings.ChildSize02;
            txtCName03.Text = _ShoeSettings.ChildName03;
            txtCSize03.Text = _ShoeSettings.ChildSize03;
            txtCName04.Text = _ShoeSettings.ChildName04;
            txtCSize04.Text = _ShoeSettings.ChildSize04;
            txtCName05.Text = _ShoeSettings.ChildName05;
            txtCSize05.Text = _ShoeSettings.ChildSize05;
        }
        #endregion
        #region save methods
        private void SaveAll()
        {
            SaveWomenShoes();
            SaveMenShoes();
            SaveChildShoes();
        }
        private void SaveWomenShoes()
        {
            _ShoeSettings.WomenName01 = txtWName01.Text;
            _ShoeSettings.WomenSize01 = txtWSize01.Text;
            _ShoeSettings.WomenName02 = txtWName02.Text;
            _ShoeSettings.WomenSize02 = txtWSize02.Text;
            _ShoeSettings.WomenName03 = txtWName03.Text;
            _ShoeSettings.WomenSize03 = txtWSize03.Text;
            _ShoeSettings.WomenName04 = txtWName04.Text;
            _ShoeSettings.WomenSize04 = txtWSize04.Text;
            _ShoeSettings.WomenName05 = txtWName05.Text;
            _ShoeSettings.WomenSize05 = txtWSize05.Text;
        }
        private void SaveMenShoes()
        {
            _ShoeSettings.MenName01 = txtMName01.Text;
            _ShoeSettings.MenSize01 = txtMSize01.Text;
            _ShoeSettings.MenName02 = txtMName02.Text;
            _ShoeSettings.MenSize02 = txtMSize02.Text;
            _ShoeSettings.MenName03 = txtMName03.Text;
            _ShoeSettings.MenSize03 = txtMSize03.Text;
            _ShoeSettings.MenName04 = txtMName04.Text;
            _ShoeSettings.MenSize04 = txtMSize04.Text;
            _ShoeSettings.MenName05 = txtMName05.Text;
            _ShoeSettings.MenSize05 = txtMSize05.Text;
        }
        private void SaveChildShoes()
        {
            _ShoeSettings.ChildName01 = txtCName01.Text;
            _ShoeSettings.ChildSize01 = txtCSize01.Text;
            _ShoeSettings.ChildName02 = txtCName02.Text;
            _ShoeSettings.ChildSize02 = txtCSize02.Text;
            _ShoeSettings.ChildName03 = txtCName03.Text;
            _ShoeSettings.ChildSize03 = txtCSize03.Text;
            _ShoeSettings.ChildName04 = txtCName04.Text;
            _ShoeSettings.ChildSize04 = txtCSize04.Text;
            _ShoeSettings.ChildName05 = txtCName05.Text;
            _ShoeSettings.ChildSize05 = txtCSize05.Text;
        }
        #endregion
        #region navigation methods
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
            _DeleteButtonVisible = true;
            _SaveButtonVisible = false;
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            ApplicationBar.Buttons.Remove(appBarButtonHome);
            //create a new button. delete
            appBarButtonDelete = new ApplicationBarIconButton(new Uri("/Assets/AppBar/delete.png", UriKind.Relative));
            appBarButtonDelete.Text = "delete";
            ApplicationBar.Buttons.Add(appBarButtonDelete);
            appBarButtonDelete.Click += appBarButtonDelete_Click;
        }
        private void BuildLocalizedApplicationBarSave()
        {
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonHome);
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            if (!_SaveButtonVisible)
            {
                //Create a new button. Save.
                appBarButtonSave = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
                appBarButtonSave.Text = "save";
                ApplicationBar.Buttons.Add(appBarButtonSave);
                appBarButtonSave.Click += appBarButtonSave_Click;
            }

            _SaveButtonVisible = true;

        }

        void appBarButtonSave_Click(object sender, EventArgs e)
        {
            SaveAll();
            HideCheckBoxes();
            MakeReadOnly();
            BuildLocalizedAppBarReadOnly();
            this.Focus();
        }

        void appBarButtonDelete_Click(object sender, EventArgs e)
        {
            //delete the ones that are checked
            ClearAll();
            //hide the checkboxes
            HideCheckBoxes();
            MakeReadOnly();
            SaveAll();
            //reset the navigation bar
            BuildLocalizedAppBarReadOnly();

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
        private void appBarButtonEdit_Click(object sender, EventArgs e)
        {
            BuildLocalizedApplicationBarSave();
            ShowCheckBoxes();
            MakeEditable();
        }
        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            ApplicationBar.Buttons.Remove(appBarButtonDelete);
            ApplicationBar.Buttons.Remove(appBarButtonSave);
            ApplicationBar.Buttons.Remove(appBarButtonHome);

            HideCheckBoxes();
            MakeReadOnly();
            BuildLocalizedAppBarReadOnly();
        }
        private void checkBoxAction_Checked(object sender, RoutedEventArgs e)
        {
            ApplicationBar.Buttons.Remove(appBarButtonSave);

            if (cbxMSave01.IsChecked == true || cbxMSave02.IsChecked == true ||
                cbxMSave03.IsChecked == true || cbxMSave04.IsChecked == true || cbxMSave05.IsChecked == true)
            {
                if (!_DeleteButtonVisible)
                {
                    BuildLocalizedApplicationBarDelete();
                }
            }
            if (cbxWSave01.IsChecked == true || cbxWSave02.IsChecked == true ||
                cbxWSave03.IsChecked == true || cbxWSave04.IsChecked == true || cbxWSave05.IsChecked == true)
            {
                if (!_DeleteButtonVisible)
                {
                    BuildLocalizedApplicationBarDelete();
                }
            }
            if (cbxCSave01.IsChecked == true || cbxCSave02.IsChecked == true ||
                cbxCSave03.IsChecked == true || cbxCSave04.IsChecked == true || cbxCSave05.IsChecked == true)
            {
                if (!_DeleteButtonVisible)
                {
                    BuildLocalizedApplicationBarDelete();
                }
            }
        }
        private void checkBoxAction_UnChecked(object sender, RoutedEventArgs e)
        {

            if (cbxMSave01.IsChecked == false && cbxMSave02.IsChecked == false &&
                cbxMSave03.IsChecked == false && cbxMSave04.IsChecked == false && cbxMSave05.IsChecked == false)
            {
                _DeleteButtonVisible = false;
                ApplicationBar.Buttons.Remove(appBarButtonDelete);
                HideCheckBoxes();
                BuildLocalizedApplicationBarSave();
            }
            if (cbxWSave01.IsChecked == false && cbxWSave02.IsChecked == false &&
                cbxWSave03.IsChecked == false && cbxWSave04.IsChecked == false && cbxWSave05.IsChecked == false)
            {
                _DeleteButtonVisible = false;
                ApplicationBar.Buttons.Remove(appBarButtonDelete);
                HideCheckBoxes();
                BuildLocalizedApplicationBarSave();
            }
            if (cbxCSave01.IsChecked == false && cbxCSave02.IsChecked == false &&
                cbxCSave03.IsChecked == false && cbxCSave04.IsChecked == false && cbxCSave05.IsChecked == false)
            {
                _DeleteButtonVisible = false;
                ApplicationBar.Buttons.Remove(appBarButtonDelete);
                HideCheckBoxes();
                BuildLocalizedApplicationBarSave();
            }
        }
        #endregion
    }
}