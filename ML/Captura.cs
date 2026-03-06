using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public  class Captura
    {

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Sexo { get; set; }
        public string? EstadoNacimiento { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Telefono { get; set; }
        public string? DireccionActual  { get; set; }
        public string? Municipio { get; set; }
        public string? Colonia { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }

        public List<object>? Capturas { get; set; }
    }
}
