using OpenQA.Selenium;

namespace SeleniumProject.ComponentHelper
{
    public class CheckBoxHelper : BaseComponentHelper
    {
        private static IWebElement _element;
        public static void CheckedCheckBox(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            Logger.Info("Checking test box" + _element.Text);
            _element.Click();
        }

        public static void CheckedCheckBox(IWebElement element)
        {
            Logger.Info("Checking text box" + element.Text);
            element.Click();
        }

        public static bool IsCheckboxChecked(By locator)
        {
            _element = GenericHelper.GetElement(locator);
            var flag = _element.GetAttribute("checked");
            if (flag == null)
            {
                return false;
            }
            else
            {
                return flag.Equals("true") || flag.Equals("checked");
            }
        }

  

        public static bool IsCheckboxChecked(IWebElement element)
        {
            
            var flag = element.GetAttribute("checked");
            if (flag == null)
            {
                return false;
            }
            else
            {
                return flag.Equals("true") || flag.Equals("checked");
            }
        }
    }
}
