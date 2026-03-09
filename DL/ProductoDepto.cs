using System;
using System.Collections.Generic;

namespace DL;

public partial class ProductoDepto
{
    public int? IdProducto { get; set; }

    public int? IdDepto { get; set; }

    public virtual Departamento? IdDeptoNavigation { get; set; }

    public virtual Producto1? IdProductoNavigation { get; set; }
}
