
using SeleniumProject.Settings;

namespace SeleniumProject.ComponentHelper
{
    public class WindowHelper : BaseComponentHelper
    {
        public static string GetTitle()
        {
            return ObjectRepository.Driver.Title;
        }
    }
}
