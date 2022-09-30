using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using YesilEv.DAL.Concrete;
using YesilEv.Entity.Concrete.DTO;
using YesilEv.Validation.Abstract;

namespace YesilEv.Validation.Concrete
{
    public class ProductValidator : AbstractProductValidator<ProductDTO>
    {
        public List<string> SubstancesCleared;
        public bool isValid=false;
        public ProductValidator()
        {
                
        }
        public ProductValidator(ProductDTO data, List<string> substances)
        {
            if (StringEmptyOrWhiteSpace(data) && SubstancesValidate(substances))
            {
                if ( IsChildCategory(data) && SubstancesCleared.Count>0)
                {
                    isValid = true;
                }
            }
        }

        public override bool IsChildCategory(ProductDTO data)
        {
            CategoryDal catDal = new CategoryDal();
            var categoryIdResult=catDal.GetAll(x => x.Id == data.CategoryId).FirstOrDefault();
            if (categoryIdResult is null)
            {
                return false;
            }
            else if (categoryIdResult.ParentId == 0 ||data.CompanyId==0)
            {
                return false;
            }
            return true;
        }

        public override bool StringEmptyOrWhiteSpace(ProductDTO data)
        {
            if (String.IsNullOrEmpty(data.Name)
                || String.IsNullOrEmpty(data.CompanyId.ToString())
                || String.IsNullOrEmpty(data.CategoryId.ToString())
                )
            { 
                return false;
            }
            else
            {
                return true;
            }

        }
        public override bool SubstancesValidate(List<string> substances)
        {
            SubstancesCleared = new List<string>();
            if (substances.Count <= 0)
            {
                return false;
            }

            foreach (var item in substances)
            {
                if (item == "")
                {

                }
                else
                {
                    SubstancesCleared.Add(item);
                }
            }
            return true;
        }
    }
}
