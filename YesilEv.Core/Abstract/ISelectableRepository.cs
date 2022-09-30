using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Core.Abstract
{
    public interface ISelectableRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(int id);

    }
}
