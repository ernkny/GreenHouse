using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Core.Abstract
{
    public interface IUpdateRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity Update(TEntity item);

    }
}
