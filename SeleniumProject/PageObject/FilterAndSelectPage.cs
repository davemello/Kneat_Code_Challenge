using Newtonsoft.Json;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumProject.BaseClasses;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Extensions;
using SeleniumProject.Settings;
using SeleniumProject.Text;
using System;
using System.Collections.Generic;

namespace SeleniumProject.PageObject
{
    public class FilterAndSelectPage : BasePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='hotel_name_link url']")]
        private readonly IList<IWebElement> ListOfHotelsDisplayed;

        [FindsBy(How = How.XPath, Using = "//h3[@class='filtercategory-title'][contains(text(),'Star')]")]
        private readonly IWebElement StarRatingHeader;

        public FilterAndSelectPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }



        public void UseSpecifiedFilterToSearchForHotels(string filter)
        {
            if (filter.Equals("Spa and wellness centre"))
            {
                SelectSpaAndWellnessCentre();
            }
            else
            {
                SelectStarRating(filter);
            }
        }

        private void SelectSpaAndWellnessCentre()
        {
            try
            {
                //show all facilities
                var expandList = _driver.FindElement(By.XPath("//button[contains(text(),'Show all 13')]"), 5);
                ButtonHelper.ClickButton(expandList);
                //spa and wellness center
                var spaOption = _driver.FindElement(By.XPath("//div[@id='filter_facilities']/descendant::a[@data-id='hotelfacility-54']"), 5);
                CheckBoxHelper.CheckedCheckBox(spaOption);
            }
            catch (NoSuchElementException e)
            {
                Logger.Warn($"Element not found: {e}");
            }

        }

        public bool IsStarRatingPanelHeaderPresent()
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            if (StarRatingHeader.Displayed)
            {
                return true;
            }
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return false;

        }

        private void SelectStarRating(string rating)
        {
            string starRatingValue = "0";
            switch (rating)
            {
                case "5 Star":
                    starRatingValue = "5";
                    break;
                case "4 Star":
                    starRatingValue = "4";
                    break;
                case "3 Star":
                    starRatingValue = "3";
                    break;
                case "Unrated":
                    starRatingValue = "0";
                    break;
                default:
                    break;
            }

            var starsCheckBox = _driver.FindElement(By.XPath($"//div[@class='filteroptions']/descendant::a[@data-id='class-{starRatingValue}']"), 5);
            CheckBoxHelper.CheckedCheckBox(starsCheckBox);
        }


        public bool CheckHotelListForName(string hotelName, string isListed)
        {

            //go through list and depending on true of false, hotel should or should not be present
            bool doesHotelMatchRule = false;
            foreach (IWebElement hotel in ListOfHotelsDisplayed)
            {
                //if true hotel must match 1 from list
                if (Boolean.Parse(isListed))
                {
                    if (hotel.Text.Contains(hotelName))
                    {
                        doesHotelMatchRule = true;
                    }
                }
                //if  is shouldnt be listed then there should be no matches on list
                else
                {
                    if (!hotel.Text.Contains(hotelName))
                    {
                        doesHotelMatchRule = true;
                    }
                }
            }
            return doesHotelMatchRule;
        }



        public void GoBackToHomePage()
        {
              //click on booking.com logo and ensure user returned to home page
            do
            {
                var bookingLogo = _driver.FindElement(By.Id("logo_no_globe_new_logo"));
                ButtonHelper.ClickButton(bookingLogo);
            } while (!_driver.Title.Contains(RequiredText.TitleOfLandingPage));
        }
    }
}

