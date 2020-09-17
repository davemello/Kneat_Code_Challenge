
using System.Collections.Generic;
using System.Linq;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumProject.ComponentHelper
{
    public class DropDownHelper : BaseComponentHelper
    {
        private static SelectElement select;

        public static void SelectElement(By locator, string text)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByText(text);

        }

        public static void SelectElement(IWebElement element, string text)
        {
            select = new SelectElement(element);
            select.SelectByText(text);

        }

        public static void SelectElement(By locator, int index)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            select.SelectByIndex(index);

        }

        public static IList<string> GetAllItems(By locator)
        {
            select = new SelectElement(GenericHelper.GetElement(locator));
            return select.Options.Select((x) => x.Text).ToList();
        }    }
}
