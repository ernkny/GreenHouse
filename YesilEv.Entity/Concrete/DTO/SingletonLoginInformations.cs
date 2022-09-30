using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class SingletonLoginInformations
    {
        private SingletonLoginInformations() { }
        private static SingletonLoginInformations instance = null;
        public static SingletonLoginInformations LoginInformationWithSingleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonLoginInformations();
                }
                return instance;
            }
        }
        /* singleton metot kullanımı
        public static SingletonLoginInformations Instance()
        {
            if(instance == null)
            {
                instance = new SingletonLoginInformations();
            }
            return instance;
        }*/
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string KayıtTarihi { get; set; }
        public int Id { get; set; }
    }
}
