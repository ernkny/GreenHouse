using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Log.Abstract;

namespace YesilEv.Log.Concrete
{
    public class DatabaseLogger<T> : ILogger<T>
    {
        public void Info(T data)
        {
            throw new NotImplementedException();
        }
    }
}
