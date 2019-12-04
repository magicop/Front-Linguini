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
using System.Globalization;
using Newtonsoft.Json;

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

        public ActionResult FormBuscar()
        {
            return View();
        }
        #endregion

        #region Agregar
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

                ViewBag.confirmacion = "si";
                ViewBag.ok = "Se ha agregado la reserva con éxito";
                return View("Reservar", new Reservas());
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }

        public static async Task<Uri> agregarReservas(Reservas c)
        {

            string s = c.fechaEmisionReserva.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);

            var url = "http://localhost:8034/api/reserva/" + c.rutCliente + "/" + c.nombreCliente + "/" + c.apPaternoCliente + "/" + c.apMaternoCliente + "/" + s + "/" + c.cantidadPersonas + "/" + c.telefonoCliente + "/" + "agregarReserva/";
            HttpResponseMessage response = await client.PostAsJsonAsync(url, c);

            return response.Headers.Location;
        }
        #endregion

        #region Buscar
        [HttpPost]
        public ActionResult Buscar(Reservas2 c)
        {
            try
            {
                //ViewBag.Result1 = categoriaApiClienat.categorias();

                Reservas2 car = new Reservas2();
                car.rutCliente = c.rutCliente;

                Reservas2 model = reservaApiController.buscarReserva(car);

                if (model == null)
                {
                    ViewBag.error = "si";
                    ViewBag.error2 = "No se ha encontrado la reserva.";
                }
                else
                {
                    ViewBag.error = "no";

                    List<Reservas2> lista = new List<Reservas2>();
                    lista.Add(model);
                    ViewBag.data = lista;
                    

                }


                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }
        /*[HttpGet]
        public static Reservas getReservas(Reservas c)
        {
            /*Usuario u = null;
            
            HttpResponseMessage response = await client.GetAsync(url);
            HttpContent content = response.Content;
            var result2 = await response.Content.ReadAsAsync<Usuario>();*/

        /*var url = "http://localhost:8034/api/reserva/" + c.rutCliente;

        Reservas model = null;
        var client = new HttpClient();
        var task = client.GetAsync(url)
          .ContinueWith((taskwithresponse) =>
          {
              var response = taskwithresponse.Result;
              var jsonString = response.Content.ReadAsStringAsync();
              jsonString.Wait();
              model = JsonConvert.DeserializeObject<Reservas>(jsonString.Result);

          });
        task.Wait();

        if (model == null)
        {
            return null;
        }
        else
        {
            return model;
        }

    }*/
        #endregion

        #region Cancelar
        [HttpPost]
        public ActionResult Cancelar(Reservas2 c)
        {
            try
            {
                //ViewBag.Result1 = categoriaApiClienat.categorias();

                Reservas2 car = new Reservas2();
                car.idReserva = c.idReserva;

                Reservas2 model = reservaApiController.buscarReserva(car);

                if (model == null)
                {
                    ViewBag.error = "si";
                    ViewBag.error2 = "No se ha encontrado la reserva.";
                }
                else
                {
                    ViewBag.ok = "si";
                    ViewBag.cancelado = "Se ha cancelado su reserva con éxito";

                }


                return View();
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }
        #endregion

    }
}