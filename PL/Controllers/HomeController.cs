using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;
using PL.Models;
using System.Diagnostics;

namespace PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ML.Result result = BL.Class1.GetAll();
            ML.Captura captura = new ML.Captura();

            captura.Capturas = result.Objects;

            return View(captura);

            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetAll()
        {
            ML.Result result = BL.Class1.GetAll();
            ML.Captura captura = new ML.Captura();

            captura.Capturas = result.Objects;

            return View(captura);
        }

        public IActionResult Form(int Id)
        {
            ML.Result result = BL.Class1.GetById(Id);
            ML.Captura captura = new ML.Captura();

            var item = (ML.Captura?)result.Object;

            captura.Id = item.Id;
            captura.Nombre = item.Nombre;
            captura.Paterno = item.Paterno;
            captura.Materno = item.Materno;

            return View(captura);
        }

        public IActionResult Delete(int Id)
        {

            ML.Result result = BL.Class1.Delete(Id);

            if (result.Correct)
            {
                Console.WriteLine("se elimino correctamente");
            }

            return RedirectToAction("GetAll");
            //return View();
        }



        public ActionResult UsuarioGetAll()
        {
            ML.Result result = BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();

            //usuario.Direccion = new ML.Direccion();
            //usuario.Direccion.Colonia = new ML.Colonia();
            //usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            //usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();

            usuario.Usuarios = result.Objects;

            return View(usuario);
        }


        public static ML.Result UsuarioGetById()
        {
            ML.Result result = new ML.Result();

            return result;
        }

        public ActionResult UsuarioForm(int IdUsuario)
        {

            ML.Result result = BL.Usuario.GetById(IdUsuario);
            ML.Usuario usuario = new ML.Usuario();

            usuario = (ML.Usuario)result.Object;

            ML.Result result1 = BL.Estado.EstadoGetAll();
            usuario.Direccion.Colonia.Municipio.Estado.Estados = result1.Objects;



            return View(usuario);
        }

        public ActionResult EntidadGetAll()

        {
            ML.Result result1 = BL.Estado.EstadoGetAll();

            ML.Estado estado = new ML.Estado();


            foreach (ML.Estado itemEstado in result1.Objects)
            {

                estado.IdEstado = itemEstado.IdEstado;
                estado.Nombre = itemEstado.Nombre;

            }

            return View();
        }


        public JsonResult EstadoGetByIdMunicipio (int IdEstado)
        {

            ML.Result result = BL.Municipio.EstadoGetByIdMunicipio(IdEstado);
            return Json(result);

        }








    }
}
