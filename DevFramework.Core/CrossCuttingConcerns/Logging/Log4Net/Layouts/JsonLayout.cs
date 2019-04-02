using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        //Install-Package Newtonsoft.Json pakerın eklenmseı gerek
        public override void ActivateOptions()
        {
           
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogevent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented);

            //veritabanına dosyya console ekranına yazmak ıcın
            writer.WriteLine(json);
        }
    }
}
