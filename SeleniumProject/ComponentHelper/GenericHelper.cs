using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

using SeleniumProject.Settings;

namespace SeleniumProject.ComponentHelper
{
    public class GenericHelper : BaseComponentHelper
    {
        public static bool IsElementPresent(By locator)
        {
            try
            {
                return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
            {
                return ObjectRepository.Driver.FindElement(locator);
            }
            else
            {
                throw new NoSuchElementException("Element not found" + locator.ToString());
            }
        }

        public static void TakeScreenShotAsJpeg(string filename = "Screen")
        {
            Screenshot screen = ObjectRepository.Driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                string name = filename + DateTime.UtcNow.ToString("yyyy-MM-dd-mm-ss") + ".jpeg";
                screen.SaveAsFile(name, ScreenshotImageFormat.Jpeg);
                return;
            }

            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);




        }

     
    }
}
