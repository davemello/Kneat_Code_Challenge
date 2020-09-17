using log4net;
using SeleniumProject.Logging;

namespace SeleniumProject.ComponentHelper
{

   /// <summary>
   /// Adds a logger to all component helper classes that inherit
   /// </summary>
   public class BaseComponentHelper
    {

        public static readonly ILog Logger = LogHelper.GetXmlLogger(typeof(BaseComponentHelper));
    }
}
