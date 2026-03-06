using System;
using System.Collections.Generic;

namespace DL;

public partial class Captura
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Paterno { get; set; }

    public string? Materno { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }

    public string? EstadoNacimiento { get; set; }

    public string? Telefono { get; set; }

    public string? DireccionActual { get; set; }

    public string? Municipio { get; set; }

    public string? Colonia { get; set; }

    public string? Calle { get; set; }

    public int? Numero { get; set; }
}
