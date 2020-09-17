
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SeleniumProject.Logging;
using ILog = log4net.ILog;

namespace SeleniumProject.Common
{
    public static class Utils
    {

        private static readonly ILog Logger = LogHelper.GetXmlLogger(typeof(Utils));

        public static IEnumerable<string> FindAllMatchingStringsInFile(string filePath, string textToSearchFor)
        {
            Logger.Info($"File path is: {filePath}");
            Logger.Info($"Searching for text: {textToSearchFor}");
            return File.ReadLines(filePath).Where(x => x.StartsWith(textToSearchFor));
        }
    }
}
