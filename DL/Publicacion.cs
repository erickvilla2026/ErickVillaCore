using System;
using System.Collections.Generic;

namespace DL;

public partial class Publicacion
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Contenido { get; set; }

    public string? Autor { get; set; }

    public DateOnly FechaCreacion { get; set; }

    public DateOnly? FechaActualizacion { get; set; }
}
