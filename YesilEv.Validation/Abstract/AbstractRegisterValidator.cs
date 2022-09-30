using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Validation.Abstract.Validations;

namespace YesilEv.Validation.Abstract
{
    public abstract class AbstractRegisterValidator<T> : IEmailExist<T>, IStringEmptyOrWhiteSpace<T>
        where T : class, new()
    {
        public abstract bool IsEmailExist(T data);

        public abstract bool StringEmptyOrWhiteSpace(T data);


     
    }
}
