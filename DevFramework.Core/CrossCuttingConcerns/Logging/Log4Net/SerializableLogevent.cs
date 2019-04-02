using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public  class SerializableLogevent
    {
        LoggingEvent _loggingEvent;

        public SerializableLogevent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }


        public string UserName => _loggingEvent.UserName;
        public object MessageObject => _loggingEvent.MessageObject;
    }
}
