using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BulutBilisim.Models
{
    public partial class BulutBilisimContext : DbContext
    {
        public BulutBilisimContext()
        {
        }

        public BulutBilisimContext(DbContextOptions<BulutBilisimContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblmusteri> Tblmusteris { get; set; }
        public virtual DbSet<Tblurun> Tbluruns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\FATIH;Database=BulutBilisim;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Tblmusteri>(entity =>
            {
                entity.HasKey(e => e.Musteriid);

                entity.ToTable("TBLMUSTERI");

                entity.Property(e => e.Musteriid).HasColumnName("MUSTERIID");

                entity.Property(e => e.Musteriad)
                    .HasMaxLength(30)
                    .HasColumnName("MUSTERIAD");

                entity.Property(e => e.Musteriemail)
                    .HasMaxLength(50)
                    .HasColumnName("MUSTERIEMAIL");

                entity.Property(e => e.Musterisifre)
                    .HasMaxLength(10)
                    .HasColumnName("MUSTERISIFRE")
                    .IsFixedLength(true);

                entity.Property(e => e.Musterisoyad)
                    .HasMaxLength(30)
                    .HasColumnName("MUSTERISOYAD");

                entity.Property(e => e.Musteritelefon)
                    .HasMaxLength(11)
                    .HasColumnName("MUSTERITELEFON");
            });

            modelBuilder.Entity<Tblurun>(entity =>
            {
                entity.HasKey(e => e.Urunid);

                entity.ToTable("TBLURUN");

                entity.Property(e => e.Urunid).HasColumnName("URUNID");

                entity.Property(e => e.Urunad)
                    .HasMaxLength(30)
                    .HasColumnName("URUNAD");

                entity.Property(e => e.Urunfiyat)
                    .HasMaxLength(50)
                    .HasColumnName("URUNFIYAT");

                entity.Property(e => e.Urunfoto1)
                    .HasMaxLength(300)
                    .HasColumnName("URUNFOTO1");

                entity.Property(e => e.Urunfoto2)
                    .HasMaxLength(300)
                    .HasColumnName("URUNFOTO2");

                entity.Property(e => e.Urunfoto3)
                    .HasMaxLength(300)
                    .HasColumnName("URUNFOTO3");

                entity.Property(e => e.Urunkategori)
                    .HasMaxLength(50)
                    .HasColumnName("URUNKATEGORI");

                entity.Property(e => e.Urunmarka)
                    .HasMaxLength(50)
                    .HasColumnName("URUNMARKA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
