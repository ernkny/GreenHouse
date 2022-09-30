using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class NumberOfProductsNotApprovedByAdminThisMonthDTO
    {
        public string ProductName { get; set; }
        public bool? Situation { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
