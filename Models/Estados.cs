using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Front_Linguini.Models
{
    public class Estados
    {
        [JsonProperty("idEstado")]
        public int idEstado { get; set; }

        [JsonProperty("nombreEstado")]
        public string nombreEstado { get; set; }
    }
}