using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Validation.Abstract.Validations
{
    public interface IEmailExist<T>
    {
        bool IsEmailExist(T data);
    }
}
