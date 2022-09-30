using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YesilEv.Entity.Concrete.DTO
{
    public class productSubstancesForWhichRiskTypeHasNotBeenDeterminedDTO
    {
        public string SubstanceName { get; set; }

        public override string ToString()
        {
            return SubstanceName.ToString();
        }
    }
}
