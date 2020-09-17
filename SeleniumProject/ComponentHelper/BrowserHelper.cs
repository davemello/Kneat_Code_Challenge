using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumProject.Settings;

namespace SeleniumProject.ComponentHelper
{
   public class BrowserHelper: BaseComponentHelper
   {
       
        public static void BrowserMaximise()
        {
            Logger.Info("Maximise Browser");
            ObjectRepository.Driver.Manage().Window.Maximize();
           
        }

        public static void GoBack()
        {
            Logger.Info("Go to previous page");
            ObjectRepository.Driver.Navigate().Back();
        }

        public static void GoForward()
        {
            Logger.Info("Go to next page");
            ObjectRepository.Driver.Navigate().Forward();
        }

        public static void BrowserRefresh()
        {
            Logger.Info("Refresh browser");
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index)
        {
            Logger.Info("Switching windows");
            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            if (windows.Count < index)
            {
                throw new NoSuchWindowException("Invalid Browser Window Index");

            }
            else
            {
                ObjectRepository.Driver.SwitchTo().Window(windows[index]);
                BrowserMaximise();
            }
        }

        public static void SwitchToParent()
        {
            Logger.Info("Switching to parent window");
            var windows = ObjectRepository.Driver.WindowHandles;

            for (var i = windows.Count; i > 0; i--)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.SwitchTo().Window(windows[i]);
            }

            ObjectRepository.Driver.SwitchTo().Window(windows[0]);
        }
    }
}
