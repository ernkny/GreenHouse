using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class WhoHasHowManyBlacklistedProductsAndHowManyFavoriteProductsDTO
    {
        public string Username { get; set; }
        public int BlockQuantity { get; set; }
        public int FavoriteQuantity { get; set; }
    }
}
