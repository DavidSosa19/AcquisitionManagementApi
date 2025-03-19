using System;
using System.Collections.Generic;

namespace AcquisitionManagementAPI.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Acquisition> Adquisiciones { get; set; } = new List<Acquisition>();
}
