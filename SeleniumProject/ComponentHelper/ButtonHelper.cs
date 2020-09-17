using System;
using OpenQA.Selenium;
using SeleniumProject.Waits;


namespace SeleniumProject.ComponentHelper
{
    public class ButtonHelper : BaseComponentHelper
    {
        private static IWebElement _element;

        public static void ClickButton(IWebElement element)
        {
            Logger.Info($"Clicking button: {element.Text}");
            element.Click();
        }

        public static void ClickButton(IWebElement element, int waitTime)
        {

            Logger.Info($"Clicking button: {element.Text}");
            try
            {
                element.Click();
                return;
            }
            catch (StaleElementReferenceException e)
            {
                Logger.Info($"Element not found: {e}");
            }
            catch (ElementNotVisibleException e)
            {
                Logger.Info($"Element not visible: {e}");
            }
            catch (WebDriverException e)
            {
                Logger.Info($"WebDriver Exception: {e}");
            }
            catch (Exception e)
            {
                Logger.Info($"Exception occured: {e}");
            }

            CustomWaits.Wait(waitTime);
          
            Logger.Info($"Exception caught in ClickButton method. Attempting to resume test");
            Logger.Info($"Clicking button: {element.Text}");
            element.Click();
            Logger.Info("Exception caught in ClickButton method, and test resumed ");
        }

 
        public static void ClickButton(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            _element.Click();
        }

        public static bool IsButtonEnabled(IWebElement element)
        {
            return element.Enabled;
        }

        public static bool IsButtonEnabled(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            return _element.Enabled;
        }

        public static string GetButtonText(IWebElement element)
        {
            return (element.GetAttribute("value").Length != 0) ? element.GetAttribute("value") : string.Empty;
        }


        public static string GetButtonText(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            return _element.GetAttribute("value") ?? string.Empty;

        }



  



    }

}
