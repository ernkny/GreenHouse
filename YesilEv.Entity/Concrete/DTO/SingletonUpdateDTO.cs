using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class SingletonUpdateDTO
    {
        private SingletonUpdateDTO() { }
        private static SingletonUpdateDTO instance = null;
        public static SingletonUpdateDTO SingletonUpdate
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonUpdateDTO();
                }
                return instance;
            }
        }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public int CompanyId { get; set; }
        public int CategoryId { get; set; }
        public List<string> Substances { get; set; }

    }
}
