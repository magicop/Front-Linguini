using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Linguini.Models
{
    public class Reservas
    {
        [JsonProperty("idReserva")]
        public int idReserva { get; set; }

        [JsonProperty("apMaternoCliente")]
        public string apMaternoCliente { get; set; }

        [JsonProperty("apPaternoCliente")]
        public string apPaternoCliente { get; set; }

        [JsonProperty("cantidadPersonas")]
        public int cantidadPersonas { get; set; }

        [JsonProperty("fechaEmisionReserva")]
        public DateTime fechaEmisionReserva { get; set; }

        [JsonProperty("fechaReserva")]
        public DateTime fechaReserva { get; set; }

        [JsonProperty("nombreCliente")]
        public string nombreCliente { get; set; }

        [JsonProperty("rutCliente")]
        public string rutCliente { get; set; }

        [JsonProperty("telefonoCliente")]
        public string telefonoCliente { get; set; }

        [JsonProperty("estados")]
        public Estados estados { get; set; }

    }

}