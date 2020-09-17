using SeleniumProject.Interfaces;
using OpenQA.Selenium;


namespace SeleniumProject.Settings
{
    public static class ObjectRepository
    {
        public static IConfig Config { get; set; }

        public static IWebDriver Driver { get; set; }


    }
}
