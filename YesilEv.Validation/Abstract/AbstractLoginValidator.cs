using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Validation.Abstract.Validations;

namespace YesilEv.Validation.Abstract
{
    public abstract class AbstractLoginValidator<T> : IStringEmptyOrWhiteSpace<T> where T : class
    {
        public abstract bool StringEmptyOrWhiteSpace(T data);

    }
}