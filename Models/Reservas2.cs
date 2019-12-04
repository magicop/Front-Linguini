using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Linguini.Models
{
    public class Reservas2
    {
        [JsonProperty("idReserva")]
        public int idReserva { get; set; }

        [JsonProperty("fechaReserva")]
        public DateTime fechaReserva { get; set; }

        [JsonProperty("rutCliente")]
        public string rutCliente { get; set; }
    }
}