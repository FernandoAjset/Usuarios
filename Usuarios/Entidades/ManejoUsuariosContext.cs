using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Usuarios.Entidades
{
    public partial class ManejoUsuariosContext : DbContext
    {
        public ManejoUsuariosContext()
        {
        }

        public ManejoUsuariosContext(DbContextOptions<ManejoUsuariosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Contrasenia).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
