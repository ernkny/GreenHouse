namespace YesilEv.Core.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Picture")]
    public partial class Picture
    {
        public int Id { get; set; }

        public string PicturePath { get; set; }

        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
