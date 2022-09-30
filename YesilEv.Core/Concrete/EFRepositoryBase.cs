using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Abstract;

namespace YesilEv.Core.Concrete
{
    public class EFRepositoryBase<TEntity, TContext> : ISelectableRepository<TEntity>, IDeletableRepository<TEntity>, IInsertableRepository<TEntity>, IUpdateRepository<TEntity>
        where TEntity : class
        where TContext : DbContext, new()
    {
        private readonly TContext _context;
        public EFRepositoryBase(TContext context)
        {
            this._context = context;
        }
        public EFRepositoryBase()
        {
            _context = new TContext();
        }
        //Irepository implement
        public void MyChanges()
        {
            var s=_context.SaveChanges();
        }

        //insertable implement
        public TEntity Add(TEntity item)
        {
            return _context.Set<TEntity>().Add(item);
        }

        public List<TEntity> AddRange(List<TEntity> items)
        {
            return (List<TEntity>)_context.Set<TEntity>().AddRange(items);
        }
        //deletable
        public TEntity Delete(TEntity item)
        {
            return _context.Set<TEntity>().Remove(item);
        }

        //selectable

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                   ? _context.Set<TEntity>().ToList()
                   : _context.Set<TEntity>().Where(filter).ToList();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        //update
        public TEntity Update(TEntity item)
        {
            
            _context.Entry(item).State = EntityState.Modified;
            return _context.Set<TEntity>().Attach(item);
        }
    }
}
