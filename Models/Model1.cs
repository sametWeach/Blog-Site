namespace MvcBlog.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=MvcContext2")
        {
        }

        public virtual DbSet<etiket> etiket { get; set; }
        public virtual DbSet<kategori> kategori { get; set; }
        public virtual DbSet<kullanici> kullanici { get; set; }
        public virtual DbSet<makale> makale { get; set; }
        public virtual DbSet<MakaleTip> MakaleTip { get; set; }
        public virtual DbSet<resim> resim { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }
        public virtual DbSet<SiteTakip> SiteTakip { get; set; }
        public virtual DbSet<ZiyaretciIPLog> ZiyaretciIPLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<etiket>()
                .HasMany(e => e.makale)
                .WithMany(e => e.etiket)
                .Map(m => m.ToTable("makaleEtiket").MapLeftKey("EtiketID").MapRightKey("MakaleID"));

            modelBuilder.Entity<kategori>()
                .HasMany(e => e.makale)
                .WithRequired(e => e.kategori)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.makale)
                .WithRequired(e => e.kullanici)
                .HasForeignKey(e => e.YazarID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.resim)
                .WithRequired(e => e.kullanici)
                .HasForeignKey(e => e.EkleyenID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.SiteTakip)
                .WithOptional(e => e.kullanici)
                .HasForeignKey(e => e.YazarID);

            modelBuilder.Entity<kullanici>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.kullanici)
                .HasForeignKey(e => e.YazarID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<makale>()
                .HasMany(e => e.Yorum)
                .WithRequired(e => e.makale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<makale>()
                .HasMany(e => e.resim1)
                .WithMany(e => e.makale1)
                .Map(m => m.ToTable("MakaleResim").MapLeftKey("MakaleID").MapRightKey("ResimID"));

            modelBuilder.Entity<MakaleTip>()
                .HasMany(e => e.makale)
                .WithRequired(e => e.MakaleTip)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resim>()
                .HasMany(e => e.kullanici1)
                .WithRequired(e => e.resim1)
                .HasForeignKey(e => e.ResimID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<resim>()
                .HasMany(e => e.makale)
                .WithRequired(e => e.resim)
                .HasForeignKey(e => e.KapakResimID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ZiyaretciIPLog>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);
        }
    }
}
