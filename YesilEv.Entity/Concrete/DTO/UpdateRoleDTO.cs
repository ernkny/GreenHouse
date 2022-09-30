using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class UpdateRoleDTO
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
