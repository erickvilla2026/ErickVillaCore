using System;
using System.Collections.Generic;

namespace DL;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Rfc { get; set; }

    public DateOnly? FechaRegistro { get; set; }
}
