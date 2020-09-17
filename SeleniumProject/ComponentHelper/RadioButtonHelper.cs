using OpenQA.Selenium;

namespace SeleniumProject.ComponentHelper
{
    public class RadioButtonHelper : BaseComponentHelper
    {
        private static IWebElement element;

        public static void ClickRadioButton(By locator)
        {

            element = GenericHelper.GetElement(locator);
            element.Click();
        }

        public static bool IsRadioButtonChecked(By locator)
        {
            element = GenericHelper.GetElement(locator);
            string flag = element.GetAttribute("checked");
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
