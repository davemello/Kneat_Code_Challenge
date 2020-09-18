using log4net;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.Logging;

namespace SeleniumProject.BaseClasses
{

    /// <summary>
    /// Holds an instance of logger and initialises elements using page factory
    /// </summary>
    public class BasePage
    {
        private readonly IWebDriver _driver;
        
        public string Title => _driver.Title;
        public static readonly ILog Logger = LogHelper.GetXmlLogger(typeof(BaseDefinition));
        public BasePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

      }
}
