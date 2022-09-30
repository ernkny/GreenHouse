namespace YesilEv.Core.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProcess")]
    public partial class UserProcess
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public int? SituationId { get; set; }

        public int? AppStarCount { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Product Product { get; set; }

        public virtual Situation Situation { get; set; }

        public virtual User User { get; set; }
    }
}
