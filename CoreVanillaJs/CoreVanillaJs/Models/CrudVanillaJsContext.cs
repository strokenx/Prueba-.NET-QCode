using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreVanillaJs.Models
{
    public partial class CrudVanillaJsContext : DbContext
    {
        public CrudVanillaJsContext()
        {
        }

        public CrudVanillaJsContext(DbContextOptions<CrudVanillaJsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Automovil> Automovil { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CrudVanillaJs;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automovil>(entity =>
            {
                entity.ToTable("Automovil");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.Property(e => e.Marca)
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
