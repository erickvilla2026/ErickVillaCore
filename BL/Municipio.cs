using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result EstadoGetByIdMunicipio(int? IdEstado)
        {
            ML.Result result = new ML.Result();

            using (DL.PruebaConexionContext context = new DL.PruebaConexionContext())
            {
                var municipioItem = context.Municipios
                 .FromSqlRaw("EXEC EstadoGetByMunicipio @IdEstado",
                     new SqlParameter("@IdEstado", IdEstado))
                 .ToList();


                foreach (var municipios in municipioItem)
                {
                    ML.Municipio municipio = new ML.Municipio();
                    municipio.IdMunicipio = municipios.IdMunicipio;
                    municipio.Nombre = municipios.Nombre;

                    result.Objects.Add(municipio);
                }

            }


            return result;
        }

    }
}
