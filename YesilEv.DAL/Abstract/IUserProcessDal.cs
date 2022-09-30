using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Abstract;
using YesilEv.Core.Context;

namespace YesilEv.DAL.Abstract
{
    public interface IUserProcessDal: ISelectableRepository<UserProcess>, IDeletableRepository<UserProcess>, IInsertableRepository<UserProcess>, IUpdateRepository<UserProcess>
    {
    }
}
