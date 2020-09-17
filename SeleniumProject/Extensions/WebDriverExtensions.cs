using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }


        public static IWebElement WaitUntilVisible(
            this IWebDriver driver,
            By itemSpecifier,
            int secondsTimeout = 10)
        {
            return SetUpWait(driver, itemSpecifier, secondsTimeout, "visible");
        }

        public static IWebElement WaitUntilEnabled(this IWebDriver driver, By itemSpecifier, int secondsTimeout = 10)
        {
            return SetUpWait(driver, itemSpecifier, secondsTimeout, "enabled");
        }

        private static IWebElement SetUpWait(IWebDriver driver, By itemSpecifier, int secondsTimeout, string property)
        {
            bool trueOrFalseCheck; ;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsTimeout));
            var element = wait.Until(d =>
            {
                try
                {
                    var elementToBeDisplayed = driver.FindElement(itemSpecifier);
                    if (property.Equals("visible"))
                    {
                        trueOrFalseCheck = elementToBeDisplayed.Displayed;
                    }
                    else
                    {
                        trueOrFalseCheck = elementToBeDisplayed.Enabled;
                    }
                    if (trueOrFalseCheck)
                    {
                        return elementToBeDisplayed;
                    }
                    return null;
                }
                catch (StaleElementReferenceException)
                {
                    return null;
                }
                catch (NoSuchElementException)
                {
                    return null;
                }

            });
            return element;
        }

    

    }
}
