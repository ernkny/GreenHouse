namespace YesilEv.Core.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleUser")]
    public partial class RoleUser
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? RolId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? isActive { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
