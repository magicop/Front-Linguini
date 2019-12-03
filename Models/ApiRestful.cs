using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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



        #region Eliminar
        #endregion

        #endregion
    }
}