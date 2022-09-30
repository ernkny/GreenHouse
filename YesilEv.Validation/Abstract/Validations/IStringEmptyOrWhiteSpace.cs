using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Validation.Abstract.Validations
{
    internal interface IStringEmptyOrWhiteSpace<T>
    {
        bool StringEmptyOrWhiteSpace(T data);
    }
}
