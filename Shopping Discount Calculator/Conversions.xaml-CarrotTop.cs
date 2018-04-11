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
    public partial class Conversions : PhoneApplicationPage
    {
        Settings settings = new Settings();
        ApplicationBarIconButton appBarButtonSave;
        ApplicationBarIconButton appBarButtonCancel;
        ApplicationBarIconButton appBarButtonEdit;
        public bool IsEditModeOn;
        public Conversions()
        {
            InitializeComponent();
            RestoreSaveSettings();
            MakeViewReadOnly();
            EverythingInvisible();
        }
        //Tap events for women
        private void womensSaveSectionOneVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtWomensSaveOneBra.Visibility == System.Windows.Visibility.Visible)
            {
                womensSaveSectionOneInvisible();
            }
            else
            {
                womensSaveSectionOneVisible();
                womensSaveSectionTwoInvisible();
                womensSaveSectionThreeInvisible();
                womensSaveSectionFourInvisible();
                womensSaveSectionFiveInvisible();
            }
        }
        private void womensSaveSectionTwoVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtWomensSaveTwoBra.Visibility == System.Windows.Visibility.Visible)
            {
                womensSaveSectionTwoInvisible();
            }
            else
            {
                womensSaveSectionTwoVisible();
                womensSaveSectionOneInvisible();
                womensSaveSectionThreeInvisible();
                womensSaveSectionFourInvisible();
                womensSaveSectionFiveInvisible();
            }
        }
        private void womensSaveSectionThreeVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtWomensSaveThreeBra.Visibility == System.Windows.Visibility.Visible)
            {
                womensSaveSectionThreeInvisible();
            }
            else
            {
                womensSaveSectionThreeVisible();
                womensSaveSectionOneInvisible();
                womensSaveSectionTwoInvisible();
                womensSaveSectionFourInvisible();
                womensSaveSectionFiveInvisible();
            }
        }
        private void womensSaveSectionFourVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtWomensSaveFourBra.Visibility == System.Windows.Visibility.Visible)
            {
                womensSaveSectionFourInvisible();
            }
            else
            {
                womensSaveSectionFourVisible();
                womensSaveSectionOneInvisible();
                womensSaveSectionTwoInvisible();
                womensSaveSectionThreeInvisible();
                womensSaveSectionFiveInvisible();
            }
        }
        private void womensSaveSectionFiveVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtWomensSaveFiveBra.Visibility == System.Windows.Visibility.Visible)
            {
                womensSaveSectionFiveInvisible();
            }
            else
            {
                womensSaveSectionFiveVisible();
                womensSaveSectionOneInvisible();
                womensSaveSectionTwoInvisible();
                womensSaveSectionThreeInvisible();
                womensSaveSectionFourInvisible();
            }
        }
        //Tap events for men
        private void mensSaveSectionOneVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtMenSaveOneCollar.Visibility == System.Windows.Visibility.Visible)
            {
                mensSaveSectionOneInvisible();
            }
            else
            {
                mensSaveSectionOneVisible();
                mensSaveSectionTwoInvisible();
                mensSaveSectionThreeInvisible();
                mensSaveSectionFourInvisible();
                mensSaveSectionFiveInvisible();
            }
        }
        private void mensSaveSectionTwoVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtMenSaveTwoLeg.Visibility == System.Windows.Visibility.Visible)
            {
                mensSaveSectionTwoInvisible();
            }
            else
            {
                mensSaveSectionTwoVisible();
                mensSaveSectionOneInvisible();
                mensSaveSectionThreeInvisible();
                mensSaveSectionFourInvisible();
                mensSaveSectionFiveInvisible();
            }
        }
        private void mensSaveSectionThreeVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtMenSaveThreeLeg.Visibility == System.Windows.Visibility.Visible)
            {
                mensSaveSectionThreeInvisible();
            }
            else
            {
                mensSaveSectionThreeVisible();
                mensSaveSectionOneInvisible();
                mensSaveSectionTwoInvisible();
                mensSaveSectionFourInvisible();
                mensSaveSectionFiveInvisible();
            }
        }
        private void mensSaveSectionFourVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            if (txtMenSaveFourLeg.Visibility == System.Windows.Visibility.Visible)
            {
                mensSaveSectionFourInvisible();
            }
            else
            {
                mensSaveSectionFourVisible();
                mensSaveSectionOneInvisible();
                mensSaveSectionTwoInvisible();
                mensSaveSectionThreeInvisible();
                mensSaveSectionFiveInvisible();
            }
        }
        private void mensSaveSectionFiveVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TitlesVisibility();
            //the methods you can use are
            //mensSaveSectionFiveVisibleTextblocks();
            //mensSaveSectionFiveInvisibleTextBlocks();
            //mensSaveSectionFiveVisible(); textbox writeable only visible in edit mode on
            //mensSaveSectionFiveInvisible(); invisible at all othertimes.
            if (IsEditModeOn == false)
            {
                mensSaveSectionOneInvisible();
                mensSaveSectionTwoInvisible();
                mensSaveSectionThreeInvisible();
                mensSaveSectionFourInvisible();
                mensSaveSectionFiveInvisible();

                //if the state is collapsed EVERYTHING should be invisible.
                if (txbM5Leg.Visibility == System.Windows.Visibility.Visible)
                {
                    //make the section invisible
                    mensSaveSectionFiveInvisibleTextBlocks();
                }
                else
                {
                    //make the section visible AND make it readonly
                    mensSaveSectionFiveVisibleTextblocks();
                    
                    //TODO: these all need to change to the textblock ones
                    //mensSaveSectionOneInvisibleTextBlock();
                    //mensSaveSectionTwoInvisibleTextBlock();
                    //mensSaveSectionThreeInvisibleTextBlock();
                    //mensSaveSectionFourInvisibleTextBlock();
                }
            }
            else
            {
                mensSaveSectionOneInvisible();
                mensSaveSectionTwoInvisible();
                mensSaveSectionThreeInvisible();
                mensSaveSectionFourInvisible();

                //TODO: here add all of the textblocks and make them invisible
                mensSaveSectionFiveInvisibleTextBlocks();

                if (txtMenSaveFiveLeg.Visibility == System.Windows.Visibility.Visible)
                {
                    //make the section invisible AND make it readonly
                    mensSaveSectionFiveInvisible();
                }
                else
                {
                    //make the section visible and writeable
                    mensSaveSectionFiveVisible();
                }
            }
        }
        //visibility methods
        private void TitlesVisibility()
        {
            //these are the subject headings
            if (IsEditModeOn == true)
            {
                txbMensSaveNameOne.Visibility = System.Windows.Visibility.Collapsed;
                mensSaveNameOne.Visibility = System.Windows.Visibility.Visible;
                //TODO: make the other textboxes for Womens Section 01
                //TODO: make the other textboxes for Womens Section 02
                //TODO: make the other textboxes for Womens Section 03
                //TODO: make the other textboxes for Womens Section 04
                //TODO: make the other textboxes for Womens Section 05
                //TODO: make the other textboxes for Mens Section 02
                //TODO: make the other textboxes for Mens Section 03
                //TODO: make the other textboxes for Mens Section 04
                txbMensSaveNameFive.Visibility = System.Windows.Visibility.Collapsed;
                mensSaveNameFive.Visibility = System.Windows.Visibility.Visible;
            }
            else
            { 
                txbMensSaveNameOne.Visibility = System.Windows.Visibility.Visible;
                mensSaveNameOne.Visibility = System.Windows.Visibility.Collapsed;
                //TODO: make the other textboxes for Womens Section 01
                //TODO: make the other textboxes for Womens Section 02
                //TODO: make the other textboxes for Womens Section 03
                //TODO: make the other textboxes for Womens Section 04
                //TODO: make the other textboxes for Womens Section 05
                //TODO: make the other textboxes for Mens Section 02
                //TODO: make the other textboxes for Mens Section 03
                //TODO: make the other textboxes for Mens Section 04
                txbMensSaveNameFive.Visibility = System.Windows.Visibility.Visible;
                mensSaveNameFive.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        private void EverythingInvisible()
        {

            TitlesVisibility();

            womensSaveSectionOneInvisible();
            womensSaveSectionTwoInvisible();
            womensSaveSectionThreeInvisible();
            womensSaveSectionFourInvisible();
            womensSaveSectionFiveInvisible();
            mensSaveSectionOneInvisible();
            mensSaveSectionTwoInvisible();
            mensSaveSectionThreeInvisible();
            mensSaveSectionFourInvisible();
            mensSaveSectionFiveInvisible();
            //textblocks invisible
            mensSaveSectionFiveInvisibleTextBlocks();

        }
        //visibility methods for women
        private void womensSaveSectionOneVisible()
        {
            txtWomensSaveOneBra.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveOneDress.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveOneShoes.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveOneTop.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveOneWaist.Visibility = System.Windows.Visibility.Visible;
            txtW1Bra.Visibility = System.Windows.Visibility.Visible;
            txtW1Dress.Visibility = System.Windows.Visibility.Visible;
            txtW1Shoes.Visibility = System.Windows.Visibility.Visible;
            txtW1Top.Visibility = System.Windows.Visibility.Visible;
            txtW1Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void womensSaveSectionOneInvisible()
        {
            txtWomensSaveOneBra.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveOneDress.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveOneShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveOneTop.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveOneWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtW1Bra.Visibility = System.Windows.Visibility.Collapsed;
            txtW1Dress.Visibility = System.Windows.Visibility.Collapsed;
            txtW1Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtW1Top.Visibility = System.Windows.Visibility.Collapsed;
            txtW1Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void womensSaveSectionTwoVisible()
        {
            txtWomensSaveTwoBra.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveTwoDress.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveTwoShoes.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveTwoTop.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveTwoWaist.Visibility = System.Windows.Visibility.Visible;
            txtW2Bra.Visibility = System.Windows.Visibility.Visible;
            txtW2Dress.Visibility = System.Windows.Visibility.Visible;
            txtW2Shoes.Visibility = System.Windows.Visibility.Visible;
            txtW2Top.Visibility = System.Windows.Visibility.Visible;
            txtW2Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void womensSaveSectionTwoInvisible()
        {
            txtWomensSaveTwoBra.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveTwoDress.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveTwoShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveTwoTop.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveTwoWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtW2Bra.Visibility = System.Windows.Visibility.Collapsed;
            txtW2Dress.Visibility = System.Windows.Visibility.Collapsed;
            txtW2Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtW2Top.Visibility = System.Windows.Visibility.Collapsed;
            txtW2Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void womensSaveSectionThreeVisible()
        {
            txtWomensSaveThreeBra.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveThreeDress.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveThreeShoes.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveThreeTop.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveThreeWaist.Visibility = System.Windows.Visibility.Visible;
            txtW3Bra.Visibility = System.Windows.Visibility.Visible;
            txtW3Dress.Visibility = System.Windows.Visibility.Visible;
            txtW3Shoes.Visibility = System.Windows.Visibility.Visible;
            txtW3Top.Visibility = System.Windows.Visibility.Visible;
            txtW3Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void womensSaveSectionThreeInvisible()
        {
            txtWomensSaveThreeBra.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveThreeDress.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveThreeShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveThreeTop.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveThreeWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtW3Bra.Visibility = System.Windows.Visibility.Collapsed;
            txtW3Dress.Visibility = System.Windows.Visibility.Collapsed;
            txtW3Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtW3Top.Visibility = System.Windows.Visibility.Collapsed;
            txtW3Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void womensSaveSectionFourVisible()
        {
            txtWomensSaveFourBra.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFourDress.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFourShoes.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFourTop.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFourWaist.Visibility = System.Windows.Visibility.Visible;
            txtW4Bra.Visibility = System.Windows.Visibility.Visible;
            txtW4Dress.Visibility = System.Windows.Visibility.Visible;
            txtW4Shoes.Visibility = System.Windows.Visibility.Visible;
            txtW4Top.Visibility = System.Windows.Visibility.Visible;
            txtW4Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void womensSaveSectionFourInvisible()
        {
            txtWomensSaveFourBra.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFourDress.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFourShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFourTop.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFourWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtW4Bra.Visibility = System.Windows.Visibility.Collapsed;
            txtW4Dress.Visibility = System.Windows.Visibility.Collapsed;
            txtW4Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtW4Top.Visibility = System.Windows.Visibility.Collapsed;
            txtW4Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void womensSaveSectionFiveVisible()
        {
            txtWomensSaveFiveBra.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFiveDress.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFiveShoes.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFiveTop.Visibility = System.Windows.Visibility.Visible;
            txtWomensSaveFiveWaist.Visibility = System.Windows.Visibility.Visible;
            txtW5Bra.Visibility = System.Windows.Visibility.Visible;
            txtW5Dress.Visibility = System.Windows.Visibility.Visible;
            txtW5Shoes.Visibility = System.Windows.Visibility.Visible;
            txtW5Top.Visibility = System.Windows.Visibility.Visible;
            txtW5Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void womensSaveSectionFiveInvisible()
        {
            txtWomensSaveFiveBra.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFiveDress.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFiveShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFiveTop.Visibility = System.Windows.Visibility.Collapsed;
            txtWomensSaveFiveWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtW5Bra.Visibility = System.Windows.Visibility.Collapsed;
            txtW5Dress.Visibility = System.Windows.Visibility.Collapsed;
            txtW5Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtW5Top.Visibility = System.Windows.Visibility.Collapsed;
            txtW5Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        //visibility methods for men
        private void mensSaveSectionOneVisible()
        {
            txtMenSaveOneLeg.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveOneCollar.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveOneShoes.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveOneShirt.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveOneWaist.Visibility = System.Windows.Visibility.Visible;
            txtM1Collar.Visibility = System.Windows.Visibility.Visible;
            txtM1Leg.Visibility = System.Windows.Visibility.Visible;
            txtM1Shirt.Visibility = System.Windows.Visibility.Visible;
            txtM1Shoes.Visibility = System.Windows.Visibility.Visible;
            txtM1Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void mensSaveSectionOneInvisible()
        {
            txtMenSaveOneLeg.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveOneCollar.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveOneShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveOneShirt.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveOneWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtM1Collar.Visibility = System.Windows.Visibility.Collapsed;
            txtM1Leg.Visibility = System.Windows.Visibility.Collapsed;
            txtM1Shirt.Visibility = System.Windows.Visibility.Collapsed;
            txtM1Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtM1Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void mensSaveSectionTwoVisible()
        {
            txtMenSaveTwoLeg.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveTwoCollar.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveTwoShoes.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveTwoShirt.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveTwoWaist.Visibility = System.Windows.Visibility.Visible;
            txtM2Collar.Visibility = System.Windows.Visibility.Visible;
            txtM2Leg.Visibility = System.Windows.Visibility.Visible;
            txtM2Shirt.Visibility = System.Windows.Visibility.Visible;
            txtM2Shoes.Visibility = System.Windows.Visibility.Visible;
            txtM2Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void mensSaveSectionTwoInvisible()
        {
            txtMenSaveTwoLeg.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveTwoCollar.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveTwoShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveTwoShirt.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveTwoWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtM2Collar.Visibility = System.Windows.Visibility.Collapsed;
            txtM2Leg.Visibility = System.Windows.Visibility.Collapsed;
            txtM2Shirt.Visibility = System.Windows.Visibility.Collapsed;
            txtM2Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtM2Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void mensSaveSectionThreeVisible()
        {
            txtMenSaveThreeLeg.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveThreeCollar.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveThreeShoes.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveThreeShirt.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveThreeWaist.Visibility = System.Windows.Visibility.Visible;
            txtM3Collar.Visibility = System.Windows.Visibility.Visible;
            txtM3Leg.Visibility = System.Windows.Visibility.Visible;
            txtM3Shirt.Visibility = System.Windows.Visibility.Visible;
            txtM3Shoes.Visibility = System.Windows.Visibility.Visible;
            txtM3Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void mensSaveSectionThreeInvisible()
        {
            txtMenSaveThreeLeg.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveThreeCollar.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveThreeShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveThreeShirt.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveThreeWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtM3Collar.Visibility = System.Windows.Visibility.Collapsed;
            txtM3Leg.Visibility = System.Windows.Visibility.Collapsed;
            txtM3Shirt.Visibility = System.Windows.Visibility.Collapsed;
            txtM3Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtM3Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void mensSaveSectionFourVisible()
        {
            txtMenSaveFourLeg.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFourCollar.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFourShoes.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFourShirt.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFourWaist.Visibility = System.Windows.Visibility.Visible;
            txtM4Collar.Visibility = System.Windows.Visibility.Visible;
            txtM4Leg.Visibility = System.Windows.Visibility.Visible;
            txtM4Shirt.Visibility = System.Windows.Visibility.Visible;
            txtM4Shoes.Visibility = System.Windows.Visibility.Visible;
            txtM4Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void mensSaveSectionFourInvisible()
        {
            txtMenSaveFourLeg.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFourCollar.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFourShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFourShirt.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFourWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtM4Collar.Visibility = System.Windows.Visibility.Collapsed;
            txtM4Leg.Visibility = System.Windows.Visibility.Collapsed;
            txtM4Shirt.Visibility = System.Windows.Visibility.Collapsed;
            txtM4Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtM4Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void mensSaveSectionFiveVisibleTextblocks()
        {
            txbMensSaveNameFive.Visibility = System.Windows.Visibility.Visible;
            txbM5Collar.Visibility = System.Windows.Visibility.Visible;
            txbM5Leg.Visibility = System.Windows.Visibility.Visible;
            txbM5Shirt.Visibility = System.Windows.Visibility.Visible;
            txbM5Shoes.Visibility = System.Windows.Visibility.Visible;
            txbM5Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void mensSaveSectionFiveInvisibleTextBlocks()
        {
            txbMensSaveNameFive.Visibility = System.Windows.Visibility.Collapsed;
            txbM5Collar.Visibility = System.Windows.Visibility.Collapsed;
            txbM5Leg.Visibility = System.Windows.Visibility.Collapsed;
            txbM5Shirt.Visibility = System.Windows.Visibility.Collapsed;
            txbM5Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txbM5Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        private void mensSaveSectionFiveVisible()
        {
            txtMenSaveFiveLeg.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFiveCollar.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFiveShoes.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFiveShirt.Visibility = System.Windows.Visibility.Visible;
            txtMenSaveFiveWaist.Visibility = System.Windows.Visibility.Visible;
            txtM5Collar.Visibility = System.Windows.Visibility.Visible;
            txtM5Leg.Visibility = System.Windows.Visibility.Visible;
            txtM5Shirt.Visibility = System.Windows.Visibility.Visible;
            txtM5Shoes.Visibility = System.Windows.Visibility.Visible;
            txtM5Waist.Visibility = System.Windows.Visibility.Visible;
        }
        private void mensSaveSectionFiveInvisible()
        {
            txtMenSaveFiveLeg.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFiveCollar.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFiveShoes.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFiveShirt.Visibility = System.Windows.Visibility.Collapsed;
            txtMenSaveFiveWaist.Visibility = System.Windows.Visibility.Collapsed;
            txtM5Collar.Visibility = System.Windows.Visibility.Collapsed;
            txtM5Leg.Visibility = System.Windows.Visibility.Collapsed;
            txtM5Shirt.Visibility = System.Windows.Visibility.Collapsed;
            txtM5Shoes.Visibility = System.Windows.Visibility.Collapsed;
            txtM5Waist.Visibility = System.Windows.Visibility.Collapsed;
        }
        //Navigation Section
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RestoreSaveSettings();
            base.OnNavigatedTo(e);
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SaveSettings(); //think about whether you want this.
            base.OnNavigatedFrom(e);
        }
        private void BuildLocalizedApplicationBar()
        {
            // Set the page's ApplicationBar to a new instance of ApplicationBar.
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;

            // Create a new button and set the text value to the localized string from AppResources.
            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(new Uri("/Assets/AppBar/home.png", UriKind.Relative));
            appBarButtonHome.Text = AppResources.AppBarButtonHome;
            ApplicationBar.Buttons.Add(appBarButtonHome);
            appBarButtonHome.Click += appBarButtonHome_Click;

            // Create a new menu item with the localized string from AppResources.
            ApplicationBarMenuItem appBarMenuItemTaxes = new ApplicationBarMenuItem(AppResources.AppBarTaxes);
            ApplicationBar.MenuItems.Add(appBarMenuItemTaxes);
            appBarMenuItemTaxes.Click += appBarMenuItemTaxes_Click;

            ApplicationBarMenuItem appBarMenuItemHowTo = new ApplicationBarMenuItem(AppResources.AppBarHowTo);
            ApplicationBar.MenuItems.Add(appBarMenuItemHowTo);
            appBarMenuItemHowTo.Click += appBarMenuItemHowTo_Click;

            ApplicationBarMenuItem appBarMenuItemAbout = new ApplicationBarMenuItem(AppResources.AppBarAbout);
            ApplicationBar.MenuItems.Add(appBarMenuItemAbout);
            appBarMenuItemAbout.Click += appBarMenuItemAbout_Click;
        }
        private void BuildLocalizedApplicationBarReadOnly()
        {
            appBarButtonEdit = new ApplicationBarIconButton(new Uri("/Assets/AppBar/edit.png", UriKind.Relative));
            appBarButtonEdit.Text = AppResources.AppBarButtonEdit;
            ApplicationBar.Buttons.Add(appBarButtonEdit);
            appBarButtonEdit.Click += appBarButtonEdit_Click;
        }
        private void BuildLocalizedApplicationBarWriteOnly()
        {
            appBarButtonSave = new ApplicationBarIconButton(new Uri("/Assets/AppBar/save.png", UriKind.Relative));
            appBarButtonSave.Text = AppResources.AppBarButtonSave;
            ApplicationBar.Buttons.Add(appBarButtonSave);
            appBarButtonSave.Click += appBarButtonSave_Click;

            appBarButtonCancel = new ApplicationBarIconButton(new Uri("/Assets/AppBar/cancel.png", UriKind.Relative));
            appBarButtonCancel.Text = AppResources.AppBarButtonHome;
            ApplicationBar.Buttons.Add(appBarButtonCancel);
            appBarButtonCancel.Click += appBarButtonCancel_Click;
        }
        void appBarButtonHome_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/StartScreen.xaml", UriKind.Relative));
        }
        void appBarMenuItemTaxes_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Taxes.xaml", UriKind.Relative));
        }
        void appBarMenuItemHowTo_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/HowToUse.xaml", UriKind.Relative));
        }
        void appBarMenuItemAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
        void appBarButtonEdit_Click(object sender, EventArgs e)
        {
            ApplicationBar.Buttons.Remove(appBarButtonEdit);
            BuildLocalizedApplicationBarWriteOnly();
            Write();
        }
        private void appBarButtonCancel_Click(object sender, EventArgs e)
        {
            RestoreSaveSettings();
            MakeViewReadOnly();
            ApplicationBar.Buttons.Remove(appBarButtonCancel);
            ApplicationBar.Buttons.Remove(appBarButtonSave);
        }
        private void appBarButtonSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            MakeViewReadOnly();
            ApplicationBar.Buttons.Remove(appBarButtonCancel);
            ApplicationBar.Buttons.Remove(appBarButtonSave);
        }
        //save settings
        public void SaveSettings()
        {
            settings.W1Placeholder = womensSaveNameOne.Text;
            settings.W2Placeholder = womensSaveNameTwo.Text;
            settings.W3Placeholder = womensSaveNameThree.Text;
            settings.W4Placeholder = womensSaveNameFour.Text;
            settings.W5Placeholder = womensSaveNameFive.Text;
            settings.M1Placeholder = mensSaveNameOne.Text;
            settings.M2Placeholder = mensSaveNameTwo.Text;
            settings.M3Placeholder = mensSaveNameThree.Text;
            settings.M4Placeholder = mensSaveNameFour.Text;
            settings.M5Placeholder = mensSaveNameFive.Text;
            //shoes
            settings.W1Shoes = int.Parse(txtW1Shoes.Text);
            settings.W2Shoes = int.Parse(txtW2Shoes.Text);
            settings.W3Shoes = int.Parse(txtW3Shoes.Text);
            settings.W4Shoes = int.Parse(txtW4Shoes.Text);
            settings.W5Shoes = int.Parse(txtW5Shoes.Text);
            settings.M1Shoes = int.Parse(txtM1Shoes.Text);
            settings.M2Shoes = int.Parse(txtM2Shoes.Text);
            settings.M3Shoes = int.Parse(txtM3Shoes.Text);
            settings.M4Shoes = int.Parse(txtM4Shoes.Text);
            settings.M5Shoes = int.Parse(txtM5Shoes.Text);
            //bras
            settings.W1Bra = txtW1Bra.Text;
            settings.W2Bra = txtW2Bra.Text;
            settings.W3Bra = txtW3Bra.Text;
            settings.W4Bra = txtW4Bra.Text;
            settings.W5Bra = txtW5Bra.Text;
            //dress
            settings.W1Dress = txtW1Dress.Text;
            settings.W2Dress = txtW2Dress.Text;
            settings.W3Dress = txtW3Dress.Text;
            settings.W4Dress = txtW4Dress.Text;
            settings.W5Dress = txtW5Dress.Text;
            //waist
            settings.W1Waist = txtW1Waist.Text;
            settings.W2Waist = txtW2Waist.Text;
            settings.W3Waist = txtW3Waist.Text;
            settings.W4Waist = txtW4Waist.Text;
            settings.W5Waist = txtW5Waist.Text;
            settings.M1Waist = txtM1Waist.Text;
            settings.M2Waist = txtM2Waist.Text;
            settings.M3Waist = txtM3Waist.Text;
            settings.M4Waist = txtM4Waist.Text;
            settings.M5Waist = txtM5Waist.Text;
            //top
            settings.W1Top = txtW1Top.Text;
            settings.W2Top = txtW2Top.Text;
            settings.W3Top = txtW3Top.Text;
            settings.W4Top = txtW4Top.Text;
            settings.W5Top = txtW5Top.Text;
            //shirt
            settings.M1Shirt = txtM1Shirt.Text;
            settings.M2Shirt = txtM2Shirt.Text;
            settings.M3Shirt = txtM3Shirt.Text;
            settings.M4Shirt = txtM4Shirt.Text;
            settings.M5Shirt = txtM5Shirt.Text;
            //collar
            settings.M1Collar = txtM1Collar.Text;
            settings.M2Collar = txtM2Collar.Text;
            settings.M3Collar = txtM3Collar.Text;
            settings.M4Collar = txtM4Collar.Text;
            settings.M5Collar = txtM5Collar.Text;
            //leg
            settings.M1Leg = txtM1Leg.Text;
            settings.M2Leg = txtM2Leg.Text;
            settings.M3Leg = txtM3Leg.Text;
            settings.M4Leg = txtM4Leg.Text;
            settings.M5Leg = txtM5Leg.Text;
        }
        public void RestoreSaveSettings()
        {
            womensSaveNameOne.Text = settings.W1Placeholder;
            //TODO: add the textblock
            womensSaveNameTwo.Text = settings.W2Placeholder;
            //TODO: add the textblock
            womensSaveNameThree.Text = settings.W3Placeholder;
            //TODO: add the textblock
            womensSaveNameFour.Text = settings.W4Placeholder;
            //TODO: add the textblock
            womensSaveNameFive.Text = settings.W5Placeholder;
            //TODO: add the textblock
            mensSaveNameOne.Text = settings.M1Placeholder;
            txbMensSaveNameOne.Text = settings.M1Placeholder;
            mensSaveNameTwo.Text = settings.M2Placeholder;
            //TODO: add the textblock
            mensSaveNameThree.Text = settings.M3Placeholder;
            //TODO: add the textblock
            mensSaveNameFour.Text = settings.M4Placeholder;
            //TODO: add the textblock
            mensSaveNameFive.Text = settings.M5Placeholder;
            txbMensSaveNameFive.Text = settings.M5Placeholder;
            //shoes
            txtW1Shoes.Text = settings.W1Shoes.ToString();
            txtW2Shoes.Text = settings.W2Shoes.ToString();
            txtW3Shoes.Text = settings.W3Shoes.ToString();
            txtW4Shoes.Text = settings.W4Shoes.ToString();
            txtW5Shoes.Text = settings.W5Shoes.ToString();
            txtM1Shoes.Text = settings.M1Shoes.ToString();
            txtM2Shoes.Text = settings.M2Shoes.ToString();
            txtM3Shoes.Text = settings.M3Shoes.ToString();
            txtM4Shoes.Text = settings.M4Shoes.ToString();
            txtM5Shoes.Text = settings.M5Shoes.ToString();
            txbM5Shoes.Text = settings.M5Shoes.ToString();
            //bras
            txtW1Bra.Text = settings.W1Bra.ToString();
            txtW2Bra.Text = settings.W2Bra.ToString();
            txtW3Bra.Text = settings.W3Bra.ToString();
            txtW4Bra.Text = settings.W4Bra.ToString();
            txtW5Bra.Text = settings.W5Bra.ToString();
            //dress
            txtW1Dress.Text = settings.W1Dress.ToString();
            txtW2Dress.Text = settings.W2Dress.ToString();
            txtW3Dress.Text = settings.W3Dress.ToString();
            txtW4Dress.Text = settings.W4Dress.ToString();
            txtW5Dress.Text = settings.W5Dress.ToString();
            //waist
            txtW1Waist.Text = settings.W1Waist.ToString();
            txtW2Waist.Text = settings.W2Waist.ToString();
            txtW3Waist.Text = settings.W3Waist.ToString();
            txtW4Waist.Text = settings.W4Waist.ToString();
            txtW5Waist.Text = settings.W5Waist.ToString();
            txtM1Waist.Text = settings.M1Waist.ToString();
            txtM2Waist.Text = settings.M2Waist.ToString();
            txtM3Waist.Text = settings.M3Waist.ToString();
            txtM4Waist.Text = settings.M4Waist.ToString();
            txtM5Waist.Text = settings.M5Waist.ToString();
            //top
            txtW1Top.Text = settings.W1Top.ToString();
            txtW2Top.Text = settings.W2Top.ToString();
            txtW3Top.Text = settings.W3Top.ToString();
            txtW4Top.Text = settings.W4Top.ToString();
            txtW5Top.Text = settings.W5Top.ToString();
            //shirt
            txtM1Shirt.Text = settings.M1Shirt.ToString();
            txtM2Shirt.Text = settings.M2Shirt.ToString();
            txtM3Shirt.Text = settings.M3Shirt.ToString();
            txtM4Shirt.Text = settings.M4Shirt.ToString();
            txtM5Shirt.Text = settings.M5Shirt.ToString();
            //collar
            txtM1Collar.Text = settings.M1Collar.ToString();
            txtM2Collar.Text = settings.M2Collar.ToString();
            txtM3Collar.Text = settings.M3Collar.ToString();
            txtM4Collar.Text = settings.M4Collar.ToString();
            txtM5Collar.Text = settings.M5Collar.ToString();
            //leg
            txtM1Leg.Text = settings.M1Leg.ToString();
            txtM2Leg.Text = settings.M2Leg.ToString();
            txtM3Leg.Text = settings.M3Leg.ToString();
            txtM4Leg.Text = settings.M4Leg.ToString();
            txtM5Leg.Text = settings.M5Leg.ToString();
        }
        //readonly
        public void ReadOnly()
        {
            IsEditModeOn = false;

            womensSaveNameOne.IsReadOnly = true;
            womensSaveNameTwo.IsReadOnly = true;
            womensSaveNameThree.IsReadOnly = true;
            womensSaveNameFour.IsReadOnly = true;
            womensSaveNameFive.IsReadOnly = true;
            mensSaveNameTwo.IsReadOnly = true;
            mensSaveNameOne.IsReadOnly = true;
            mensSaveNameThree.IsReadOnly = true;
            mensSaveNameFour.IsReadOnly = true;
            mensSaveNameFive.IsReadOnly = true;
            //shoes
            txtW1Shoes.IsReadOnly = true;
            txtW2Shoes.IsReadOnly = true;
            txtW3Shoes.IsReadOnly = true;
            txtW4Shoes.IsReadOnly = true;
            txtW5Shoes.IsReadOnly = true;
            txtM1Shoes.IsReadOnly = true;
            txtM2Shoes.IsReadOnly = true;
            txtM3Shoes.IsReadOnly = true;
            txtM4Shoes.IsReadOnly = true;
            txtM5Shoes.IsReadOnly = true;
            //bras
            txtW1Bra.IsReadOnly = true;
            txtW2Bra.IsReadOnly = true;
            txtW3Bra.IsReadOnly = true;
            txtW4Bra.IsReadOnly = true;
            txtW5Bra.IsReadOnly = true;
            //dress
            txtW1Dress.IsReadOnly = true;
            txtW2Dress.IsReadOnly = true;
            txtW3Dress.IsReadOnly = true;
            txtW4Dress.IsReadOnly = true;
            txtW5Dress.IsReadOnly = true;
            //waist
            txtW1Waist.IsReadOnly = true;
            txtW2Waist.IsReadOnly = true;
            txtW3Waist.IsReadOnly = true;
            txtW4Waist.IsReadOnly = true;
            txtW5Waist.IsReadOnly = true;
            txtM1Waist.IsReadOnly = true;
            txtM2Waist.IsReadOnly = true;
            txtM3Waist.IsReadOnly = true;
            txtM4Waist.IsReadOnly = true;
            txtM5Waist.IsReadOnly = true;
            //top
            txtW1Top.IsReadOnly = true;
            txtW2Top.IsReadOnly = true;
            txtW3Top.IsReadOnly = true;
            txtW4Top.IsReadOnly = true;
            txtW5Top.IsReadOnly = true;
            //shirt
            txtM1Shirt.IsReadOnly = true;
            txtM2Shirt.IsReadOnly = true;
            txtM3Shirt.IsReadOnly = true;
            txtM4Shirt.IsReadOnly = true;
            txtM5Shirt.IsReadOnly = true;
            //collar
            txtM1Collar.IsReadOnly = true;
            txtM2Collar.IsReadOnly = true;
            txtM3Collar.IsReadOnly = true;
            txtM4Collar.IsReadOnly = true;
            txtM5Collar.IsReadOnly = true;
            //leg
            txtM1Leg.IsReadOnly = true;
            txtM2Leg.IsReadOnly = true;
            txtM3Leg.IsReadOnly = true;
            txtM4Leg.IsReadOnly = true;
            txtM5Leg.IsReadOnly = true;
        }
        //write
        public void Write()
        {
            IsEditModeOn = true;

            womensSaveNameOne.IsReadOnly = false;
            womensSaveNameTwo.IsReadOnly = false;
            womensSaveNameThree.IsReadOnly = false;
            womensSaveNameFour.IsReadOnly = false;
            womensSaveNameFive.IsReadOnly = false;
            mensSaveNameTwo.IsReadOnly = false;
            mensSaveNameOne.IsReadOnly = false;
            mensSaveNameThree.IsReadOnly = false;
            mensSaveNameFour.IsReadOnly = false;
            mensSaveNameFive.IsReadOnly = false;
            //shoes
            txtW1Shoes.IsReadOnly = false;
            txtW2Shoes.IsReadOnly = false;
            txtW3Shoes.IsReadOnly = false;
            txtW4Shoes.IsReadOnly = false;
            txtW5Shoes.IsReadOnly = false;
            txtM1Shoes.IsReadOnly = false;
            txtM2Shoes.IsReadOnly = false;
            txtM3Shoes.IsReadOnly = false;
            txtM4Shoes.IsReadOnly = false;
            txtM5Shoes.IsReadOnly = false;
            //bras
            txtW1Bra.IsReadOnly = false;
            txtW2Bra.IsReadOnly = false;
            txtW3Bra.IsReadOnly = false;
            txtW4Bra.IsReadOnly = false;
            txtW5Bra.IsReadOnly = false;
            //dress
            txtW1Dress.IsReadOnly = false;
            txtW2Dress.IsReadOnly = false;
            txtW3Dress.IsReadOnly = false;
            txtW4Dress.IsReadOnly = false;
            txtW5Dress.IsReadOnly = false;
            //waist
            txtW1Waist.IsReadOnly = false;
            txtW2Waist.IsReadOnly = false;
            txtW3Waist.IsReadOnly = false;
            txtW4Waist.IsReadOnly = false;
            txtW5Waist.IsReadOnly = false;
            txtM1Waist.IsReadOnly = false;
            txtM2Waist.IsReadOnly = false;
            txtM3Waist.IsReadOnly = false;
            txtM4Waist.IsReadOnly = false;
            txtM5Waist.IsReadOnly = false;
            //top
            txtW1Top.IsReadOnly = false;
            txtW2Top.IsReadOnly = false;
            txtW3Top.IsReadOnly = false;
            txtW4Top.IsReadOnly = false;
            txtW5Top.IsReadOnly = false;
            //shirt
            txtM1Shirt.IsReadOnly = false;
            txtM2Shirt.IsReadOnly = false;
            txtM3Shirt.IsReadOnly = false;
            txtM4Shirt.IsReadOnly = false;
            txtM5Shirt.IsReadOnly = false;
            //collar
            txtM1Collar.IsReadOnly = false;
            txtM2Collar.IsReadOnly = false;
            txtM3Collar.IsReadOnly = false;
            txtM4Collar.IsReadOnly = false;
            txtM5Collar.IsReadOnly = false;
            //leg
            txtM1Leg.IsReadOnly = false;
            txtM2Leg.IsReadOnly = false;
            txtM3Leg.IsReadOnly = false;
            txtM4Leg.IsReadOnly = false;
            txtM5Leg.IsReadOnly = false;
        }
        private void MakeViewReadOnly()
        {
            BuildLocalizedApplicationBar();
            BuildLocalizedApplicationBarReadOnly();
            ReadOnly();
        }
    }

}
//TODO: create textblocks that are use the save save settings as the textboxes. PhoneAccent as the BG color.
//TODO: visibility for the textboxes will need to be done.
//TODO: visibility for the textblocks
//TODO: on enter press move down.
//TODO: select all on tap of textbox