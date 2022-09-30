using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Log.Abstract;

namespace YesilEv.Log.Concrete
{
    public class FileLogger<T> : ILogger<T>
        where T : class
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public FileLogger()
        {
            LogConfig logConfig = new LogConfig();
        }
        public void Info(T data)
        { string message = null;
            try
            {
                 message = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings
                 {
                       PreserveReferencesHandling = PreserveReferencesHandling.Objects
                   });
                Logger.Info(message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Hata Oluştu "+DateTime.Now+" " +message);
            }
        }
    }
}
