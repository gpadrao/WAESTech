using log4net;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Infra.CrossCutting.Log
{
    /// <summary>
    /// Implementing Log4Net. Like you can see within the Web.config file on "WAES.Web" project, there is a node named <log4net>
    /// that contains the mapping to write in WAESLog table all requisitions to the available api's. The WAESLog table contains only three properties
    /// WAESLogId (uniqueidentifier/primary key), Message ( text of the log ), LogDate ( contains the date of insertion )
    /// </summary>
    public class Logger
    {
        public Logger()
        {
        }
        /// <summary>
        /// Static method that provides an instance to the logger object, and writes the message into database mapped table
        /// </summary>
        /// <param name="message"></param>
        public static void LogInfo(string message)
        {
            ILog _logger = LogManager.GetLogger(Constants.WAESLogRegister);
            ThreadContext.Properties["message"] = message;
            _logger.Info(message);
        }
    }
}
