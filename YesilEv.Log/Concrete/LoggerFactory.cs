using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Log.Abstract;

namespace YesilEv.Log.Concrete
{
    public class LoggerFactory<T>
        where T : class
    {
        public enum LoggerType
        {
            DatabaseLogger=1,
            FileLogger=2,
        }

        public void FactoryMethod(LoggerType logType,T data)
        {
            ILogger<T> log = null;
            switch (logType)
            {
                case LoggerType.DatabaseLogger:
                    log= new DatabaseLogger<T>();
                    break;
                case LoggerType.FileLogger:
                    log= new FileLogger<T>();
                    break;
                default:
                    break;
            }
            log.Info(data);
        }
    }
}
