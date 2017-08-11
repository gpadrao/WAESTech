using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAES.Infra.CrossCutting.Utilities;

namespace WAES.Infra.CrossCutting.Log
{
    public class Logger
    {
        public Logger()
        {
        }
        public static void LogInfo(string message)
        {
            ILog _logger = LogManager.GetLogger(Constants.WAESLogRegister);
            ThreadContext.Properties["message"] = message;
            _logger.Info(message);
        }
    }
}
