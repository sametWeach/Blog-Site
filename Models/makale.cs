namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("makale")]
    public partial class makale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public makale()
        {
            Yorum = new HashSet<Yorum>();
            etiket = new HashSet<etiket>();
            resim1 = new HashSet<resim>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [AllowHtml]
        [Required]
        public string Icerik { get; set; }

        public DateTime YayinTarihi { get; set; }

        public int KategoriID { get; set; }

        public int MakaleTipID { get; set; }

        public Guid YazarID { get; set; }

        public int KapakResimID { get; set; }

        public int Goruntulenme { get; set; }

        public int Begeni { get; set; }

        public bool Aktif { get; set; }

        public virtual kategori kategori { get; set; }

        public virtual kullanici kullanici { get; set; }

        public virtual MakaleTip MakaleTip { get; set; }

        public virtual resim resim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Yorum> Yorum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<etiket> etiket { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resim> resim1 { get; set; }
    }
}
