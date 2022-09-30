using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Concrete;
using YesilEv.Core.Context;
using YesilEv.DAL.Abstract;

namespace YesilEv.DAL.Concrete
{
    public class CompanyDal:EFRepositoryBase<Company,GreenHouse>,ICompanyDal
    {
    }
}
