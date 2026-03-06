using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Class1
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (DL.PruebaTecnicalContext context = new DL.PruebaTecnicalContext())
            {
                result.Objects = new List<object>();
                var GetAll = context.Capturas.FromSqlRaw("EXEC CapGetAll").ToList();

                foreach (var item in GetAll)
                {
                    ML.Captura captura = new ML.Captura();
                    captura.Id = item.Id;
                    captura.Nombre = item.Nombre;
                    captura.Paterno = item.Paterno;
                    captura.Materno = item.Materno;
                    // captura.FechaNacimiento = item.FechaNacimiento;
                    captura.Sexo = item.Sexo;
                    captura.EstadoNacimiento = item.EstadoNacimiento;
                    captura.Telefono = item.Telefono;
                    captura.DireccionActual = item.DireccionActual;


                    captura.Calle = item.Calle;

                    result.Objects.Add(captura);
                }
            }
            return result;
        }

        public static ML.Result GetById(int Id)
        {
            ML.Result result = new ML.Result();

            using (DL.PruebaTecnicalContext context = new DL.PruebaTecnicalContext())
            {

                var getById = context.Capturas
                                              .FromSqlInterpolated($"EXEC CapGetById {Id}")
                                              .AsEnumerable()
                                              .FirstOrDefault();
                var item = getById;



                ML.Captura captura = new ML.Captura();

                captura.Id = item.Id;
                captura.Nombre = item.Nombre;
                captura.Paterno = item.Paterno;
                captura.Materno = item.Materno;
                // captura.FechaNacimiento = item.FechaNacimiento;
                captura.Sexo = item.Sexo;
                captura.EstadoNacimiento = item.EstadoNacimiento;
                captura.Telefono = item.Telefono;
                captura.DireccionActual = item.DireccionActual;

                captura.Calle = item.Calle;

                result.Object = captura;



                //var GetByID = context.Capturas.FromSqlRaw('"EXEC CapGetById"++ Id')).ToList();

            }


            return result;
        }

        public static ML.Result Delete(int Id)
        {
            ML.Result result = new ML.Result();

            using (DL.PruebaTecnicalContext context = new DL.PruebaTecnicalContext())
            {
                var getById = context.Database.ExecuteSqlRaw($"EXEC CapDelete {Id}");

                if(getById > 0)
                {
                    result.Correct = true;
                }
            }


            return result;
        }
        public static ML.Result Update()
        {
            ML.Result result = new ML.Result();

            return result;
        }


    }
}
