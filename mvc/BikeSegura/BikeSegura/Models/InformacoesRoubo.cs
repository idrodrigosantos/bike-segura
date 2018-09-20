using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class InformacoesRoubo
    {
        public int Id { get; set; }
        public string Relato { get; set; }
        public string Localidade { get; set; }
        public DateTime Data { get; set; }
    }
}