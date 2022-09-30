using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Core.Abstract
{
    public interface IInsertableRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity item);
        List<TEntity> AddRange(List<TEntity> items);

    }
}
