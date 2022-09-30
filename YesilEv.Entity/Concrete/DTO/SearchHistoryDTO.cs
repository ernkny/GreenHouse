using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseEntityy.Concrete.DTO
{
    public class SearchHistoryDTO
    {
        public int ProductId { get; set; }

        public int? UserId { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreatedDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {

            }
        }

        public DateTime? ModifiedDate
        {
            get
            {
                return DateTime.Now;
            }
            set
            {

            }
        }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
