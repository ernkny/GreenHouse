using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseEntityy.Concrete.DTO
{
    public class SearchDTO
    {

        public int Id { get; set; }

        public string CategoryName { get; set; }
        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string BarkodNo { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        //   public int? CreatedBy { get; set; }

        // public int? ModifiedBy { get; set; }
    }
}
/*
 * E
       public int Id { get; set; }

       public int? SubCategoryId { get; set; }
       public string Name { get; set; }

       public int? CompanyId { get; set; }

       public string BarkodNo { get; set; }

       public bool? isActive { get; set; }

       public DateTime? CreatedDate { get; set; }

       public DateTime? ModifiedDate { get; set; }

       public int? CreatedBy { get; set; }

       public int? ModifiedBy { get; set; }
       */