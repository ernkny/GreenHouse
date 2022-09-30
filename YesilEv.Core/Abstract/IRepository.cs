using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Core.Abstract
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        void MyChanges(); //uoa - dbsavechanges


    }
}
