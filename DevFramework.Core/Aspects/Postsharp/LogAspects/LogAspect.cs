using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetMemberAttributes =MulticastAttributes.Instance)]
    //nesnelerin methodlarına uygula namespace ustunde yazmak ıstersek
   public class LogAspect: OnMethodBoundaryAspect
    {
        private Type _loggerType;
        LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType !=typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }

            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }


        public override void OnEntry(MethodExecutionArgs args)
        {
            //enable degılse
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }

            try
            {
                //t iteratir ise birinci ikinci arguman gibi
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)

                }).ToList();

                //sınıf ve metgod simi gıbı namespace ıne  karsılık gelıyor
                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    LogParameters = logParameters
                };

                //logdetaili kaydediyoruz
                _loggerService.Info(logDetail);
            }
            catch  (Exception)
            {

                
            }



        }
    }
}
