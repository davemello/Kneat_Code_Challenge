using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Logging;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumProject.Waits
{
    public class CustomWaits
    {

        public static readonly ILog Logger = LogHelper.GetXmlLogger(typeof(CustomWaits));

        public static void WaitUntilElementIsPresent(IWebElement element)
        {
            var maxCycles = 20;
            while (!element.Displayed || maxCycles > 0)
            {
                Logger.Info("Waiting for element");
                Wait(1);
                maxCycles--;
            }
        }

        public static void Wait(int seconds)
        {
            try
            {
                Thread.Sleep(seconds*1000);
            }
            catch (ThreadInterruptedException e)
            {
                Thread.CurrentThread.Interrupt();
                Logger.Info($"Exception thrown from Utils.wait(): {e}");
            }
        }

        public static WebDriverWait GetWebDriverWait()
        {
           return  GetWebDriverWait(TimeSpan.FromSeconds(ObjectRepository.Config.GetDefaultWebDriveWaitTimeout()));
        }

        public static WebDriverWait GetWebDriverWait(TimeSpan timeout)
        {
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            var wait = new WebDriverWait(ObjectRepository.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Timeout = TimeSpan.FromSeconds(50)
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;
        }

        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
            var wait = GetWebDriverWait(timeout);
              var flag = wait.Until(WaitForWebElementFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return flag;
        }


        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            var wait = GetWebDriverWait(timeout);
            var element = wait.Until(WaitForWebElementInPageFunc(locator));
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeout());
            return element;
        }

        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) => x.FindElements(locator).Count == 1);

        }
     
        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {

                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;

            });
        }

        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) => x.FindElements(locator));

        }

    }
}
