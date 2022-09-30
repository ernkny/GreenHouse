using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHouseEntityy.Concrete.DTO
{
    public class RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SocialMediaAcc { get; set; }
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
