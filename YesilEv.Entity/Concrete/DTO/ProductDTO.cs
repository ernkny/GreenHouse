using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Context;

namespace YesilEv.Entity.Concrete.DTO
{
    public  class ProductDTO
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public int CreatedUserId { get; set; }
        public int CompanyId { get; set; }

        public int CategoryId { get; set; }

        public bool isActive { get; set; }
        public string description { get; set; }
        public bool IsApproved { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
