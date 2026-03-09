using System;
using System.Collections.Generic;

namespace DL;

public partial class Productos1
{
    public int IdProducto { get; set; }

    public string? DescProducto { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public int? Activo { get; set; }

    public int? IdDepto { get; set; }

    public virtual Departamentos1? IdDeptoNavigation { get; set; }
}
