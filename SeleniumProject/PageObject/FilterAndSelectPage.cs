using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumProject.BaseClasses;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Extensions;
using System;
using System.Collections.Generic;

namespace SeleniumProject.PageObject
{
    public class FilterAndSelectPage : BasePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[@class='hotel_name_link url']")]
        private readonly IList<IWebElement> ListOfHotelsDisplayed;

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
                // var spaOption = _driver.FindElement(By.XPath("//div[@class='filteroptions']/descendant::a[@data-id='popular_activities-10']"), 5);
                var spaOption = _driver.FindElement(By.XPath("//div[@id='filter_facilities']/descendant::a[@data-id='hotelfacility-54']"), 5);
                CheckBoxHelper.CheckedCheckBox(spaOption);
            }
            catch (NoSuchElementException e)
            {
                Logger.Warn($"Element not found: {e}");
            }

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

            //var stars = _driver.FindElement(By.XPath("//*[@id='filter_class']/div[2]/a[3]/label/div"), 5);
            //stars.Click();
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
            BrowserHelper.GoBack();
            BrowserHelper.GoBack();
        }

    }



}

