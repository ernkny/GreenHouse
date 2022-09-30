using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class UserInfoCountDto
    {
        public int AdminCount { get; set; }
        public int UserCount { get; set; }
        public int PremiumUserCount { get; set; }
        public int TotalUserCount { get; set; }
    }
}
