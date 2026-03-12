using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static ML.Result EstadoGetAll()
        {
            ML.Result result = new ML.Result();

            using (DL.PruebaConexionContext context = new DL.PruebaConexionContext())
            {

                var estadoGetAll = context.Estados.FromSqlRaw("EXEC EstadoGetAll").ToList();

                result.Objects = new List<object>();

                foreach (var item in estadoGetAll)
                {
                    ML.Estado estado = new ML.Estado();

                    estado.IdEstado = item.IdEstado;
                    estado.Nombre = item.Nombre;

                    result.Objects.Add(estado);


                }

            }


            return result;
        }
    }
}
