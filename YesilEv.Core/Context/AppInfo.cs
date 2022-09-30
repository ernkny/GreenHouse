namespace YesilEv.Core.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AppInfo")]
    public partial class AppInfo
    {
        public int Id { get; set; }

        public string AboutUs { get; set; }

        public string Contact { get; set; }

        public string KullanımKosullari { get; set; }

        public long? UygulamaToplamPuanı { get; set; }

        public bool? isActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }
    }
}
