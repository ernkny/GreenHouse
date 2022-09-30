using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class ProductListDTO
    {
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string BarkodNo { get; set; }
        public string Name { get; set; }

         public bool? isActive { get; set; }

        public DateTime? CreatedDate { get; set; }
        public bool? IsApproved { get; set; }


        // public int? CreatedBy { get; set; }

        //public int? ModifiedBy { get; set; }
        public override string ToString()
        {
            return (BarkodNo).ToString(); 
        }

    }
}
