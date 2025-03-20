using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AcquisitionManagementAPI.Models;

public partial class AcquisitiondbContext : DbContext
{
    public AcquisitiondbContext()
    {
    }

    public AcquisitiondbContext(DbContextOptions<AcquisitiondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acquisition> Acquisitions { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<AssetServiceType> AssetServiceTypes { get; set; }

    public virtual DbSet<Unit> Unities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acquisition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("adquisiciones_pkey");

            entity.ToTable("adquisiciones");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cantidad)
                .HasPrecision(20)
                .HasColumnName("cantidad");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.Documentacion)
                .HasColumnType("character varying[]")
                .HasColumnName("documentacion");
            entity.Property(e => e.FechaAdquisicion).HasColumnName("fecha_adquisicion");
            entity.Property(e => e.Presupuesto)
                .HasPrecision(30)
                .HasColumnName("presupuesto");
            entity.Property(e => e.Proveedor).HasColumnName("proveedor");
            entity.Property(e => e.TipoBienServicio).HasColumnName("tipo_bien_servicio");
            entity.Property(e => e.Unidad).HasColumnName("unidad");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(30)
                .HasColumnName("valor_total");
            entity.Property(e => e.ValorUnitario)
                .HasPrecision(30)
                .HasColumnName("valor_unitario");

            entity.HasOne(d => d.ProveedorNavigation).WithMany(p => p.Adquisiciones)
                .HasForeignKey(d => d.Proveedor)
                .HasConstraintName("fkey_proveedores");

            entity.HasOne(d => d.TipoBienServicioNavigation).WithMany(p => p.Adquisiciones)
                .HasForeignKey(d => d.TipoBienServicio)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_tipos_bien_servicio");

            entity.HasOne(d => d.UnidadNavigation).WithMany(p => p.Adquisiciones)
                .HasForeignKey(d => d.Unidad)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_unidad");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("proveedores_pkey");

            entity.ToTable("proveedores");

            entity.HasIndex(e => e.Nombre, "proveedores_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<AssetServiceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_bien_servicio_pkey");

            entity.ToTable("tipos_bien_servicio");

            entity.HasIndex(e => e.Nombre, "tipos_bien_servicio_nombre_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("unidad_pkey");

            entity.ToTable("unidades");

            entity.HasIndex(e => e.Nombre, "unidad_nombre_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityColumn();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
