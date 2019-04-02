using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    //nuget paketden log4net eklıyoruz
    [Serializable]
   public class LoggerService
    {
      private  ILog _log;
        public LoggerService(ILog log)
        {
            _log = log;
        }

        //normal loglama su kısı su saatte su metodu cagırdı gıbı
        public bool IsInfoEnabled => _log.IsInfoEnabled;
        public bool IsDebudEnabled => _log.IsDebugEnabled;
        //uyarı bıcımlerınde loglama için
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        //hataların loglalnması gıbı
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            }
        }

        public void Debug(object logMessage)
        {
            if (IsDebudEnabled)
            {
                _log.Debug(logMessage);
            }
        }

        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }
        }

        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
        }
    }
}
