using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumProject.BaseClasses;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Extensions;
using SeleniumProject.Settings;
using SeleniumProject.Text;
using SeleniumProject.Waits;
using System;
using System.Globalization;

namespace SeleniumProject.PageObject
{
    public class HomePage : BasePage
    {

        private readonly IWebDriver _driver;


        [FindsBy(How = How.Id, Using = "onetrust-accept-btn-handler")]
        private readonly IWebElement AcceptCookies;

        [FindsBy(How = How.XPath, Using = "//*[@class='xp__fieldset js--sb-fieldset accommodation']")]
        private readonly IWebElement SearchBar;

        [FindsBy(How = How.Id, Using = "ss")]
        private readonly IWebElement DestinationSearchBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='frm']/descendant::li[1]")]
        private readonly IWebElement FirstItemInDestinationList;

        [FindsBy(How = How.XPath, Using = "//div[@class='bui-calendar']")]
        private readonly IWebElement CalendarDisplay;

        [FindsBy(How = How.XPath, Using = "//div[@class='xp__button']")]
        private readonly IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='xp__dates-inner']")]
        private readonly IWebElement DatePickerSearchBox;

        [FindsBy(How = How.XPath, Using = "//*[@class='bui-calendar__control bui-calendar__control--next']")]
        private readonly IWebElement CalendarNextMonthControl;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void CheckForCookiePrefNotification()
        {
            JavaScriptExecutor.WaitForPageLoad(_driver);

            try
            {
                //set default implicit wait to 1sec just for cookie check
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                if (GenericHelper.IsElementPresent(By.Id("onetrust-banner-sdk")))
                {
                    ButtonHelper.ClickButton(AcceptCookies, 3);

                    if (AcceptCookies.Displayed)
                    {
                        ButtonHelper.ClickButton(AcceptCookies, 3);
                    }
                    CustomWaits.Wait(1);
                }
                //set back to default value of 20
                ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            }
            catch (Exception)
            {
                Logger.Info("Cookie warning not present");
            }

        }

        public void EnterSearchDetails()
        {
            Logger.Info("Entering Default Search criteria");
            DestinationSearchBox.Clear();
            TextBoxHelper.TypeInTextBox(DestinationSearchBox, RequiredText.DefaultLocation);

            //wait for drop down to appear
            _driver.WaitUntilVisible(By.XPath("//*[@id='frm']/descendant::ul[1]"));
            //get first item in list and click, this will open calendar
            ButtonHelper.ClickButton(FirstItemInDestinationList);
            SelectDefaultDates();
            ButtonHelper.ClickButton(SearchButton);

        }

        private void SelectDefaultDates()
        {
            if (!CalendarDisplay.Displayed)
            {
                DatePickerSearchBox.Click();
                CustomWaits.Wait(1);
            }
            var dateIn3Months = DateTime.Now.AddMonths(3);
            var day = dateIn3Months.Day.ToString("00");
            var nextDay = dateIn3Months.AddDays(1).Day.ToString("00");
            var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateIn3Months.Month);
            //loop until month is found
            bool isMonthNotEqual = true;
            do
            {
                var firstMonthOfCalendar = _driver.FindElement(By.XPath("(//*[@class='bui-calendar__month'])[1]"));
                var monthText = firstMonthOfCalendar.Text;
                if (!monthText.Contains(monthName))
                {
                    ButtonHelper.ClickButton(CalendarNextMonthControl);
                }
                else
                {
                    isMonthNotEqual = false;
                }
            } while (isMonthNotEqual);

            ClickOnSelectedCalendarDay(day, nextDay);
        }

        private void ClickOnSelectedCalendarDay(string day, string nextDay)
        {
            var calendarDay = _driver.FindElement(By.XPath($"//td[@data-bui-ref='calendar-date'][@data-date='2020-12-{day}']"));
            var calendarNextDay = _driver.FindElement(By.XPath($"//td[@data-bui-ref='calendar-date'][@data-date='2020-12-{nextDay}']"));

            var classAttribute = calendarDay.GetAttribute("class");
            //if date has previously been selected then need to click away from initial date, then redo selection
            if (classAttribute.Contains("selected"))
            {
                ButtonHelper.ClickButton(calendarNextDay);
                ButtonHelper.ClickButton(calendarDay);
                ButtonHelper.ClickButton(calendarNextDay);
            }
            else
            {
                ButtonHelper.ClickButton(calendarDay);
                ButtonHelper.ClickButton(calendarNextDay);
            }

        }
    }
}
