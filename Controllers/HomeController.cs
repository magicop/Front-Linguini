using Front_Linguini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;

namespace Front_Linguini.Controllers
{
    public class HomeController : Controller
    {

        private ApiRestful reservaApiController = new ApiRestful();
        static HttpClient client = new HttpClient();

        #region Paginas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Galeria()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult Reservar()
        {
            return View(new Reservas());
        }

        public ActionResult Somos()
        {
            return View();
        }
        #endregion

        [HttpPost]

        public async Task<ActionResult> AgregarReserva(Reservas c)
        {
            try
            {
                //ViewBag.Result1 = categoriaApiClienat.categorias();

                /*c.fechaReserva = (c.fechaReserva.Date.Add(c.fechaEmisionReserva.TimeOfDay)).ToShortDateString;
                c.fechaEmisionReserva = c.fechaReserva;*/
                c.estados = null;
                

                var result = await agregarReservas(c);

                return View("Reservar", new Reservas());
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }

        public static async Task<Uri> agregarReservas(Reservas c)
        {
            var url = "http://localhost:8034/api/reserva/agregarReserva/";
            HttpResponseMessage response = await client.PostAsJsonAsync(url, c);

            return response.Headers.Location;
        }
    }
}