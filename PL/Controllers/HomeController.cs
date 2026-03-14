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
           // ML.Result result = BL.Class1.GetAll();
            ML.Captura captura = new ML.Captura();

//            captura.Capturas = result.Objects;

            return View();

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

        /*

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
        */








    }
}
