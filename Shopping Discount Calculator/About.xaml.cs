using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Shopping_Discount_Calculator.Resources;

namespace Shopping_Discount_Calculator
{
    public partial class About : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public About()
        {
            InitializeComponent();
            IsInitialized = true;

        }
        private void txbMoreApps_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //Show an application, using the default ContentType.
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

            marketplaceSearchTask.SearchTerms = "geekypanda";
            marketplaceSearchTask.Show();  
        }
        private void txbRateApp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }
        private void txbShareApp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "Shopping Discount Calculator App";
            shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/en-us/store/app/shopping-discount-calculator/c4984888-b8c1-47a7-929e-7808b6ec3313", UriKind.Absolute);
            shareLinkTask.Message = "Here is a great shopping discount App for your Windows Phone.";

            shareLinkTask.Show();
        }
    }
}