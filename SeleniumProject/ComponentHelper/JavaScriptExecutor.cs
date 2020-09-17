using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Settings;
using System;
using System.Threading;



namespace SeleniumProject.ComponentHelper
{
    public class JavaScriptExecutor : BaseComponentHelper
    {
       
        public static object ExecuteScript(string script)
        {
            var executor = (IJavaScriptExecutor)ObjectRepository.Driver;
            Logger.Info($" Execute Script @ {script}");
            return executor.ExecuteScript(script);

        }

        public static object ExecuteScript(string script, params object[] args)
        {
            var executor = ((IJavaScriptExecutor)ObjectRepository.Driver);
            return executor.ExecuteScript(script, args);
        }

        public static void ScrollToAndClick(IWebElement element)
        {

            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static void ScrollToAndClick(By locator)
        {
            var element = GenericHelper.GetElement(locator);
            ExecuteScript("window.scrollTo(0," + element.Location.Y + ")");
            Thread.Sleep(300);
            element.Click();
        }

        public static bool IsPageLoaded()
        {
           return ExecuteScript("return document.readyState").Equals("complete");
        }

        public static void WaitForPageLoad(IWebDriver webDriver)
        {
            var status = (string)((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState");
            Logger.Info($"Page load status: {status}");
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            wait.Until(drv => ((IJavaScriptExecutor)webDriver).ExecuteScript("return document.readyState").Equals("complete"));
        }


















    }
}


