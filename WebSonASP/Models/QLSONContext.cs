using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebSonASP.Models
{
    public partial class QLSONContext : DbContext
    {
        public QLSONContext()
        {
        }

        public QLSONContext(DbContextOptions<QLSONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baiviet> Baiviets { get; set; }
        public virtual DbSet<Loaison> Loaisons { get; set; }
        public virtual DbSet<Mauson> Mausons { get; set; }
        public virtual DbSet<Son> Sons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ASUSTUF\\SQLEXPRESS;Database=QLSON;Trusted_Connection=True;");
            }//"Server=ASUSTUF\\SQLEXPRESS;Database=qlhv;Trusted_Connection=True;"
        }//Data Source=SQL8004.site4now.net;Initial Catalog=db_a8f9b6_lesonhai0339;User Id=db_a8f9b6_lesonhai0339_admin;Password=hai09871825460;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baiviet>(entity =>
            {
                entity.HasKey(e => e.Mabaiviet);

                entity.ToTable("baiviet");

                entity.Property(e => e.Mabaiviet)
                    .HasMaxLength(10)
                    .HasColumnName("mabaiviet")
                    .IsFixedLength(true);

                entity.Property(e => e.Noidung)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("noidung");

                entity.Property(e => e.Tenbaiviet)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tenbaiviet");
            });

            modelBuilder.Entity<Loaison>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("loaison");

                entity.Property(e => e.Maloai)
                    .HasMaxLength(10)
                    .HasColumnName("maloai")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenloai)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Mauson>(entity =>
            {
                entity.HasKey(e => e.Mason);

                entity.ToTable("mauson");

                entity.Property(e => e.Mason)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mason");

                entity.Property(e => e.Maloai)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("maloai")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenmau)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("tenmau");

                entity.HasOne(d => d.MaloaiNavigation)
                    .WithMany(p => p.Mausons)
                    .HasForeignKey(d => d.Maloai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_mauson_loaison");
            });

            modelBuilder.Entity<Son>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("son");

                entity.Property(e => e.Chuthich)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("chuthich");

                entity.Property(e => e.Congdung)
                    .HasMaxLength(1000)
                    .HasColumnName("congdung");

                entity.Property(e => e.Hinhanh)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("hinhanh");

                entity.Property(e => e.Huongdansd)
                    .HasMaxLength(1000)
                    .HasColumnName("huongdansd");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("id")
                    .IsFixedLength(true);

                entity.Property(e => e.Loai)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("loai");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("ten");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
