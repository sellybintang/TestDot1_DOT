using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestDot1_DOT.Repositories.Entities
{
    public partial class Test_DOTContext : DbContext
    {
        public Test_DOTContext()
        {
        }

        public Test_DOTContext(DbContextOptions<Test_DOTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbliDataPinjaman> TbliDataPinjamen { get; set; } = null!;
        public virtual DbSet<TblsBuku> TblsBukus { get; set; } = null!;
        public virtual DbSet<TblsUser> TblsUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SELLY-ONE-CODE\\SQLEXPRESS;Database=Test_DOT;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbliDataPinjaman>(entity =>
            {
                entity.ToTable("TBLI_Data_Pinjaman");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");

                entity.Property(e => e.DeletedDate).HasColumnName("Deleted_Date");

                entity.Property(e => e.KodeBuku)
                    .HasMaxLength(50)
                    .HasColumnName("Kode_Buku");

                entity.Property(e => e.KodeSiswa)
                    .HasMaxLength(50)
                    .HasColumnName("Kode_Siswa");

                entity.Property(e => e.PinjamanBukuId).HasColumnName("Pinjaman_Buku_Id");

                entity.Property(e => e.UpdatedDate).HasColumnName("Updated_Date");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.WaktuPengembalian).HasColumnName("Waktu_Pengembalian");

                entity.Property(e => e.WaktuPinjaman).HasColumnName("Waktu_Pinjaman");

                entity.HasOne(d => d.PinjamanBuku)
                    .WithMany(p => p.TbliDataPinjamen)
                    .HasForeignKey(d => d.PinjamanBukuId)
                    .HasConstraintName("FK_TBLI_Data_Pinjaman_TBLI_Data_Pinjaman");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbliDataPinjamen)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TBLI_Data_Pinjaman_TBLS_User");
            });

            modelBuilder.Entity<TblsBuku>(entity =>
            {
                entity.ToTable("TBLS_Buku");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");

                entity.Property(e => e.DeletedDate).HasColumnName("Deleted_Date");

                entity.Property(e => e.KodeBuku)
                    .HasMaxLength(50)
                    .HasColumnName("Kode_Buku");

                entity.Property(e => e.NamaBuku)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_Buku");

                entity.Property(e => e.Penerbit).HasMaxLength(50);

                entity.Property(e => e.TahunPenerbit)
                    .HasMaxLength(50)
                    .HasColumnName("Tahun_Penerbit");

                entity.Property(e => e.UpdatedDate).HasColumnName("Updated_Date");
            });

            modelBuilder.Entity<TblsUser>(entity =>
            {
                entity.ToTable("TBLS_User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AlamatRumah)
                    .HasMaxLength(200)
                    .HasColumnName("Alamat_Rumah");

                entity.Property(e => e.CreatedDate).HasColumnName("Created_Date");

                entity.Property(e => e.DeletedDate).HasColumnName("Deleted_Date");

                entity.Property(e => e.KodeSiswa)
                    .HasMaxLength(50)
                    .HasColumnName("Kode_Siswa");

                entity.Property(e => e.NamaLengkap)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_Lengkap");

                entity.Property(e => e.NoTelp)
                    .HasMaxLength(50)
                    .HasColumnName("No_Telp");

                entity.Property(e => e.TanggalLahir)
                    .HasColumnType("date")
                    .HasColumnName("Tanggal_Lahir");

                entity.Property(e => e.UpdatedDate).HasColumnName("Updated_Date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
