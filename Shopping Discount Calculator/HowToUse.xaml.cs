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
    public partial class HowToUse : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public HowToUse()
        {
            InitializeComponent();
            IsInitialized = true;
        }
    }
}