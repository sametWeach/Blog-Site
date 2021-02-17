namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Yorum")]
    public partial class Yorum
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(500)]
        public string icerik { get; set; }

        public int MakaleID { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public Guid YazarID { get; set; }

        public bool Aktif { get; set; }

        public virtual kullanici kullanici { get; set; }

        public virtual makale makale { get; set; }
    }
}
