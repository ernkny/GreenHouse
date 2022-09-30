using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Log.Abstract
{
    public interface ILogger<T>
    {
        void Info(T data);
    }
}
