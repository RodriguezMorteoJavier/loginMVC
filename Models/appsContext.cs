using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_users.Models
{
    public partial class appsContext : DbContext
    {
        public appsContext()
        {
        }

        public appsContext(DbContextOptions<appsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Datos> Datos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=apps;Username=postgres;Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

      
            
            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Idroles);

                entity.ToTable("roles");

                entity.Property(e => e.Idroles)
                    .HasColumnName("idroles")
                    .HasDefaultValueSql("nextval('roles_rol_seq'::regclass)");

                entity.Property(e => e.Nombrerol)
                    .HasColumnName("nombrerol")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.HasKey(e => e.Idur);

                entity.ToTable("usuario_rol");

                entity.Property(e => e.Idur)
                    .HasColumnName("idur")
                    .HasDefaultValueSql("nextval('usuario_rol_id_seq'::regclass)");

                entity.Property(e => e.Idrol).HasColumnName("idrol");

                entity.Property(e => e.Idusuario).HasColumnName("idusuario");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.Idrol)
                    .HasConstraintName("fk_idrol");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.UsuarioRol)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_idusuario");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("usuarios");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(45);

                entity.Property(e => e.Pass)
                    .HasColumnName("pass")
                    .HasMaxLength(45);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(45);
            });

            modelBuilder.HasSequence<int>("roles_rol_seq");

            modelBuilder.HasSequence<int>("usuario_rol_id_seq");
        }
    }
}
