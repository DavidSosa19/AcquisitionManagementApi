using System;
using System.Collections.Generic;

namespace AcquisitionManagementAPI.Models;

public partial class Acquisition
{
    public int Id { get; set; }

    public decimal Presupuesto { get; set; }

    public string Unidad { get; set; } = null!;

    public string TipoBienServicio { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal ValorUnitario { get; set; }

    public decimal ValorTotal { get; set; }

    public DateOnly FechaAdquisicion { get; set; }

    public string Proveedor { get; set; } = null!;

    public List<string> Documentacion { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
