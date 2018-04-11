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
    public partial class Shoes : PhoneApplicationPage
    {
        private bool _IsInitialized = false;
        private ShoeSettings _Settings = new ShoeSettings();
        private Settings _AllSettings = new Settings();
        private int intWomensValue, intMensValue, intChildsValue;
        private bool turnOnToddlerSizes = false;

        private struct WomensShoeSizes
        {
            public double UK;
            public double US;
            public double EU;
            public double AUS;
        }
        private struct MensShoeSizes
        {
            public double UKAUS;
            public double US;
            public double EU;
        }
        private struct ToddlerShoeSizes
        {
            public double UKAUS;
            public double US;
            public double EU;
        }
        private struct ChildShoeSizes
        {
            public double UKAUS;
            public double US;
            public double EU;
        }

        public Shoes()
        {
            InitializeComponent();
            _IsInitialized = true;
            
            intWomensValue = (int)sldWomenShoes.Value;
            intMensValue = (int)sldMenShoes.Value;
            intChildsValue = (int)sldChildShoes.Value;
        }
        #region womens shoes sizes
        private readonly WomensShoeSizes[] womenShoes = new WomensShoeSizes[]
        {
            new WomensShoeSizes
            {
                UK = 2.5,
                US = 5,
                EU = 35,
                AUS = 3.5,
            },
            new WomensShoeSizes
            {
                UK = 3,
                US = 5.5,
                EU = 35.5,
                AUS = 4,
            },
            new WomensShoeSizes
            {
                UK = 3.5,
                US = 6,
                EU = 36,
                AUS = 4.5,
            },
            new WomensShoeSizes
            {
                UK = 4,
                US = 6.5,
                EU = 37,
                AUS = 5,
            },
            new WomensShoeSizes
            {
                UK = 4.5,
                US = 7,
                EU = 37.5,
                AUS = 5.5,
            },
            new WomensShoeSizes
            {
                UK = 5,
                US = 7.5,
                EU = 38,
                AUS = 6,
            },
            new WomensShoeSizes
            {
                UK = 5.5,
                US = 8,
                EU = 38.5,
                AUS = 6.5,
            },
            new WomensShoeSizes
            {
                UK = 6,
                US = 8.5,
                EU = 39,
                AUS = 7,
            },
            new WomensShoeSizes
            {
                UK = 6.5,
                US = 9,
                EU = 40,
                AUS = 7.5,
            },
            new WomensShoeSizes
            {
                UK = 7,
                US = 9.5,
                EU = 41,
                AUS = 8,
            },
            new WomensShoeSizes
            {
                UK = 7.5,
                US = 10,
                EU = 42,
                AUS = 8.5,
            },
        };

        #endregion
        #region mens shoe sizes
        private readonly MensShoeSizes[] menShoes = new MensShoeSizes[]
        {
            new MensShoeSizes
            {
                UKAUS = 6,
                US = 6.5,
                EU = 30,
            },
            new MensShoeSizes
            {
                UKAUS = 7,
                US = 7.5,
                EU = 40,
            },
            new MensShoeSizes
            {
                UKAUS = 7.5,
                US = 8,
                EU = 41,
            },
            new MensShoeSizes
            {
                UKAUS = 8,
                US = 8.5,
                EU = 42,
            },
            new MensShoeSizes
            {
                UKAUS = 8.5,
                US = 9,
                EU = 43,
            },
            new MensShoeSizes
            {
                UKAUS = 9,
                US = 9.5,
                EU = 43.5,
            },
            new MensShoeSizes
            {
                UKAUS = 9.5,
                US = 10,
                EU = 44,
            },
            new MensShoeSizes
            {
                UKAUS = 10,
                US = 10.5,
                EU = 44.5,
            },
            new MensShoeSizes
            {
                UKAUS = 10.5,
                US = 11,
                EU = 45,
            },
            new MensShoeSizes
            {
                UKAUS = 11,
                US = 11.5,
                EU = 45.5,
            },
            new MensShoeSizes
            {
                UKAUS = 11.5,
                US = 12,
                EU = 46,
            },
        };
        #endregion
        #region toddler shoe sizes
        private readonly ToddlerShoeSizes[] toddlerShoes = new ToddlerShoeSizes[]
        {
            new ToddlerShoeSizes
            {
                UKAUS = 4.5,
                US = 5.5,
                EU = 21,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 5,
                US = 6,
                EU = 22,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 5.5,
                US = 6.5,
                EU = 22,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 6,
                US = 7,
                EU = 23,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 6.5,
                US = 7.5,
                EU = 23,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 7,
                US = 8,
                EU = 24,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 7.5,
                US = 8.5,
                EU = 25,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 8,
                US = 9,
                EU = 25,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 8.5,
                US = 9.5,
                EU = 26,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 9,
                US = 10,
                EU = 27,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 9.5,
                US = 10.5,
                EU = 27,
            },
            new ToddlerShoeSizes
            {
                UKAUS = 10,
                US = 11,
                EU = 28,
            },
        };
        #endregion
        #region child shoe sizes
        private readonly ChildShoeSizes[] childShoes = new ChildShoeSizes[]
        {
            new ChildShoeSizes
            {
                UKAUS = 10.5,
                US = 11.5,
                EU = 29,
            },
            new ChildShoeSizes
            {
                UKAUS = 11,
                US = 12,
                EU = 30,
            },
            new ChildShoeSizes
            {
                UKAUS = 11.5,
                US = 12.5,
                EU = 30,
            },
            new ChildShoeSizes
            {
                UKAUS = 12,
                US = 13,
                EU = 31,
            },
            new ChildShoeSizes
            {
                UKAUS = 12.5,
                US = 13.5,
                EU = 31,
            },
            new ChildShoeSizes
            {
                UKAUS = 13,
                US = 1,
                EU = 32,
            },
            new ChildShoeSizes
            {
                UKAUS = 14,
                US = 1.5,
                EU = 33,
            },
            new ChildShoeSizes
            {
                UKAUS = 1,
                US = 2,
                EU = 33,
            },
            new ChildShoeSizes
            {
                UKAUS = 1.5,
                US = 2.5,
                EU = 34,
            },
            new ChildShoeSizes
            {
                UKAUS = 2,
                US = 3,
                EU = 34,
            },
            new ChildShoeSizes
            {
                UKAUS = 2.5,
                US = 3.5,
                EU = 35,
            },
            new ChildShoeSizes
            {
                UKAUS = 3,
                US = 4,
                EU = 36,
            },
        };
        #endregion
        private void WomensSizes(WomensShoeSizes[] women, int intValue)
        {
            txbWUKSize.Text = women[intWomensValue].UK.ToString();
            txbWUSSize.Text = women[intWomensValue].US.ToString();
            txbWEUROSize.Text = women[intWomensValue].EU.ToString();
            txbWAUSSize.Text = women[intWomensValue].AUS.ToString();
        }
        private void MenSizes(MensShoeSizes[] men, int intValue)
        {
            txbMUKSize.Text = men[intMensValue].UKAUS.ToString();
            txbMUSSize.Text = men[intMensValue].US.ToString();
            txbMEUROSize.Text = men[intMensValue].EU.ToString();
        }
        private void ChildSizes(ChildShoeSizes[] child, int intValue)
        {
            txbCUKSize.Text = child[intChildsValue].UKAUS.ToString();
            txbCUSSize.Text = child[intChildsValue].US.ToString();
            txbCEUROSize.Text = child[intChildsValue].EU.ToString();
        }
        private void ToddlerSizes(ToddlerShoeSizes[] toddler, int intValue)
        {
            txbCUKSize.Text = toddler[intChildsValue].UKAUS.ToString();
            txbCUSSize.Text = toddler[intChildsValue].US.ToString();
            txbCEUROSize.Text = toddler[intChildsValue].EU.ToString();
        }
        private void sldWomenShoes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            intWomensValue = (int)sldWomenShoes.Value;
            WomensSizes(womenShoes, intWomensValue);
        }
        private void sldMensShoes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            intMensValue = (int)sldMenShoes.Value;
            MenSizes(menShoes, intMensValue);
        }
        private void sldChildShoes_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            intChildsValue = (int)sldChildShoes.Value;

            if (turnOnToddlerSizes)
            {
                ToddlerSizes(toddlerShoes, intChildsValue);
            }
            else
            {
                ChildSizes(childShoes, intChildsValue);
            }
        }
        private void btnSwitch_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (turnOnToddlerSizes)
            {
                txbToddlerAndChildTitle.Text = "child : shoes";
                turnOnToddlerSizes = false;
                btnSwitch.Content = "toddler";
                ChildSizes(childShoes, intChildsValue);
            } 
            else
            {
                txbToddlerAndChildTitle.Text = "toddler : shoes";
                turnOnToddlerSizes = true;
                btnSwitch.Content = "child";
                ToddlerSizes(toddlerShoes, intChildsValue);
            }
        }
        private void btnSave_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int slot;
            //check to see who is the sender
            if (sender == btnWomenSave)
            {
                slot = IsThereAWomensSlotFree();
                if (slot != 0)
                {
                    NavigationService.Navigate(new Uri("/ShoeSaves.xaml?goto=0", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("all women shoe slots are full, please delete some data and try again", "warning", MessageBoxButton.OK);
                }
            }
            else if (sender == btnMenSave)
            {
                slot = IsThereAMensSlotFree();
                if (slot != 0)
                {
                    NavigationService.Navigate(new Uri("/ShoeSaves.xaml?goto=1", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("all men shoe slots are full, please delete some data and try again", "warning", MessageBoxButton.OK);
                }

            }
            else if (sender == btnChildSave)
            {
                slot = IsThereAChildSlotFree();
                if (slot != 0)
                {
                    NavigationService.Navigate(new Uri("/ShoeSaves.xaml?goto=2", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("all child shoe slots are full, please delete some data and try again", "warning", MessageBoxButton.OK);
                }
            }
            else
            {
                return;
            }
        }
        #region is there a slot free
        private int IsThereAWomensSlotFree()
        {
            if (!HasWomensGroup01BeenSavedIn())
            {
                WSave01();
                return 1;
            }
            if (!HasWomensGroup02BeenSavedIn())
            {
                WSave02();
                return 2;
            }
            if (!HasWomensGroup03BeenSavedIn())
            {
                WSave03();
                return 3;
            }
            if (!HasWomensGroup04BeenSavedIn())
            {
                WSave04();
                return 4;
            }
            if (!HasWomensGroup05BeenSavedIn())
            {
                WSave05();
                return 5;
            }
            return 0;
        }
        private int IsThereAMensSlotFree()
        {
            if (!HasMensGroup01BeenSavedIn())
            {
                MSave01();
                return 1;
            }
            if (!HasMensGroup02BeenSavedIn())
            {
                MSave02();
                return 2;
            }
            if (!HasMensGroup03BeenSavedIn())
            {
                MSave03();
                return 3;
            }
            if (!HasMensGroup04BeenSavedIn())
            {
                MSave04();
                return 4;
            }
            if (!HasMensGroup05BeenSavedIn())
            {
                MSave05();
                return 5;
            }
            return 0;
        }
        private int IsThereAChildSlotFree()
        {
            if (!HasChildGroup01BeenSavedIn())
            {
                CSave01();
                return 1;
            }
            if (!HasChildGroup02BeenSavedIn())
            {
                CSave02();
                return 2;
            }
            if (!HasChildGroup03BeenSavedIn())
            {
                CSave03();
                return 3;
            }
            if (!HasChildGroup04BeenSavedIn())
            {
                CSave04();
                return 4;
            }
            if (!HasChildGroup05BeenSavedIn())
            {
                CSave05();
                return 5;
            }
            return 0;
        }
        #endregion
        #region saves
        private bool HasWomensGroup01BeenSavedIn()
        {
            if (_Settings.WomenName01 == "default name 01" && _Settings.WomenSize01 == "00")
                return false;
            else
                return true;
        }
        private bool HasWomensGroup02BeenSavedIn()
        {
            if (_Settings.WomenName02 == "default name 02" && _Settings.WomenSize02 == "00")
                return false;
            else
                return true;
        }
        private bool HasWomensGroup03BeenSavedIn()
        {
            if (_Settings.WomenName03 == "default name 03" && _Settings.WomenSize03 == "00")
                return false;
            else
                return true;
        }
        private bool HasWomensGroup04BeenSavedIn()
        {
            if (_Settings.WomenName04 == "default name 04" && _Settings.WomenSize04 == "00")
                return false;
            else
                return true;
        }
        private bool HasWomensGroup05BeenSavedIn()
        {
            if (_Settings.WomenName05 == "default name 05" && _Settings.WomenSize05 == "00")
                return false;
            else
                return true;
        }
        private bool HasMensGroup01BeenSavedIn()
        {
            if (_Settings.MenName01 == "default name 01" && _Settings.MenSize01 == "00")
                return false;
            else
                return true;
        }
        private bool HasMensGroup02BeenSavedIn()
        {
            if (_Settings.MenName02 == "default name 02" && _Settings.MenSize02 == "00")
                return false;
            else
                return true;
        }
        private bool HasMensGroup03BeenSavedIn()
        {
            if (_Settings.MenName03 == "default name 03" && _Settings.MenSize03 == "00")
                return false;
            else
                return true;
        }
        private bool HasMensGroup04BeenSavedIn()
        {
            if (_Settings.MenName04 == "default name 04" && _Settings.MenSize04 == "00")
                return false;
            else
                return true;
        }
        private bool HasMensGroup05BeenSavedIn()
        {
            if (_Settings.MenName05 == "default name 05" && _Settings.MenSize05 == "00")
                return false;
            else
                return true;
        }
        private bool HasChildGroup01BeenSavedIn()
        {
            if (_Settings.ChildName01 == "default name 01" && _Settings.ChildSize01 == "00")
                return false;
            else
                return true;
        }
        private bool HasChildGroup02BeenSavedIn()
        {
            if (_Settings.ChildName02 == "default name 02" && _Settings.ChildSize02 == "00")
                return false;
            else
                return true;
        }
        private bool HasChildGroup03BeenSavedIn()
        {
            if (_Settings.ChildName03 == "default name 03" && _Settings.ChildSize03 == "00")
                return false;
            else
                return true;
        }
        private bool HasChildGroup04BeenSavedIn()
        {
            if (_Settings.ChildName04 == "default name 04" && _Settings.ChildSize04 == "00")
                return false;
            else
                return true;
        }
        private bool HasChildGroup05BeenSavedIn()
        {
            if (_Settings.ChildName05 == "default name 05" && _Settings.ChildSize05 == "00")
                return false;
            else
                return true;
        }
        private void WSave01()
        {
            if (_AllSettings.RadWShoeUK)
            {
                _Settings.WomenSize01 = "UK: " + womenShoes[intWomensValue].UK.ToString();
            }
            else if (_AllSettings.RadWShoeUS)
            {
                _Settings.WomenSize01 = "US: " + womenShoes[intWomensValue].US.ToString();
            }
            else if (_AllSettings.RadWShoeEU)
            {
                _Settings.WomenSize01 = "EU: " + womenShoes[intWomensValue].EU.ToString();
            }
            else if (_AllSettings.RadWShoeAU)
            {
                _Settings.WomenSize01 = "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
            else
            {
                _Settings.WomenSize01 = "UK: " + womenShoes[intWomensValue].UK.ToString() +
                    Environment.NewLine + "US: " + womenShoes[intWomensValue].US.ToString() +
                    Environment.NewLine + "EU: " + womenShoes[intWomensValue].EU.ToString() +
                    Environment.NewLine + "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
        }
        private void WSave02()
        {
            if (_AllSettings.RadWShoeUK)
            {
                _Settings.WomenSize02 = "UK: " + womenShoes[intWomensValue].UK.ToString();
            }
            else if (_AllSettings.RadWShoeUS)
            {
                _Settings.WomenSize02 = "US: " + womenShoes[intWomensValue].US.ToString();
            }
            else if (_AllSettings.RadWShoeEU)
            {
                _Settings.WomenSize02 = "EU: " + womenShoes[intWomensValue].EU.ToString();
            }
            else if (_AllSettings.RadWShoeAU)
            {
                _Settings.WomenSize02 = "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
            else
            {
                _Settings.WomenSize02 = "UK: " + womenShoes[intWomensValue].UK.ToString() +
                    Environment.NewLine + "US: " + womenShoes[intWomensValue].US.ToString() +
                    Environment.NewLine + "EU: " + womenShoes[intWomensValue].EU.ToString() +
                    Environment.NewLine + "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
        }
        private void WSave03()
        {
            if (_AllSettings.RadWShoeUK)
            {
                _Settings.WomenSize03 = "UK: " + womenShoes[intWomensValue].UK.ToString();
            }
            else if (_AllSettings.RadWShoeUS)
            {
                _Settings.WomenSize03 = "US: " + womenShoes[intWomensValue].US.ToString();
            }
            else if (_AllSettings.RadWShoeEU)
            {
                _Settings.WomenSize03 = "EU: " + womenShoes[intWomensValue].EU.ToString();
            }
            else if (_AllSettings.RadWShoeAU)
            {
                _Settings.WomenSize03 = "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
            else
            {
                _Settings.WomenSize03 = "UK: " + womenShoes[intWomensValue].UK.ToString() +
                    Environment.NewLine + "US: " + womenShoes[intWomensValue].US.ToString() +
                    Environment.NewLine + "EU: " + womenShoes[intWomensValue].EU.ToString() +
                    Environment.NewLine + "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
        }
        private void WSave04()
        {
            if (_AllSettings.RadWShoeUK)
            {
                _Settings.WomenSize04 = "UK: " + womenShoes[intWomensValue].UK.ToString();
            }
            else if (_AllSettings.RadWShoeUS)
            {
                _Settings.WomenSize04 = "US: " + womenShoes[intWomensValue].US.ToString();
            }
            else if (_AllSettings.RadWShoeEU)
            {
                _Settings.WomenSize04 = "EU: " + womenShoes[intWomensValue].EU.ToString();
            }
            else if (_AllSettings.RadWShoeAU)
            {
                _Settings.WomenSize04 = "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
            else
            {
                _Settings.WomenSize04 = "UK: " + womenShoes[intWomensValue].UK.ToString() +
                    Environment.NewLine + "US: " + womenShoes[intWomensValue].US.ToString() +
                    Environment.NewLine + "EU: " + womenShoes[intWomensValue].EU.ToString() +
                    Environment.NewLine + "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
        }
        private void WSave05()
        {
            if (_AllSettings.RadWShoeUK)
            {
                _Settings.WomenSize05 = "UK: " + womenShoes[intWomensValue].UK.ToString();
            }
            else if (_AllSettings.RadWShoeUS)
            {
                _Settings.WomenSize05 = "US: " + womenShoes[intWomensValue].US.ToString();
            }
            else if (_AllSettings.RadWShoeEU)
            {
                _Settings.WomenSize05 = "EU: " + womenShoes[intWomensValue].EU.ToString();
            }
            else if (_AllSettings.RadWShoeAU)
            {
                _Settings.WomenSize05 = "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
            else
            {
                _Settings.WomenSize05 = "UK: " + womenShoes[intWomensValue].UK.ToString() +
                    Environment.NewLine + "US: " + womenShoes[intWomensValue].US.ToString() +
                    Environment.NewLine + "EU: " + womenShoes[intWomensValue].EU.ToString() +
                    Environment.NewLine + "AUS: " + womenShoes[intWomensValue].AUS.ToString();
            }
        }
        private void MSave01()
        {
            if (_AllSettings.RadMShoeUK)
            {
                _Settings.MenSize01 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.MenSize01 = "US: " + menShoes[intMensValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.MenSize01 = "EU: " + menShoes[intMensValue].EU.ToString();
            }
            else
            {
                _Settings.MenSize01 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString() +
                    Environment.NewLine + "US: " + menShoes[intMensValue].US.ToString() +
                    Environment.NewLine + "EU: " + menShoes[intMensValue].EU.ToString();
            }
        }
        private void MSave02()
        {
            if (_AllSettings.RadMShoeUK)
            {
                _Settings.MenSize02 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.MenSize02 = "US: " + menShoes[intMensValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.MenSize02 = "EU: " + menShoes[intMensValue].EU.ToString();
            }
            else
            {
                _Settings.MenSize02 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString() +
                    Environment.NewLine + "US: " + menShoes[intMensValue].US.ToString() +
                    Environment.NewLine + "EU: " + menShoes[intMensValue].EU.ToString();
            }
        }
        private void MSave03()
        {
            if (_AllSettings.RadMShoeUK)
            {
                _Settings.MenSize03 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.MenSize03 = "US: " + menShoes[intMensValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.MenSize03 = "EU: " + menShoes[intMensValue].EU.ToString();
            }
            else
            {
                _Settings.MenSize03 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString() +
                    Environment.NewLine + "US: " + menShoes[intMensValue].US.ToString() +
                    Environment.NewLine + "EU: " + menShoes[intMensValue].EU.ToString();
            }
        }
        private void MSave04()
        {
            if (_AllSettings.RadMShoeUK)
            {
                _Settings.MenSize04 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.MenSize04 = "US: " + menShoes[intMensValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.MenSize04 = "EU: " + menShoes[intMensValue].EU.ToString();
            }
            else
            {
                _Settings.MenSize04 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString() +
                    Environment.NewLine + "US: " + menShoes[intMensValue].US.ToString() +
                    Environment.NewLine + "EU: " + menShoes[intMensValue].EU.ToString();
            }
        }
        private void MSave05()
        {
            if (_AllSettings.RadMShoeUK)
            {
                _Settings.MenSize05 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.MenSize05 = "US: " + menShoes[intMensValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.MenSize05 = "EU: " + menShoes[intMensValue].EU.ToString();
            }
            else
            {
                _Settings.MenSize05 = "UK/AUS: " + menShoes[intMensValue].UKAUS.ToString() +
                    Environment.NewLine + "US: " + menShoes[intMensValue].US.ToString() +
                    Environment.NewLine + "EU: " + menShoes[intMensValue].EU.ToString();
            }
        }
        private void CSave01()
        {
            if (_AllSettings.RadCShoeUK)
            {
                _Settings.ChildSize01 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.ChildSize01 = (!turnOnToddlerSizes) ? "US child: " + childShoes[intChildsValue].US.ToString() :
                    "US toddler: " + toddlerShoes[intChildsValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.ChildSize01 = (!turnOnToddlerSizes) ? "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
            else
            {
                _Settings.ChildSize01 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US child: " + childShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US toddler: " + toddlerShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
        }
        private void CSave02()
        {
            if (_AllSettings.RadCShoeUK)
            {
                _Settings.ChildSize02 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.ChildSize02 = (!turnOnToddlerSizes) ? "US child: " + childShoes[intChildsValue].US.ToString() :
                    "US toddler: " + toddlerShoes[intChildsValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.ChildSize02 = (!turnOnToddlerSizes) ? "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
            else
            {
                _Settings.ChildSize02 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US child: " + childShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US toddler: " + toddlerShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
        }
        private void CSave03()
        {
            if (_AllSettings.RadCShoeUK)
            {
                _Settings.ChildSize03 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.ChildSize03 = (!turnOnToddlerSizes) ? "US child: " + childShoes[intChildsValue].US.ToString() :
                    "US toddler: " + toddlerShoes[intChildsValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.ChildSize03 = (!turnOnToddlerSizes) ? "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
            else
            {
                _Settings.ChildSize03 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US child: " + childShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US toddler: " + toddlerShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
        }
        private void CSave04()
        {
            if (_AllSettings.RadCShoeUK)
            {
                _Settings.ChildSize04 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.ChildSize04 = (!turnOnToddlerSizes) ? "US child: " + childShoes[intChildsValue].US.ToString() :
                    "US toddler: " + toddlerShoes[intChildsValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.ChildSize04 = (!turnOnToddlerSizes) ? "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
            else
            {
                _Settings.ChildSize04 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US child: " + childShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US toddler: " + toddlerShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
        }
        private void CSave05()
        {
            if (_AllSettings.RadCShoeUK)
            {
                _Settings.ChildSize05 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString();
            }
            else if (_AllSettings.RadCShoeUS)
            {
                _Settings.ChildSize05 = (!turnOnToddlerSizes) ? "US child: " + childShoes[intChildsValue].US.ToString() :
                    "US toddler: " + toddlerShoes[intChildsValue].US.ToString();
            }
            else if (_AllSettings.RadCShoeEU)
            {
                _Settings.ChildSize05 = (!turnOnToddlerSizes) ? "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
            else
            {
                _Settings.ChildSize05 = (!turnOnToddlerSizes) ? "UK/AUS child: " + childShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US child: " + childShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU child: " + childShoes[intChildsValue].EU.ToString() :
                    "UK/AUS toddler: " + toddlerShoes[intChildsValue].UKAUS.ToString() +
                    Environment.NewLine + "US toddler: " + toddlerShoes[intChildsValue].US.ToString() +
                    Environment.NewLine + "EU toddler: " + toddlerShoes[intChildsValue].EU.ToString();
            }
        }
        #endregion
        private void navigation_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (sender == txbWNavigation)
            {
                NavigationService.Navigate(new Uri("/ShoeSaves.xaml?goto=0", UriKind.Relative));
            }
            else if (sender == txbMNavigation)
            {
                NavigationService.Navigate(new Uri("/ShoeSaves.xaml?goto=1", UriKind.Relative));               
            }
            else if (sender == txbCNavigation)
            {
                NavigationService.Navigate(new Uri("/ShoeSaves.xaml?goto=2", UriKind.Relative));
            }
            else
            {
                return;
            }
        }
    }
}