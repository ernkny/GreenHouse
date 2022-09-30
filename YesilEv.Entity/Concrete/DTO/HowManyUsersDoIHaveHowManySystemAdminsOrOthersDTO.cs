using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class HowManyUsersDoIHaveHowManySystemAdminsOrOthersDTO
    {
        public int AdminCount { get; set; }
        public int PremiumUserCount { get; set; }
        public int NormalUserCount { get; set; }
    }
}
