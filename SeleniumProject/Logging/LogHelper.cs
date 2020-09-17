using System;
using log4net;
using log4net.Config;

namespace SeleniumProject.Logging
{
    public static class LogHelper
    {


        #region Fields

        private static ILog _xmlLogger;
        #endregion

        #region Public


        public static ILog GetXmlLogger(Type type)
        {
            if (_xmlLogger != null)
            {
                return _xmlLogger;
            }

            XmlConfigurator.Configure();
            _xmlLogger = LogManager.GetLogger(type);
            return _xmlLogger;

        }

        #endregion
    }
}
