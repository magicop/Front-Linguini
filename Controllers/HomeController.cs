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

            string s = c.fechaReserva.ToString("dd-mm-yyyy-hh-mm-ss", CultureInfo.InvariantCulture);

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
       
        #endregion


        #region Cancelar
        
        
        public ActionResult Cancelar(string rut)
        {
            //ViewBag.Result1 = categoriaApiClienat.categorias();

            Reservas2 car = new Reservas2();
            car.rutCliente = rut;

            Reservas2 model = reservaApiController.cancelarReserva(car);

            if (model == null)
            {
                ViewBag.error = "si";
                ViewBag.error2 = "No se ha encontrado la reserva.";
            }
            else
            {
                ViewBag.confirmacion = "si";
                ViewBag.cancelado = "Se ha cancelado su reserva con éxito";

            }


            return View("Reservar", new Reservas());

        }
        #endregion

    

    }
}