using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer.Models;

public partial class TaskProyectContext : DbContext
{
    public TaskProyectContext()
    {
    }

    public TaskProyectContext(DbContextOptions<TaskProyectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatEstatus> CatEstatuses { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ShaggyMR\\SQLEXPRESS01;Database=TaskProyect;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatEstatus>(entity =>
        {
            entity.HasKey(e => e.IdEstatus).HasName("PK__Cat_Esta__B32BA1C77757D938");

            entity.ToTable("Cat_Estatus");

            entity.Property(e => e.NombreEstatos)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tareas__EADE90985C986374");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstatusNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdEstatus)
                .HasConstraintName("FK__Tareas__IdEstatu__4D94879B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Tareas__IdUsuari__6E01572D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF977D1E8312");

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
