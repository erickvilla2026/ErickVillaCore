using System;
using System.Collections.Generic;

namespace DL;

public partial class Departamentos1
{
    public int IdDepto { get; set; }

    public string? DescDepto { get; set; }

    public int? Activo { get; set; }

    public virtual ICollection<Productos1> Productos1s { get; set; } = new List<Productos1>();
}
