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

            usuario.Usuarios = result.Objects; ;

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

            ML.Usuario item = (ML.Usuario)result.Object;
            
            
                usuario.IdUsuario = item.IdUsuario;
                usuario.Nombre = item.Nombre;
                usuario.ApellidoPaterno = item.ApellidoPaterno;
                usuario.ApellidoMaterno = item.ApellidoMaterno;
                usuario.Email = item.Email;
                usuario.UserName = item.UserName;
                usuario.Password = item.Password;
                usuario.FechaNacimiento = item.FechaNacimiento; 
                usuario.Sexo = item.Sexo;
                usuario.Telefono = item.Telefono;
                usuario.Celular = item.Celular;
                usuario.CURP = item.CURP;
                usuario.Estatus = item.Estatus;


            

            return View(usuario);
        }








    }
}
