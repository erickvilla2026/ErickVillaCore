using System;
using System.Collections.Generic;

namespace DL;

public partial class ProductoDepto1
{
    public int? IdProducto { get; set; }

    public int? IdDepto { get; set; }

    public virtual Departamentos1? IdDeptoNavigation { get; set; }

    public virtual Productos1? IdProductoNavigation { get; set; }
}
