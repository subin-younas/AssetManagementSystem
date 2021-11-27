using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagement.Models
{
    public partial class AssetManagementContext : DbContext
    {
        public AssetManagementContext()
        {
        }

        public AssetManagementContext(DbContextOptions<AssetManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetDefinition> AssetDefinition { get; set; }
        public virtual DbSet<AssetMaster> AssetMaster { get; set; }
        public virtual DbSet<AssetType> AssetType { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=SUBINYOUNAS\\SQLEXPRESS; Initial Catalog=AssetManagement; Integrated security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetDefinition>(entity =>
            {
                entity.HasKey(e => e.AdId)
                    .HasName("PK__AssetDef__CAA4A627B36A98EF");

                entity.Property(e => e.AdId).HasColumnName("ad_id");

                entity.Property(e => e.AdClass)
                    .HasColumnName("ad_class")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdName)
                    .HasColumnName("ad_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AdTypeId).HasColumnName("ad_type_id");

                entity.HasOne(d => d.AdType)
                    .WithMany(p => p.AssetDefinition)
                    .HasForeignKey(d => d.AdTypeId)
                    .HasConstraintName("FK__AssetDefi__ad_ty__2D27B809");
            });

            modelBuilder.Entity<AssetMaster>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED000EB54BB");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAdId).HasColumnName("am_ad_id");

                entity.Property(e => e.AmMakeId).HasColumnName("am_make_id");

                entity.Property(e => e.AmModel)
                    .HasColumnName("am_model")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmSnumber)
                    .HasColumnName("am_snumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmTypeId).HasColumnName("am_type_id");

                entity.HasOne(d => d.AmAd)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmAdId)
                    .HasConstraintName("FK__AssetMast__am_ad__32E0915F");

                entity.HasOne(d => d.AmMake)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmMakeId)
                    .HasConstraintName("FK__AssetMast__am_ma__31EC6D26");

                entity.HasOne(d => d.AmType)
                    .WithMany(p => p.AssetMaster)
                    .HasForeignKey(d => d.AmTypeId)
                    .HasConstraintName("FK__AssetMast__am_ty__30F848ED");
            });

            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasKey(e => e.AtId)
                    .HasName("PK__AssetTyp__61F859884B224667");

                entity.Property(e => e.AtId).HasColumnName("at_id");

                entity.Property(e => e.AtName)
                    .HasColumnName("at_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F811ADF901");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEA1FD3A61B");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__UserRegist__l_id__267ABA7A");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VdId)
                    .HasName("PK__Vendor__277BC6C06C2C3409");

                entity.Property(e => e.VdId).HasColumnName("vd_id");

                entity.Property(e => e.VdAddr)
                    .HasColumnName("vd_addr")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.VdAtypeId).HasColumnName("vd_atype_id");

                entity.Property(e => e.VdFrom)
                    .HasColumnName("vd_from")
                    .HasColumnType("date");

                entity.Property(e => e.VdName)
                    .HasColumnName("vd_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VdTo)
                    .HasColumnName("vd_to")
                    .HasColumnType("date");

                entity.Property(e => e.VdType)
                    .HasColumnName("vd_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.VdAtype)
                    .WithMany(p => p.Vendor)
                    .HasForeignKey(d => d.VdAtypeId)
                    .HasConstraintName("FK__Vendor__vd_atype__300424B4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
