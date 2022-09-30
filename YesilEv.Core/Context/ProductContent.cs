namespace YesilEv.Core.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductContent")]
    public partial class ProductContent
    {
        public int Id { get; set; }

        public int? SubstanceId { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }

        public virtual Substance Substance { get; set; }
    }
}
