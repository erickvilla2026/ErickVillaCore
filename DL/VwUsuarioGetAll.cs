using System;
using System.Collections.Generic;

namespace DL;

public partial class VwUsuarioGetAll
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Sexo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Celular { get; set; }

    public string? Curp { get; set; }

    public bool? Estatus { get; set; }

    public int? IdRol { get; set; }

    public byte[]? Imagen { get; set; }

    public string? Calle { get; set; }

    public string? NumeroInterior { get; set; }

    public string? NumeroExterior { get; set; }

    public int? IdEstado { get; set; }

    public int? IdMunicipio { get; set; }

    public int? IdColonia { get; set; }
}
