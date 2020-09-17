using SeleniumProject.Configuration;


namespace SeleniumProject.Interfaces
{
    public interface IConfig
    {
        BrowserType GetBrowser();

        string GetWebsite();
 
        int GetPageLoadTimeOut();

        int GetElementLoadTimeout();

        int GetDefaultWebDriveWaitTimeout();


    }
}
