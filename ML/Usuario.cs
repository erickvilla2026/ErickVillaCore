using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Sexo { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? CURP { get; set; }
        public bool? Estatus { get; set; }
        //creation  to img
        public byte[]? Imagen { get; set; }
        //Creacion lista de objetos de usuarios en plural
        public List<object>? Usuarios { get; set; }
        //id rol que se va a sustituir con el  nuevo modelos que vamos a pasar la informacion de las redireciones 
        public  int? IdRol{ get; set; }
        public Rol Rol { get; set; } = new Rol();
        public Direccion Direccion { get; set; } = new Direccion();
        // Rol
        public string? ContentType { get; set; }
        public List<object> Correcto { get; set; } = new List<object>();
        public List<object> Error { get; set; } = new List<object>();
    }
}
