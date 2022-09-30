using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Validation.Abstract.Validations;

namespace YesilEv.Validation.Abstract
{
    public abstract class AbstractProductValidator<T> : IStringEmptyOrWhiteSpace<T>,ICategoryControl<T>
        where T : class, new()
    {
        public abstract bool IsChildCategory(T data);
        public abstract bool StringEmptyOrWhiteSpace(T data);
        public abstract bool SubstancesValidate(List<string> substances);
    }
}
