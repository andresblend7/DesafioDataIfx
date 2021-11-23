using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DesafioDataIfx.Infraestructure.Providers.SqlServer.DataBase
{
    public partial class HogwardsDataIfxContext : DbContext
    {
        public HogwardsDataIfxContext()
        {
        }

        public HogwardsDataIfxContext(DbContextOptions<HogwardsDataIfxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dic_Houses> Dic_Houses { get; set; }
        public virtual DbSet<Dic_States> Dic_States { get; set; }
        public virtual DbSet<Tra_HouseRequest> Tra_HouseRequest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=HogwardsDataIfx;Integrated Security= true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dic_Houses>(entity =>
            {
                entity.HasKey(e => e.hou_Id);

                entity.Property(e => e.hou_Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dic_States>(entity =>
            {
                entity.HasKey(e => e.sta_Id);

                entity.Property(e => e.sta_Name)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tra_HouseRequest>(entity =>
            {
                entity.HasKey(e => e.hre_Id);

                entity.HasComment("histórico de solicitudes");

                entity.Property(e => e.hre_CreationDate).HasColumnType("datetime");

                entity.Property(e => e.hre_LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.hre_Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.hre_IdHouseFkNavigation)
                    .WithMany(p => p.Tra_HouseRequest)
                    .HasForeignKey(d => d.hre_IdHouseFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_HouseRequest_Dic_Houses");

                entity.HasOne(d => d.hre_IdStateFkNavigation)
                    .WithMany(p => p.Tra_HouseRequest)
                    .HasForeignKey(d => d.hre_IdStateFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_HouseRequest_Dic_States");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
