namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SiteTakip")]
    public partial class SiteTakip
    {
        [Key]
        [StringLength(500)]
        public string MailAdres { get; set; }

        public Guid? YazarID { get; set; }

        public int? KategoriID { get; set; }

        public virtual kategori kategori { get; set; }

        public virtual kullanici kullanici { get; set; }
    }
}
