using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public string? calle { get; set; }
        public string? NumeroInterior { get; set; }
        public string? NumeroExterior { get; set; }
        public Colonia? Colonia { get; set; }
        public List<object>? Direcciones { get; set; }

    }
}
