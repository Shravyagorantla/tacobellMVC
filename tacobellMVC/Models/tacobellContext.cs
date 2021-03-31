using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace tacobellMVC.Models
{
    public partial class tacobellContext : DbContext
    {
        public tacobellContext()
        {
        }

        public tacobellContext(DbContextOptions<tacobellContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodDetail> FoodDetails { get; set; }
        public virtual DbSet<Nutrition> Nutritions { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=tacobell;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<FoodDetail>(entity =>
            {
                entity.HasKey(e => e.FoodId)
                    .HasName("PK__FoodDeta__856DB3EBC0A46027");

                entity.Property(e => e.FoodId).ValueGeneratedNever();

                entity.Property(e => e.FoodName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imageurl)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("imageurl");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.ToTable("Nutrition");

                entity.Property(e => e.NutritionId).ValueGeneratedNever();

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Dairy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FruitorVegetable)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Grain)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("grain");

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.ProteinClassification)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sodium).HasColumnName("sodium");

                entity.Property(e => e.Totalsugar).HasColumnName("totalsugar");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Nutritions)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__Nutrition__FoodI__3D5E1FD2");
            });

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.ToTable("Registration");

                entity.Property(e => e.RegistrationId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
