using OpenQA.Selenium;


namespace SeleniumProject.ComponentHelper
{
    public class TextBoxHelper : BaseComponentHelper
    {
        private static IWebElement element;
        public static void TypeInTextBox(By locator, string text)
        {
            element = GenericHelper.GetElement(locator);
            element.SendKeys(text);

        }

        public static void TypeInTextBox(IWebElement element, string text)
        {
            Logger.Info($"Sending text: {text}");
            element.SendKeys(text);

        }

        public static void ClearTextBox(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Clear();

        }
    }
}
