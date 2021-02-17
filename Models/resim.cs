namespace MvcBlog.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("resim")]
    public partial class resim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resim()
        {
            kullanici1 = new HashSet<kullanici>();
            makale = new HashSet<makale>();
            makale1 = new HashSet<makale>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(500)]
        public string KucukResimYol { get; set; }

        [StringLength(500)]
        public string OrtaResimYol { get; set; }

        [StringLength(500)]
        public string BuyukResimYol { get; set; }

        [StringLength(50)]
        public string VideoYol { get; set; }

        public Guid EkleyenID { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        public int Goruntulenme { get; set; }

        public int Begeni { get; set; }

        public virtual kullanici kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kullanici> kullanici1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<makale> makale { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<makale> makale1 { get; set; }
    }
}
