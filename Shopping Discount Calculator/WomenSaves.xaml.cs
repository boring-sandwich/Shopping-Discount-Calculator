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
    public partial class WomenSaves : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private WomenSettings _Settings = new WomenSettings();
        
        private bool _DeleteButtonVisible = false;
        private bool _SaveButtonVisible = false;

        ApplicationBarIconButton appBarButtonEdit;
        ApplicationBarIconButton appBarButtonHome;
        ApplicationBarIconButton appBarButtonDelete;
        ApplicationBarIconButton appBarButtonSave;

        public WomenSaves()
        {
            InitializeComponent();
            _IsInitialized = true;

            ApplicationBar = new ApplicationBar();
            BuildLocalizedAppBarReadOnly();
            BuildLocalizedApplicationBarShared();
            HideCheckBoxes();
            RestoreAll();
        }
        #region protected Events       
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

        #region restore methods
        private void RestoreAll()
            {
		        Restore01();
                Restore02();
                Restore03();
                Restore04();
                Restore05();
            }
            private void Restore01()
            {
                txtSave01Name.Text = _Settings.Name01;
                txtSave01Size.Text = _Settings.Size01;
                txtSave01Bust.Text = _Settings.Bust01;
                txtSave01Waist.Text = _Settings.Waist01;
                txtSave01Hip.Text = _Settings.Hip01;
            }
            private void Restore02()
            {
                txtSave02Name.Text = _Settings.Name02;
                txtSave02Size.Text = _Settings.Size02;
                txtSave02Bust.Text = _Settings.Bust02;
                txtSave02Waist.Text = _Settings.Waist02;
                txtSave02Hip.Text = _Settings.Hip02;
            }
            private void Restore03()
            {
                txtSave03Name.Text = _Settings.Name03;
                txtSave03Size.Text = _Settings.Size03;
                txtSave03Bust.Text = _Settings.Bust03;
                txtSave03Waist.Text = _Settings.Waist03;
                txtSave03Hip.Text = _Settings.Hip03;
            }
            private void Restore04()
            {
                txtSave04Name.Text = _Settings.Name04;
                txtSave04Size.Text = _Settings.Size04;
                txtSave04Bust.Text = _Settings.Bust04;
                txtSave04Waist.Text = _Settings.Waist04;
                txtSave04Hip.Text = _Settings.Hip04;
            }
            private void Restore05()
            {
                txtSave05Name.Text = _Settings.Name05;
                txtSave05Size.Text = _Settings.Size05;
                txtSave05Bust.Text = _Settings.Bust05;
                txtSave05Waist.Text = _Settings.Waist05;
                txtSave05Hip.Text = _Settings.Hip05;
            }
    #endregion
        #region save methods
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
            _Settings.Name01 = txtSave01Name.Text;
            _Settings.Size01 = txtSave01Size.Text;
            _Settings.Bust01 = txtSave01Bust.Text;
            _Settings.Waist01 = txtSave01Waist.Text;
            _Settings.Hip01 = txtSave01Hip.Text;
        }
        private void Save02()
        {
            _Settings.Name02 = txtSave02Name.Text;
            _Settings.Size02 = txtSave02Size.Text;
            _Settings.Bust02 = txtSave02Bust.Text;
            _Settings.Waist02 = txtSave02Waist.Text;
            _Settings.Hip02 = txtSave02Hip.Text;
        }
        private void Save03()
        {
            _Settings.Name03 = txtSave03Name.Text;
            _Settings.Size03 = txtSave03Size.Text;
            _Settings.Bust03 = txtSave03Bust.Text;
            _Settings.Waist03 = txtSave03Waist.Text;
            _Settings.Hip03 = txtSave03Hip.Text;
        }
        private void Save04()
        {
            _Settings.Name04 = txtSave04Name.Text;
            _Settings.Size04 = txtSave04Size.Text;
            _Settings.Bust04 = txtSave04Bust.Text;
            _Settings.Waist04 = txtSave04Waist.Text;
            _Settings.Hip04 = txtSave04Hip.Text;
        }
        private void Save05()
        {
            _Settings.Name05 = txtSave05Name.Text;
            _Settings.Size05 = txtSave05Size.Text;
            _Settings.Bust05 = txtSave05Bust.Text;
            _Settings.Waist05 = txtSave05Waist.Text;
            _Settings.Hip05 = txtSave05Hip.Text;
        }
        #endregion
        #region Editable textboxes
        private void MakeEditable()
        {
            MakeTextBox01Editable();
            MakeTextBox02Editable();
            MakeTextBox03Editable();
            MakeTextBox04Editable();
            MakeTextBox05Editable();
        }
        private void MakeTextBox01Editable()
        {
            txtSave01Name.IsReadOnly = false;
            txtSave01Size.IsReadOnly = false;
            txtSave01Bust.IsReadOnly = false;
            txtSave01Waist.IsReadOnly = false;
            txtSave01Hip.IsReadOnly = false;

            txtSave01Name.IsEnabled = true;
            txtSave01Size.IsEnabled = true;
            txtSave01Bust.IsEnabled = true;
            txtSave01Waist.IsEnabled = true;
            txtSave01Hip.IsEnabled = true;

        }
        private void MakeTextBox02Editable()
        {
            txtSave02Name.IsReadOnly = false;
            txtSave02Size.IsReadOnly = false;
            txtSave02Bust.IsReadOnly = false;
            txtSave02Waist.IsReadOnly = false;
            txtSave02Hip.IsReadOnly = false;

            txtSave02Name.IsEnabled = true;
            txtSave02Size.IsEnabled = true;
            txtSave02Bust.IsEnabled = true;
            txtSave02Waist.IsEnabled = true;
            txtSave02Hip.IsEnabled = true;

        }
        private void MakeTextBox03Editable()
        {
            txtSave03Name.IsReadOnly = false;
            txtSave03Size.IsReadOnly = false;
            txtSave03Bust.IsReadOnly = false;
            txtSave03Waist.IsReadOnly = false;
            txtSave03Hip.IsReadOnly = false;

            txtSave03Name.IsEnabled = true;
            txtSave03Size.IsEnabled = true;
            txtSave03Bust.IsEnabled = true;
            txtSave03Waist.IsEnabled = true;
            txtSave03Hip.IsEnabled = true;

        }
        private void MakeTextBox04Editable()
        {
            txtSave04Name.IsReadOnly = false;
            txtSave04Size.IsReadOnly = false;
            txtSave04Bust.IsReadOnly = false;
            txtSave04Waist.IsReadOnly = false;
            txtSave04Hip.IsReadOnly = false;

            txtSave04Name.IsEnabled = true;
            txtSave04Size.IsEnabled = true;
            txtSave04Bust.IsEnabled = true;
            txtSave04Waist.IsEnabled = true;
            txtSave04Hip.IsEnabled = true;

        }
        private void MakeTextBox05Editable()
        {
            txtSave05Name.IsReadOnly = false;
            txtSave05Size.IsReadOnly = false;
            txtSave05Bust.IsReadOnly = false;
            txtSave05Waist.IsReadOnly = false;
            txtSave05Hip.IsReadOnly = false;

            txtSave05Name.IsEnabled = true;
            txtSave05Size.IsEnabled = true;
            txtSave05Bust.IsEnabled = true;
            txtSave05Waist.IsEnabled = true;
            txtSave05Hip.IsEnabled = true;

        }
        #endregion
        #region Readonly Textboxes
        private void MakeReadOnly()
        {
            MakeTextBox01ReadOnly();
            MakeTextBox02ReadOnly();
            MakeTextBox03ReadOnly();
            MakeTextBox04ReadOnly();
            MakeTextBox05ReadOnly();
        }
        private void MakeTextBox01ReadOnly()
        {
            txtSave01Name.IsReadOnly = true;
            txtSave01Size.IsReadOnly = true;
            txtSave01Bust.IsReadOnly = true;
            txtSave01Waist.IsReadOnly = true;
            txtSave01Hip.IsReadOnly = true;

            txtSave01Name.IsEnabled = false;
            txtSave01Size.IsEnabled = false;
            txtSave01Bust.IsEnabled = false;
            txtSave01Waist.IsEnabled = false;
            txtSave01Hip.IsEnabled = false;

        }
        private void MakeTextBox02ReadOnly()
        {
            txtSave02Name.IsReadOnly = true;
            txtSave02Size.IsReadOnly = true;
            txtSave02Bust.IsReadOnly = true;
            txtSave02Waist.IsReadOnly = true;
            txtSave02Hip.IsReadOnly = true;

            txtSave02Name.IsEnabled = false;
            txtSave02Size.IsEnabled = false;
            txtSave02Bust.IsEnabled = false;
            txtSave02Waist.IsEnabled = false;
            txtSave02Hip.IsEnabled = false;

        }
        private void MakeTextBox03ReadOnly()
        {
            txtSave03Name.IsReadOnly = true;
            txtSave03Size.IsReadOnly = true;
            txtSave03Bust.IsReadOnly = true;
            txtSave03Waist.IsReadOnly = true;
            txtSave03Hip.IsReadOnly = true;

            txtSave03Name.IsEnabled = false;
            txtSave03Size.IsEnabled = false;
            txtSave03Bust.IsEnabled = false;
            txtSave03Waist.IsEnabled = false;
            txtSave03Hip.IsEnabled = false;

        }
        private void MakeTextBox04ReadOnly()
        {
            txtSave04Name.IsReadOnly = true;
            txtSave04Size.IsReadOnly = true;
            txtSave04Bust.IsReadOnly = true;
            txtSave04Waist.IsReadOnly = true;
            txtSave04Hip.IsReadOnly = true;

            txtSave04Name.IsEnabled = false;
            txtSave04Size.IsEnabled = false;
            txtSave04Bust.IsEnabled = false;
            txtSave04Waist.IsEnabled = false;
            txtSave04Hip.IsEnabled = false;

        }
        private void MakeTextBox05ReadOnly()
        {
            txtSave05Name.IsReadOnly = true;
            txtSave05Size.IsReadOnly = true;
            txtSave05Bust.IsReadOnly = true;
            txtSave05Waist.IsReadOnly = true;
            txtSave05Hip.IsReadOnly = true;

            txtSave05Name.IsEnabled = false;
            txtSave05Size.IsEnabled = false;
            txtSave05Bust.IsEnabled = false;
            txtSave05Waist.IsEnabled = false;
            txtSave05Hip.IsEnabled = false;
        }
        #endregion
        #region Show Checkboxes
        private void ShowCheckBoxes()
        {
            cbxSave01.Visibility = System.Windows.Visibility.Visible;
            cbxSave02.Visibility = System.Windows.Visibility.Visible;
            cbxSave03.Visibility = System.Windows.Visibility.Visible;
            cbxSave04.Visibility = System.Windows.Visibility.Visible;
            cbxSave05.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion
        #region Hide Checkboxes
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
        #endregion
        #region clear methods
        private void Clear01()
        {
            if (cbxSave01.IsChecked == true)
            {
            txtSave01Name.Text = "default name 01";
            txtSave01Size.Text = "default size 01";
            txtSave01Bust.Text = "00";
            txtSave01Waist.Text = "00";
            txtSave01Hip.Text = "00";   
            }          
        }
        private void Clear02()
        {
            if (cbxSave02.IsChecked == true)
            {
             txtSave02Name.Text = "default name 02";
            txtSave02Size.Text = "default size 02";
            txtSave02Bust.Text = "00";
            txtSave02Waist.Text = "00";
            txtSave02Hip.Text = "00";   
            }       
        }
        private void Clear03()
        {
            if (cbxSave03.IsChecked == true)
            {
                txtSave03Name.Text = "default name 03";
                txtSave03Size.Text = "default size 03";
                txtSave03Bust.Text = "00";
                txtSave03Waist.Text = "00";
                txtSave03Hip.Text = "00";
            }           
        }
        private void Clear04()
        {
            if (cbxSave04.IsChecked == true)
            {
             txtSave04Name.Text = "default name 04";
            txtSave04Size.Text = "default size 04";
            txtSave04Bust.Text = "00";
            txtSave04Waist.Text = "00";
            txtSave04Hip.Text = "00";   
            }   
        }
        private void Clear05()
        {
            if (cbxSave05.IsChecked == true)
            {
                txtSave05Name.Text = "default name 05";
                txtSave05Size.Text = "default size 05";
                txtSave05Bust.Text = "00";
                txtSave05Waist.Text = "00";
                txtSave05Hip.Text = "00"; 
            }
        }
        #endregion
        #region Key events
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void MoveDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == txtSave01Name || sender == txtSave01Size ||
                sender == txtSave01Bust || sender == txtSave01Waist ||
                sender == txtSave01Hip)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtSave01Name)
                    {
                        txtSave01Size.Focus();
                    }
                    else if (sender == txtSave01Size)
                    {
                        txtSave01Bust.Focus();
                    }
                    else if (sender == txtSave01Bust)
                    {
                        txtSave01Waist.Focus();
                    }
                    else if (sender == txtSave01Waist)
                    {
                        txtSave01Hip.Focus();
                    }
                    else if (sender == txtSave01Hip)
                    {
                        txtSave01Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtSave02Name || sender == txtSave02Size ||
                    sender == txtSave02Bust || sender == txtSave02Waist ||
                    sender == txtSave02Hip)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtSave02Name)
                    {
                        txtSave02Size.Focus();
                    }
                    else if (sender == txtSave02Size)
                    {
                        txtSave02Bust.Focus();
                    }
                    else if (sender == txtSave02Bust)
                    {
                        txtSave02Waist.Focus();
                    }
                    else if (sender == txtSave02Waist)
                    {
                        txtSave02Hip.Focus();
                    }
                    else if (sender == txtSave02Hip)
                    {
                        txtSave02Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtSave03Name || sender == txtSave03Size ||
                    sender == txtSave03Bust || sender == txtSave03Waist ||
                    sender == txtSave03Hip)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtSave03Name)
                    {
                        txtSave03Size.Focus();
                    }
                    else if (sender == txtSave03Size)
                    {
                        txtSave03Bust.Focus();
                    }
                    else if (sender == txtSave03Bust)
                    {
                        txtSave03Waist.Focus();
                    }
                    else if (sender == txtSave03Waist)
                    {
                        txtSave03Hip.Focus();
                    }
                    else if (sender == txtSave03Hip)
                    {
                        txtSave03Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtSave04Name || sender == txtSave04Size ||
                    sender == txtSave04Bust || sender == txtSave04Waist ||
                    sender == txtSave04Hip)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtSave04Name)
                    {
                        txtSave04Size.Focus();
                    }
                    else if (sender == txtSave04Size)
                    {
                        txtSave04Bust.Focus();
                    }
                    else if (sender == txtSave04Bust)
                    {
                        txtSave04Waist.Focus();
                    }
                    else if (sender == txtSave04Waist)
                    {
                        txtSave04Hip.Focus();
                    }
                    else if (sender == txtSave04Hip)
                    {
                        txtSave05Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtSave05Name || sender == txtSave05Size ||
                    sender == txtSave05Bust || sender == txtSave05Waist ||
                    sender == txtSave05Hip)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtSave05Name)
                    {
                        txtSave05Size.Focus();
                    }
                    else if (sender == txtSave05Size)
                    {
                        txtSave05Bust.Focus();
                    }
                    else if (sender == txtSave05Bust)
                    {
                        txtSave05Waist.Focus();
                    }
                    else if (sender == txtSave05Waist)
                    {
                        txtSave05Hip.Focus();
                    }
                    else if (sender == txtSave05Hip)
                    {
                        txtSave05Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }

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
            //create a new button. delete
            appBarButtonSave = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButtonSave.Text = "delete";
            ApplicationBar.Buttons.Add(appBarButtonSave);
            appBarButtonSave.Click += appBarButtonSave_Click;
        }

        private void appBarButtonSave_Click(object sender, EventArgs e)
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
            if (cbxSave01.IsChecked == true)
            {
                Clear01();
            }
            if (cbxSave02.IsChecked == true)
            {
                Clear02();
            }
            if (cbxSave03.IsChecked == true)
            {
                Clear03();
            }
            if (cbxSave04.IsChecked == true)
            {
                Clear04();
            }
            if (cbxSave05.IsChecked == true)
            {
                Clear05();
            }
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
        private void checkBoxAction_Checked(object sender, RoutedEventArgs e)
        {
            ApplicationBar.Buttons.Remove(appBarButtonSave);

            if (cbxSave01.IsChecked == true || cbxSave02.IsChecked == true ||
                cbxSave03.IsChecked == true || cbxSave04.IsChecked == true || cbxSave05.IsChecked == true)
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
                BuildLocalizedApplicationBarSave();
                HideCheckBoxes();
            }
        }
        #endregion
    }
}