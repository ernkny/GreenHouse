namespace YesilEv.Core.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleAuthority")]
    public partial class RoleAuthority
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public int? AuthorityId { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public virtual Authority Authority { get; set; }

        public virtual Role Role { get; set; }
    }
}
