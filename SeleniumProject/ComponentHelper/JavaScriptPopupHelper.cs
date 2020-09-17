using OpenQA.Selenium;
using SeleniumProject.Settings;

namespace SeleniumProject.ComponentHelper
{
    public class JavaScriptPopupHelper : BaseComponentHelper
    {
        public static bool IsPopupPresent()
        {
            try
            {
                ObjectRepository.Driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                
                return false;
            }
            
        }

        public static string GetPopupText()
        {
            if (!IsPopupPresent())
            {
                return "";
            }

            return ObjectRepository.Driver.SwitchTo().Alert().Text;
        }

        public static void ClickOkOnPopup()
        {
            if (!IsPopupPresent())
            {
                return;
            }
            ObjectRepository.Driver.SwitchTo().Alert().Accept();


        }

        public static void ClickCancelOnPopup()
        {
            if (!IsPopupPresent())
            {
                return;
            }
            ObjectRepository.Driver.SwitchTo().Alert().Dismiss();


        }

        public static void SendKeysToPopup(string text)
        {
            if (!IsPopupPresent())
            {
                return;
            }
            ObjectRepository.Driver.SwitchTo().Alert().SendKeys(text);
        }


    }
}
