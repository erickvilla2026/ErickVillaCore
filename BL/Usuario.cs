using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.PruebaConexionContext context = new DL.PruebaConexionContext())
                {
                    result.Objects = new List<object>();

                    var getAll = context.Usuarios.FromSqlRaw("EXEC UsuarioGetAll").ToList();
                    foreach (var item in getAll)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.Nombre = item.Nombre;
                        usuario.ApellidoPaterno = item.ApellidoPaterno;
                        usuario.ApellidoMaterno = item.ApellidoMaterno;
                        usuario.Email = item.Email;
                        usuario.UserName = item.UserName;
                        usuario.Password = item.Password;
                        usuario.FechaNacimiento = item.FechaNacimiento.ToDateTime(TimeOnly.MinValue); usuario.Sexo = item.Sexo;
                        usuario.Telefono = item.Telefono;
                        usuario.Celular = item.Celular;
                        usuario.CURP = item.Curp;
                        usuario.Estatus = item.Estatus;

                        result.Objects.Add(usuario);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public static ML.Result GetById(int Id)
        {
            ML.Result result = new ML.Result();


            try
            {
                using (DL.PruebaConexionContext context = new DL.PruebaConexionContext())
                {
                    var usuarioGetByID = context.Usuarios.FromSqlRaw($"EXEC UsuarioGetById {Id}").ToList();
                    foreach (var item in usuarioGetByID)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.Nombre = item.Nombre;
                        usuario.ApellidoPaterno = item.ApellidoPaterno;
                        usuario.ApellidoMaterno = item.ApellidoMaterno;
                        usuario.Email = item.Email;
                        usuario.UserName = item.UserName;
                        usuario.Password = item.Password;
                        usuario.FechaNacimiento = item.FechaNacimiento.ToDateTime(TimeOnly.MinValue); usuario.Sexo = item.Sexo;
                        usuario.Telefono = item.Telefono;
                        usuario.Celular = item.Celular;
                        usuario.CURP = item.Curp;
                        usuario.Estatus = item.Estatus;

                        result.Object = usuario;
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            using (DL.PruebaConexionContext context = new DL.PruebaConexionContext())
            {
                var usuarioGetById = context.Usuarios.FromSqlRaw("EXEC UsuarioGetById ",
                    new SqlParameter("@Nombre", usuario.Nombre))
                    .AsEnumerable()
                    .FirstOrDefault();




            }
            return result;
        }



    }
}
