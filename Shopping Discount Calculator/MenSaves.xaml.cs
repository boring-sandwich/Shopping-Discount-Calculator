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
    public partial class MenSaves : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private MenSettings _Settings = new MenSettings();
        private bool _DeleteButtonVisible = false;
        private bool _SaveButtonVisible = false;

        ApplicationBarIconButton appBarButtonEdit;
        ApplicationBarIconButton appBarButtonHome;
        ApplicationBarIconButton appBarButtonDelete;
        ApplicationBarIconButton appBarButtonSave;

        public MenSaves()
        {
            InitializeComponent();
            _IsInitialized = true;

            ApplicationBar = new ApplicationBar();
            BuildLocalizedAppBarReadOnly();
            BuildLocalizedApplicationBarShared();
            HideCheckBoxes();
            RestoreAll();

        }
        #region Protected Events     
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string strItemIndiex;
            if (NavigationContext.QueryString.TryGetValue("goto", out strItemIndiex))
            {
                MyPivot.SelectedIndex = Convert.ToInt32(strItemIndiex);
            }
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
            txtMSave01Name.Text = _Settings.MName01;
            txtMSave01Size.Text = _Settings.MSize01;
            txtMSave01Chest.Text = _Settings.MChest01;
            txtMSave01Waist.Text = _Settings.MWaist1;
            txtMSave01Hip.Text = _Settings.MHip1;
            txtMSave01Shoulder.Text = _Settings.MShoulder1;
            txtMSave01Sleeve.Text = _Settings.MSleeve1;
            txtMSave01Neck.Text = _Settings.MNeck1;
        }
        private void Restore02()
        {
            txtMSave02Name.Text = _Settings.Name02;
            txtMSave02Size.Text = _Settings.Size02;
            txtMSave02Chest.Text = _Settings.Chest02;
            txtMSave02Waist.Text = _Settings.Waist2;
            txtMSave02Hip.Text = _Settings.Hip2;
            txtMSave02Shoulder.Text = _Settings.Shoulder2;
            txtMSave02Sleeve.Text = _Settings.Sleeve2;
            txtMSave02Neck.Text = _Settings.Neck2;
        }
        private void Restore03()
        {
            txtMSave03Name.Text = _Settings.Name03;
            txtMSave03Size.Text = _Settings.Size03;
            txtMSave03Chest.Text = _Settings.Chest03;
            txtMSave03Waist.Text = _Settings.Waist3;
            txtMSave03Hip.Text = _Settings.Hip3;
            txtMSave03Shoulder.Text = _Settings.Shoulder3;
            txtMSave03Sleeve.Text = _Settings.Sleeve3;
            txtMSave03Neck.Text = _Settings.Neck3;
        }
        private void Restore04()
        {
            txtMSave04Name.Text = _Settings.Name04;
            txtMSave04Size.Text = _Settings.Size04;
            txtMSave04Chest.Text = _Settings.Chest04;
            txtMSave04Waist.Text = _Settings.Waist4;
            txtMSave04Hip.Text = _Settings.Hip4;
            txtMSave04Shoulder.Text = _Settings.Shoulder4;
            txtMSave04Sleeve.Text = _Settings.Sleeve4;
            txtMSave04Neck.Text = _Settings.Neck4;
        }
        private void Restore05()
        {
            txtMSave05Name.Text = _Settings.Name05;
            txtMSave05Size.Text = _Settings.Size05;
            txtMSave05Chest.Text = _Settings.Chest05;
            txtMSave05Waist.Text = _Settings.Waist5;
            txtMSave05Hip.Text = _Settings.Hip5;
            txtMSave05Shoulder.Text = _Settings.Shoulder5;
            txtMSave05Sleeve.Text = _Settings.Sleeve5;
            txtMSave05Neck.Text = _Settings.Neck5;
        }
        #endregion
        #region Editable textboxes
        private void MakeAllTextBoxesEditable()
        {
            MakeTextBox01Editable();
            MakeTextBox02Editable();
            MakeTextBox03Editable();
            MakeTextBox04Editable();
            MakeTextBox05Editable();
        }
        private void MakeTextBox01Editable()
        {
            txtMSave01Name.IsReadOnly = false;
            txtMSave01Size.IsReadOnly = false;
            txtMSave01Chest.IsReadOnly = false;
            txtMSave01Shoulder.IsReadOnly = false;
            txtMSave01Waist.IsReadOnly = false;
            txtMSave01Inseem.IsReadOnly = false;
            txtMSave01Hip.IsReadOnly = false;
            txtMSave01Sleeve.IsReadOnly = false;
            txtMSave01Neck.IsReadOnly = false;

            txtMSave01Name.IsEnabled = true;
            txtMSave01Size.IsEnabled = true;
            txtMSave01Chest.IsEnabled = true;
            txtMSave01Shoulder.IsEnabled = true;
            txtMSave01Waist.IsEnabled = true;
            txtMSave01Inseem.IsEnabled = true;
            txtMSave01Hip.IsEnabled = true;
            txtMSave01Sleeve.IsEnabled = true;
            txtMSave01Neck.IsEnabled = true;
        }
        private void MakeTextBox02Editable()
        {
            txtMSave02Name.IsReadOnly = false;
            txtMSave02Size.IsReadOnly = false;
            txtMSave02Chest.IsReadOnly = false;
            txtMSave02Shoulder.IsReadOnly = false;
            txtMSave02Waist.IsReadOnly = false;
            txtMSave02Inseem.IsReadOnly = false;
            txtMSave02Hip.IsReadOnly = false;
            txtMSave02Sleeve.IsReadOnly = false;
            txtMSave02Neck.IsReadOnly = false;

            txtMSave02Name.IsEnabled = true;
            txtMSave02Size.IsEnabled = true;
            txtMSave02Chest.IsEnabled = true;
            txtMSave02Shoulder.IsEnabled = true;
            txtMSave02Waist.IsEnabled = true;
            txtMSave02Inseem.IsEnabled = true;
            txtMSave02Hip.IsEnabled = true;
            txtMSave02Sleeve.IsEnabled = true;
            txtMSave02Neck.IsEnabled = true;

        }
        private void MakeTextBox03Editable()
        {
            txtMSave03Name.IsReadOnly = false;
            txtMSave03Size.IsReadOnly = false;
            txtMSave03Chest.IsReadOnly = false;
            txtMSave03Shoulder.IsReadOnly = false;
            txtMSave03Waist.IsReadOnly = false;
            txtMSave03Inseem.IsReadOnly = false;
            txtMSave03Hip.IsReadOnly = false;
            txtMSave03Sleeve.IsReadOnly = false;
            txtMSave03Neck.IsReadOnly = false;

            txtMSave03Name.IsEnabled = true;
            txtMSave03Size.IsEnabled = true;
            txtMSave03Chest.IsEnabled = true;
            txtMSave03Shoulder.IsEnabled = true;
            txtMSave03Waist.IsEnabled = true;
            txtMSave03Inseem.IsEnabled = true;
            txtMSave03Hip.IsEnabled = true;
            txtMSave03Sleeve.IsEnabled = true;
            txtMSave03Neck.IsEnabled = true;

        }
        private void MakeTextBox04Editable()
        {
            txtMSave04Name.IsReadOnly = false;
            txtMSave04Size.IsReadOnly = false;
            txtMSave04Chest.IsReadOnly = false;
            txtMSave04Shoulder.IsReadOnly = false;
            txtMSave04Waist.IsReadOnly = false;
            txtMSave04Inseem.IsReadOnly = false;
            txtMSave04Hip.IsReadOnly = false;
            txtMSave04Sleeve.IsReadOnly = false;
            txtMSave04Neck.IsReadOnly = false;

            txtMSave04Name.IsEnabled = true;
            txtMSave04Size.IsEnabled = true;
            txtMSave04Chest.IsEnabled = true;
            txtMSave04Shoulder.IsEnabled = true;
            txtMSave04Waist.IsEnabled = true;
            txtMSave04Inseem.IsEnabled = true;
            txtMSave04Hip.IsEnabled = true;
            txtMSave04Sleeve.IsEnabled = true;
            txtMSave04Neck.IsEnabled = true;

        }
        private void MakeTextBox05Editable()
        {
            txtMSave05Name.IsReadOnly = false;
            txtMSave05Size.IsReadOnly = false;
            txtMSave05Chest.IsReadOnly = false;
            txtMSave05Shoulder.IsReadOnly = false;
            txtMSave05Waist.IsReadOnly = false;
            txtMSave05Inseem.IsReadOnly = false;
            txtMSave05Hip.IsReadOnly = false;
            txtMSave05Sleeve.IsReadOnly = false;
            txtMSave05Neck.IsReadOnly = false;

            txtMSave05Name.IsEnabled = true;
            txtMSave05Size.IsEnabled = true;
            txtMSave05Chest.IsEnabled = true;
            txtMSave05Shoulder.IsEnabled = true;
            txtMSave05Waist.IsEnabled = true;
            txtMSave05Inseem.IsEnabled = true;
            txtMSave05Hip.IsEnabled = true;
            txtMSave05Sleeve.IsEnabled = true;
            txtMSave05Neck.IsEnabled = true;

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
            _Settings.MName01 = txtMSave01Name.Text;
            _Settings.MSize01 = txtMSave01Size.Text;
            _Settings.MChest01 = txtMSave01Chest.Text;
            _Settings.MShoulder1 = txtMSave01Shoulder.Text;
            _Settings.MWaist1 = txtMSave01Waist.Text;
            _Settings.MInseem1 = txtMSave01Inseem.Text;
            _Settings.MHip1 = txtMSave01Hip.Text;
            _Settings.MSleeve1 = txtMSave01Sleeve.Text;
            _Settings.MNeck1 = txtMSave01Neck.Text;
        }
        private void Save02()
        {
            _Settings.Name02 = txtMSave02Name.Text;
            _Settings.Size02 = txtMSave02Size.Text;
            _Settings.Chest02 = txtMSave02Chest.Text;
            _Settings.Shoulder2 = txtMSave02Shoulder.Text;
            _Settings.Waist2 = txtMSave02Waist.Text;
            _Settings.Inseem2 = txtMSave02Inseem.Text;
            _Settings.Hip2 = txtMSave02Hip.Text;
            _Settings.Sleeve2 = txtMSave02Sleeve.Text;
            _Settings.Neck2 = txtMSave02Neck.Text;
        }
        private void Save03()
        {
            _Settings.Name03 = txtMSave03Name.Text;
            _Settings.Size03 = txtMSave03Size.Text;
            _Settings.Chest03 = txtMSave03Chest.Text;
            _Settings.Shoulder3 = txtMSave03Shoulder.Text;
            _Settings.Waist3 = txtMSave03Waist.Text;
            _Settings.Inseem3 = txtMSave03Inseem.Text;
            _Settings.Hip3 = txtMSave03Hip.Text;
            _Settings.Sleeve3 = txtMSave03Sleeve.Text;
            _Settings.Neck3 = txtMSave03Neck.Text;
        }
        private void Save04()
        {
            _Settings.Name04 = txtMSave04Name.Text;
            _Settings.Size04 = txtMSave04Size.Text;
            _Settings.Chest04 = txtMSave04Chest.Text;
            _Settings.Shoulder4 = txtMSave04Shoulder.Text;
            _Settings.Waist4 = txtMSave04Waist.Text;
            _Settings.Inseem4 = txtMSave04Inseem.Text;
            _Settings.Hip4 = txtMSave04Hip.Text;
            _Settings.Sleeve4 = txtMSave04Sleeve.Text;
            _Settings.Neck4 = txtMSave04Neck.Text;
        }
        private void Save05()
        {
            _Settings.Name05 = txtMSave05Name.Text;
            _Settings.Size05 = txtMSave05Size.Text;
            _Settings.Chest05 = txtMSave05Chest.Text;
            _Settings.Shoulder5 = txtMSave05Shoulder.Text;
            _Settings.Waist5 = txtMSave05Waist.Text;
            _Settings.Inseem5 = txtMSave05Inseem.Text;
            _Settings.Hip5 = txtMSave05Hip.Text;
            _Settings.Sleeve5 = txtMSave05Sleeve.Text;
            _Settings.Neck5 = txtMSave05Neck.Text;
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
            txtMSave01Name.IsReadOnly = true;
            txtMSave01Size.IsReadOnly = true;
            txtMSave01Chest.IsReadOnly = true;
            txtMSave01Shoulder.IsReadOnly = true;
            txtMSave01Waist.IsReadOnly = true;
            txtMSave01Inseem.IsReadOnly = true;
            txtMSave01Hip.IsReadOnly = true;
            txtMSave01Sleeve.IsReadOnly = true;
            txtMSave01Neck.IsReadOnly = true;

            txtMSave01Name.IsEnabled = false;
            txtMSave01Size.IsEnabled = false;
            txtMSave01Chest.IsEnabled = false;
            txtMSave01Shoulder.IsEnabled = false;
            txtMSave01Waist.IsEnabled = false;
            txtMSave01Inseem.IsEnabled = false;
            txtMSave01Hip.IsEnabled = false;
            txtMSave01Sleeve.IsEnabled = false;
            txtMSave01Neck.IsEnabled = false;

        }
        private void MakeTextBox02ReadOnly()
        {
            txtMSave02Name.IsReadOnly = true;
            txtMSave02Size.IsReadOnly = true;
            txtMSave02Chest.IsReadOnly = true;
            txtMSave02Shoulder.IsReadOnly = true;
            txtMSave02Waist.IsReadOnly = true;
            txtMSave02Inseem.IsReadOnly = true;
            txtMSave02Hip.IsReadOnly = true;
            txtMSave02Sleeve.IsReadOnly = true;
            txtMSave02Neck.IsReadOnly = true;

            txtMSave02Name.IsEnabled = false;
            txtMSave02Size.IsEnabled = false;
            txtMSave02Chest.IsEnabled = false;
            txtMSave02Shoulder.IsEnabled = false;
            txtMSave02Waist.IsEnabled = false;
            txtMSave02Inseem.IsEnabled = false;
            txtMSave02Hip.IsEnabled = false;
            txtMSave02Sleeve.IsEnabled = false;
            txtMSave02Neck.IsEnabled = false;

        }
        private void MakeTextBox03ReadOnly()
        {
            txtMSave03Name.IsReadOnly = true;
            txtMSave03Size.IsReadOnly = true;
            txtMSave03Chest.IsReadOnly = true;
            txtMSave03Shoulder.IsReadOnly = true;
            txtMSave03Waist.IsReadOnly = true;
            txtMSave03Inseem.IsReadOnly = true;
            txtMSave03Hip.IsReadOnly = true;
            txtMSave03Sleeve.IsReadOnly = true;
            txtMSave03Neck.IsReadOnly = true;

            txtMSave03Name.IsEnabled = false;
            txtMSave03Size.IsEnabled = false;
            txtMSave03Chest.IsEnabled = false;
            txtMSave03Shoulder.IsEnabled = false;
            txtMSave03Waist.IsEnabled = false;
            txtMSave03Inseem.IsEnabled = false;
            txtMSave03Hip.IsEnabled = false;
            txtMSave03Sleeve.IsEnabled = false;
            txtMSave03Neck.IsEnabled = false;

        }
        private void MakeTextBox04ReadOnly()
        {
            txtMSave04Name.IsReadOnly = true;
            txtMSave04Size.IsReadOnly = true;
            txtMSave04Chest.IsReadOnly = true;
            txtMSave04Shoulder.IsReadOnly = true;
            txtMSave04Waist.IsReadOnly = true;
            txtMSave04Inseem.IsReadOnly = true;
            txtMSave04Hip.IsReadOnly = true;
            txtMSave04Sleeve.IsReadOnly = true;
            txtMSave04Neck.IsReadOnly = true;

            txtMSave04Name.IsEnabled = false;
            txtMSave04Size.IsEnabled = false;
            txtMSave04Chest.IsEnabled = false;
            txtMSave04Shoulder.IsEnabled = false;
            txtMSave04Waist.IsEnabled = false;
            txtMSave04Inseem.IsEnabled = false;
            txtMSave04Hip.IsEnabled = false;
            txtMSave04Sleeve.IsEnabled = false;
            txtMSave04Neck.IsEnabled = false;

        }
        private void MakeTextBox05ReadOnly()
        {
            txtMSave05Name.IsReadOnly = true;
            txtMSave05Size.IsReadOnly = true;
            txtMSave05Chest.IsReadOnly = true;
            txtMSave05Shoulder.IsReadOnly = true;
            txtMSave05Waist.IsReadOnly = true;
            txtMSave05Inseem.IsReadOnly = true;
            txtMSave05Hip.IsReadOnly = true;
            txtMSave05Sleeve.IsReadOnly = true;
            txtMSave05Neck.IsReadOnly = true;

            txtMSave05Name.IsEnabled = false;
            txtMSave05Size.IsEnabled = false;
            txtMSave05Chest.IsEnabled = false;
            txtMSave05Shoulder.IsEnabled = false;
            txtMSave05Waist.IsEnabled = false;
            txtMSave05Inseem.IsEnabled = false;
            txtMSave05Hip.IsEnabled = false;
            txtMSave05Sleeve.IsEnabled = false;
            txtMSave05Neck.IsEnabled = false;

        }
        #endregion
        #region clear methods
        private void ClearAll()
        {
            Clear01();
            Clear02();
            Clear03();
            Clear04();
            Clear05();
        }
        private void Clear01()
        {
            txtMSave01Name.Text = "default name 01";
            txtMSave01Size.Text = "default size 01";
            txtMSave01Chest.Text = "00";
            txtMSave01Shoulder.Text = "00";
            txtMSave01Waist.Text = "00";
            txtMSave01Inseem.Text = "00";
            txtMSave01Hip.Text = "00";
            txtMSave01Sleeve.Text = "00";
            txtMSave01Neck.Text = "00";
        }
        private void Clear02()
        {
            txtMSave02Name.Text = "default name 02";
            txtMSave02Size.Text = "default size 02";
            txtMSave02Chest.Text = "00";
            txtMSave02Shoulder.Text = "00";
            txtMSave02Waist.Text = "00";
            txtMSave02Inseem.Text = "00";
            txtMSave02Hip.Text = "00";
            txtMSave02Sleeve.Text = "00";
            txtMSave02Neck.Text = "00";
        }
        private void Clear03()
        {
            txtMSave03Name.Text = "default name 03";
            txtMSave03Size.Text = "default size 03";
            txtMSave03Chest.Text = "00";
            txtMSave03Shoulder.Text = "00";
            txtMSave03Waist.Text = "00";
            txtMSave03Inseem.Text = "00";
            txtMSave03Hip.Text = "00";
            txtMSave03Sleeve.Text = "00";
            txtMSave03Neck.Text = "00";
        }
        private void Clear04()
        {
            txtMSave04Name.Text = "default name 04";
            txtMSave04Size.Text = "default size 04";
            txtMSave04Chest.Text = "00";
            txtMSave04Shoulder.Text = "00";
            txtMSave04Waist.Text = "00";
            txtMSave04Inseem.Text = "00";
            txtMSave04Hip.Text = "00";
            txtMSave04Sleeve.Text = "00";
            txtMSave04Neck.Text = "00";
        }
        private void Clear05()
        {
            txtMSave05Name.Text = "default name 05";
            txtMSave05Size.Text = "default size 05";
            txtMSave05Chest.Text = "00";
            txtMSave05Shoulder.Text = "00";
            txtMSave05Waist.Text = "00";
            txtMSave05Inseem.Text = "00";
            txtMSave05Hip.Text = "00";
            txtMSave05Sleeve.Text = "00";
            txtMSave05Neck.Text = "00";
        }
        #endregion
        #region Show Checkboxes
        private void ShowCheckBoxes()
        {
            cbxMSave01.Visibility = System.Windows.Visibility.Visible;
            cbxMSave02.Visibility = System.Windows.Visibility.Visible;
            cbxMSave03.Visibility = System.Windows.Visibility.Visible;
            cbxMSave04.Visibility = System.Windows.Visibility.Visible;
            cbxMSave05.Visibility = System.Windows.Visibility.Visible;
        }
        #endregion
        #region Hide Checkboxes
        private void HideCheckBoxes()
        {
            cbxMSave01.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave02.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave03.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave04.Visibility = System.Windows.Visibility.Collapsed;
            cbxMSave05.Visibility = System.Windows.Visibility.Collapsed;

            CheckedFalse();

            _DeleteButtonVisible = false;

        }

        private void CheckedFalse()
        {
            cbxMSave01.IsChecked = false;
            cbxMSave02.IsChecked = false;
            cbxMSave03.IsChecked = false;
            cbxMSave04.IsChecked = false;
            cbxMSave05.IsChecked = false;
        }
        #endregion

        public void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).SelectAll();
        }
        private void MoveDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (sender == txtMSave01Name || sender == txtMSave01Size ||
                    sender == txtMSave01Chest || sender == txtMSave01Shoulder ||
                    sender == txtMSave01Waist || sender == txtMSave01Inseem ||
                    sender == txtMSave01Hip || sender == txtMSave01Sleeve ||
                    sender == txtMSave01Neck)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtMSave01Name)
                    {
                        txtMSave01Size.Focus();
                    }
                    else if (sender == txtMSave01Size)
                    {
                        txtMSave01Chest.Focus();
                    }
                    else if (sender == txtMSave01Chest)
                    {
                        txtMSave01Waist.Focus();
                    }
                    else if (sender == txtMSave01Waist)
                    {
                        txtMSave01Hip.Focus();
                    }
                    else if (sender == txtMSave01Hip)
                    {
                        txtMSave01Neck.Focus();
                    }
                    else if (sender == txtMSave01Neck)
                    {
                        txtMSave01Sleeve.Focus();
                    }
                    else if (sender == txtMSave01Sleeve)
                    {
                        txtMSave01Shoulder.Focus();
                    }
                    else if (sender == txtMSave01Shoulder)
                    {
                        txtMSave01Inseem.Focus();
                    }
                    else if (sender == txtMSave01Inseem)
                    {
                        txtMSave01Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtMSave02Name || sender == txtMSave02Size ||
                    sender == txtMSave02Chest || sender == txtMSave02Shoulder ||
                    sender == txtMSave02Waist || sender == txtMSave02Inseem ||
                    sender == txtMSave02Hip || sender == txtMSave02Sleeve ||
                    sender == txtMSave02Neck)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtMSave02Name)
                    {
                        txtMSave02Size.Focus();
                    }
                    else if (sender == txtMSave02Size)
                    {
                        txtMSave02Chest.Focus();
                    }
                    else if (sender == txtMSave02Chest)
                    {
                        txtMSave02Waist.Focus();
                    }
                    else if (sender == txtMSave02Waist)
                    {
                        txtMSave02Hip.Focus();
                    }
                    else if (sender == txtMSave02Hip)
                    {
                        txtMSave02Neck.Focus();
                    }
                    else if (sender == txtMSave02Neck)
                    {
                        txtMSave02Sleeve.Focus();
                    }
                    else if (sender == txtMSave02Sleeve)
                    {
                        txtMSave02Shoulder.Focus();
                    }
                    else if (sender == txtMSave02Shoulder)
                    {
                        txtMSave02Inseem.Focus();
                    }
                    else if (sender == txtMSave02Inseem)
                    {
                        txtMSave02Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtMSave03Name || sender == txtMSave03Size ||
                    sender == txtMSave03Chest || sender == txtMSave03Shoulder ||
                    sender == txtMSave03Waist || sender == txtMSave03Inseem ||
                    sender == txtMSave03Hip || sender == txtMSave03Sleeve ||
                    sender == txtMSave03Neck)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtMSave03Name)
                    {
                        txtMSave03Size.Focus();
                    }
                    else if (sender == txtMSave03Size)
                    {
                        txtMSave03Chest.Focus();
                    }
                    else if (sender == txtMSave03Chest)
                    {
                        txtMSave03Waist.Focus();
                    }
                    else if (sender == txtMSave03Waist)
                    {
                        txtMSave03Hip.Focus();
                    }
                    else if (sender == txtMSave03Hip)
                    {
                        txtMSave03Neck.Focus();
                    }
                    else if (sender == txtMSave03Neck)
                    {
                        txtMSave03Sleeve.Focus();
                    }
                    else if (sender == txtMSave03Sleeve)
                    {
                        txtMSave03Shoulder.Focus();
                    }
                    else if (sender == txtMSave03Shoulder)
                    {
                        txtMSave03Inseem.Focus();
                    }
                    else if (sender == txtMSave03Inseem)
                    {
                        txtMSave03Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtMSave04Name || sender == txtMSave04Size ||
                    sender == txtMSave04Chest || sender == txtMSave04Shoulder ||
                    sender == txtMSave04Waist || sender == txtMSave04Inseem ||
                    sender == txtMSave04Hip || sender == txtMSave04Sleeve ||
                    sender == txtMSave04Neck)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtMSave04Name)
                    {
                        txtMSave04Size.Focus();
                    }
                    else if (sender == txtMSave04Size)
                    {
                        txtMSave04Chest.Focus();
                    }
                    else if (sender == txtMSave04Chest)
                    {
                        txtMSave04Waist.Focus();
                    }
                    else if (sender == txtMSave04Waist)
                    {
                        txtMSave04Hip.Focus();
                    }
                    else if (sender == txtMSave04Hip)
                    {
                        txtMSave04Neck.Focus();
                    }
                    else if (sender == txtMSave04Neck)
                    {
                        txtMSave04Sleeve.Focus();
                    }
                    else if (sender == txtMSave04Sleeve)
                    {
                        txtMSave04Shoulder.Focus();
                    }
                    else if (sender == txtMSave04Shoulder)
                    {
                        txtMSave04Inseem.Focus();
                    }
                    else if (sender == txtMSave04Inseem)
                    {
                        txtMSave04Name.Focus();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if (sender == txtMSave05Name || sender == txtMSave05Size ||
                    sender == txtMSave05Chest || sender == txtMSave05Shoulder ||
                    sender == txtMSave05Waist || sender == txtMSave05Inseem ||
                    sender == txtMSave05Hip || sender == txtMSave05Sleeve ||
                    sender == txtMSave05Neck)
            {
                if (e.Key == Key.Enter)
                {
                    if (sender == txtMSave05Name)
                    {
                        txtMSave05Size.Focus();
                    }
                    else if (sender == txtMSave05Size)
                    {
                        txtMSave05Chest.Focus();
                    }
                    else if (sender == txtMSave05Chest)
                    {
                        txtMSave05Waist.Focus();
                    }
                    else if (sender == txtMSave05Waist)
                    {
                        txtMSave05Hip.Focus();
                    }
                    else if (sender == txtMSave05Hip)
                    {
                        txtMSave05Neck.Focus();
                    }
                    else if (sender == txtMSave05Neck)
                    {
                        txtMSave05Sleeve.Focus();
                    }
                    else if (sender == txtMSave05Sleeve)
                    {
                        txtMSave05Shoulder.Focus();
                    }
                    else if (sender == txtMSave05Shoulder)
                    {
                        txtMSave05Inseem.Focus();
                    }
                    else if (sender == txtMSave05Inseem)
                    {
                        txtMSave05Name.Focus();
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
            _SaveButtonVisible = true;
            //remove buttons
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            ApplicationBar.Buttons.Remove(appBarButtonHome);
            //Create a new button. Save.
            appBarButtonSave = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButtonSave.Text = "save";
            ApplicationBar.Buttons.Add(appBarButtonSave);
            appBarButtonSave.Click += appBarButtonSave_Click;
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
            if (cbxMSave01.IsChecked == true)
            {
                Clear01();
            }
            if (cbxMSave02.IsChecked == true)
            {
                Clear02();
            }
            if (cbxMSave03.IsChecked == true)
            {
                Clear03();
            }
            if (cbxMSave04.IsChecked == true)
            {
                Clear04();
            }
            if (cbxMSave05.IsChecked == true)
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
            MakeAllTextBoxesEditable();
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
        }
        private void checkBoxAction_UnChecked(object sender, RoutedEventArgs e)
        {
            if (cbxMSave01.IsChecked == false && cbxMSave02.IsChecked == false &&
                cbxMSave03.IsChecked == false && cbxMSave04.IsChecked == false && cbxMSave05.IsChecked == false)
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
