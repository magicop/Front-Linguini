using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace Front_Linguini.Models
{
    public class ApiRestful
    {

        public string BASE_URL = "http://localhost:8034/";
        static HttpClient client = new HttpClient();


        #region Reservas

        #region Agregar
        /*public List<Reservas> listarCartas()
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("api/carta/listarCartas").Result;

                var task = client.GetAsync("api/carta/listarCartas")
                 .ContinueWith((taskwithresponse) =>
                 {
                     var response2 = taskwithresponse.Result;
                     var jsonString = response.Content.ReadAsStringAsync();
                     jsonString.Wait();
                     list2 = JsonConvert.DeserializeObject<List<Carta2>>(jsonString.Result);

                     var prueba = list.ToArray();

                     foreach (var item in prueba)
                     {
                         Carta2 c = new Carta2();
                         c.idCarta = item.idCarta;
                         c.nombreCarta = item.nombreCarta;
                         c.valorCarta = item.valorCarta;
                         c.nombreCategoria = item.nombreCategoria;
                         c.imagenCarta = item.imagenCarta;

                         list2.Add(c);
                         list.Remove(c);
                     }

                 });

                task.Wait();

                return list2;
            }
            catch
            {
                return null;
            }
        }*/

        #endregion

        #region Buscar
        public Reservas2 buscarReserva(Reservas2 c)
        {
            try
            {
                var client = new HttpClient();
                Reservas2 list = new Reservas2();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = BASE_URL + "api/reserva/" + c.rutCliente;
                HttpResponseMessage response = client.GetAsync(url).Result;

                var task = client.GetAsync(url)
                 .ContinueWith((taskwithresponse) =>
                 {
                     var response2 = taskwithresponse.Result;
                     var jsonString = response.Content.ReadAsStringAsync();
                     jsonString.Wait();
                     list = JsonConvert.DeserializeObject<Reservas2>(jsonString.Result);

                     c.idReserva = list.idReserva;
                     c.rutCliente = list.rutCliente;
                     c.fechaReserva = list.fechaReserva;

                 });

                task.Wait();

                return c;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Eliminar
        #region Buscar
        public Reservas2 cancelarReserva(Reservas2 c)
        {
            try
            {
                var client = new HttpClient();
                Reservas2 list = new Reservas2();
                client.BaseAddress = new Uri(BASE_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string url = BASE_URL + "api/reserva/" + c.rutCliente;
                var stringContent = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(url, stringContent).Result;

                return c;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        #endregion

        #endregion
    }
}