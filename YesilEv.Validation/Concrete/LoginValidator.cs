using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.Validation.Abstract;

namespace YesilEv.Validation.Concrete
{
    public class LoginValidator : AbstractLoginValidator<LoginDTO>
    {
        public bool isValid = false;
        public LoginValidator(LoginDTO data)
        {
            if (StringEmptyOrWhiteSpace(data))
                isValid = true;
        }

        public override bool StringEmptyOrWhiteSpace(LoginDTO data) //eğer data null ise otomatikman linq sorgusundan null dönmüstür yani ya login ismi ya da pass boştur ya da girilen bilgiler yanlıstır
        {
            if (data == null)
                return false;
            else
                return true;
        }
    }
}