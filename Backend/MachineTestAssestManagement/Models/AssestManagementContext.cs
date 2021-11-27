using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MachineTestAssestManagement.Models
{
    public partial class AssestManagementContext : DbContext
    {
        public AssestManagementContext()
        {
        }

        public AssestManagementContext(DbContextOptions<AssestManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetMasterTable> AssetMasterTable { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<UserRegistration> UserRegistration { get; set; }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=ROHITDEEPAK\\SQLEXPRESS; Initial Catalog=AssestManagement; Integrated security=True");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetMasterTable>(entity =>
            {
                entity.HasKey(e => e.AmId)
                    .HasName("PK__AssetMas__B95A8ED0433A62A9");

                entity.Property(e => e.AmId).HasColumnName("am_id");

                entity.Property(e => e.AmAddId).HasColumnName("am_add_id");

                entity.Property(e => e.AmAtypeId)
                    .HasColumnName("am_atype_id")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmFrom)
                    .HasColumnName("am_from")
                    .HasColumnType("date");

                entity.Property(e => e.AmMakerId).HasColumnName("am_maker_id");

                entity.Property(e => e.AmModel)
                    .HasColumnName("am_model")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AmMyyear)
                    .HasColumnName("am_myyear")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AmPdate)
                    .HasColumnName("am_pdate")
                    .HasColumnType("date");

                entity.Property(e => e.AmSnumber)
                    .HasColumnName("am_snumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AmTo)
                    .HasColumnName("am_to")
                    .HasColumnType("date");

                entity.Property(e => e.AmWarranty)
                    .HasColumnName("am_Warranty")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Login__A7C7B6F8FB37D2E7");

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRegistration>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserRegi__B51D3DEAE46F74E9");

                entity.Property(e => e.UId).HasColumnName("u_id");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LId).HasColumnName("l_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.UserRegistration)
                    .HasForeignKey(d => d.LId)
                    .HasConstraintName("FK__UserRegist__l_id__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
