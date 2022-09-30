using GreenHouseEntityy.Concrete.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesilEv.DAL.Concrete;
using YesilEv.Entity.Concrete.DTO;
using YesilEv.Validation.Abstract;

namespace YesilEv.Validation.Concrete
{
    public class RegisterValidator : AbstractRegisterValidator<RegisterDTO>
    {
        public bool isValid = false;
        public RegisterValidator()
        {

        }
        public RegisterValidator(RegisterDTO reg)
        {
            if (IsEmailExist(reg) && StringEmptyOrWhiteSpace(reg))
            {
                isValid = true;
            }
        }
        public override bool IsEmailExist(RegisterDTO data)
        {
            UserDal userDal = new UserDal();
            var emailControl=userDal.GetAll(x => x.Email == data.Email);
            if (emailControl.Count>0)
            {
                return false;
            }
            return true;
        }

        public override bool StringEmptyOrWhiteSpace(RegisterDTO data)
        {
            if (String.IsNullOrEmpty(data.Name)
                || String.IsNullOrEmpty(data.Email)
                || String.IsNullOrEmpty(data.Password)
                || String.IsNullOrEmpty(data.Surname)
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
