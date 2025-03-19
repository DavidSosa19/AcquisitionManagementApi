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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acquisition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("acquisitions_pkey");

            entity.ToTable("acquisitions");

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
            entity.Property(e => e.Proveedor)
                .HasMaxLength(100)
                .HasColumnName("proveedor");
            entity.Property(e => e.TipoBienServicio)
                .HasMaxLength(100)
                .HasColumnName("tipo_bien_servicio");
            entity.Property(e => e.Unidad)
                .HasMaxLength(255)
                .HasColumnName("unidad");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.ValorTotal)
                .HasPrecision(30)
                .HasColumnName("valor_total");
            entity.Property(e => e.ValorUnitario)
                .HasPrecision(30)
                .HasColumnName("valor_unitario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
