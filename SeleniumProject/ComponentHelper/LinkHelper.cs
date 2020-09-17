
using OpenQA.Selenium;

namespace SeleniumProject.ComponentHelper
{
    public class LinkHelper : BaseComponentHelper
    {
        private static IWebElement element;

        public static void ClickLink(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }
    }
}
