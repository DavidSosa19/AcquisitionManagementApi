using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AcquisitionManagementAPI.Models;

public partial class Acquisition
{
    public int Id { get; set; }

    public decimal Presupuesto { get; set; }

    public int Unidad { get; set; }

    public int TipoBienServicio { get; set; }

    public decimal Cantidad { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal ValorTotal { get; set; }

    public DateOnly FechaAdquisicion { get; set; }

    public int Proveedor { get; set; }

    public List<string> Documentacion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [JsonIgnore]
    public virtual Provider? ProveedorNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual AssetServiceType? TipoBienServicioNavigation { get; set; } = null!;

    [JsonIgnore]
    public virtual Unit? UnidadNavigation { get; set; } = null!;
}
