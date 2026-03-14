using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();



            usuario.Usuarios = result.Objects;

           





            return View(usuario);
        }


        public static ML.Result UsuarioGetById()
        {
            ML.Result result = new ML.Result();

            return result;
        }
        /*
        public ActionResult Form(int IdUsuario)
        {

            ML.Result result = BL.Usuario.GetById(IdUsuario);
            ML.Usuario usuario = new ML.Usuario();

            usuario = (ML.Usuario)result.Object;

            ML.Result result1 = BL.Estado.EstadoGetAll();
            usuario.Direccion.Colonia.Municipio.Estado.Estados = result1.Objects;



            return View(usuario);
        }

        */

    }
}
