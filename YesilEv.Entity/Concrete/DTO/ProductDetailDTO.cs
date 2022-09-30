using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Core.Context;

namespace YesilEv.Entity.Concrete.DTO
{
    public class ProductDetailDTO
    {
        public int Id { get; set; }
        public string Barkod { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public List<SubstanceDTO> Substances { get; set; }
        public List<PictureDTO> Pictures { get; set; }

    }
}
