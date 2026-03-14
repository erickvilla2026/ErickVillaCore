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

                    var usuarioDTO = context.UsuarioGetAllDTO.FromSqlRaw("EXEC UsuarioGetAll").ToList();

                    //var getAll = context.Usuarios.FromSqlRaw("EXEC UsuarioGetAll").ToList();
                    foreach (var item in usuarioDTO)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.Nombre = item.Nombre;
                        usuario.ApellidoPaterno = item.ApellidoPaterno;
                        usuario.ApellidoMaterno = item.ApellidoMaterno;
                        usuario.Email = item.Email;
                        usuario.UserName = item.UserName;
                        usuario.Password = item.Password;
                        usuario.FechaNacimiento = item.FechaNacimiento.ToDateTime(TimeOnly.MinValue);
                        usuario.Sexo = item.Sexo;
                        usuario.Telefono = item.Telefono;
                        usuario.Celular = item.Celular;
                        usuario.CURP = item.Curp;
                        usuario.Estatus = item.Estatus;



                        var direccionesUsuario = context.UsuarioDireccionesDTO.FromSqlRaw($"UsuarioDirecciones {usuario.IdUsuario}").ToList();


                        foreach (var usuarioDireccion in direccionesUsuario)
                        {
                            ML.Direccion direccion = new ML.Direccion();

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

                            usuario.Direccion.Colonia.IdColonia = usuarioDireccion.IdColonia;
                            usuario.Direccion.calle = usuarioDireccion.Calle;
                            usuario.Direccion.NumeroExterior = usuarioDireccion.NumeroExterior;
                            usuario.Direccion.NumeroInterior = usuarioDireccion.NumeroInterior;

                            usuario.Direccion.Direcciones = new List<object>();



                            usuario.Direccion.Direcciones?.Add(usuarioDireccion);
                        }

                        result.Objects.Add(usuario);


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                    foreach (DL.Usuario item in usuarioGetByID)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.Nombre = item.Nombre;
                        usuario.ApellidoPaterno = item.ApellidoPaterno;
                        usuario.ApellidoMaterno = item.ApellidoMaterno;
                        usuario.Email = item.Email;
                        usuario.UserName = item.UserName;
                        usuario.Password = item.Password;
                        //usuario.FechaNacimiento = item.FechaNacimiento.ToDateTime;
                        usuario.Sexo = item.Sexo;
                        usuario.Telefono = item.Telefono;
                        usuario.Celular = item.Celular;
                        usuario.CURP = item.Curp;
                        usuario.Estatus = item.Estatus;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();


                        //var direccionesItem = context.DireccionDTO.FromSqlRaw($"EXEC DireccionGetByIdUsuario {usuario.IdUsuario}");


                        //foreach (var item1 in direccionesItem)
                        //{
                        //    usuario.Direccion.Colonia.IdColonia = item1.IdColonia;
                        //    usuario.Direccion.Colonia.Municipio.IdMunicipio = item1.IdMunicipio;
                        //    usuario.Direccion.Colonia.Municipio.Estado.IdEstado = item1.IdEstado;
                        //    Console.WriteLine(item1.Municipio);
                        //}







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
