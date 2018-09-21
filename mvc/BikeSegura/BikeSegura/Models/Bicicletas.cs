using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Bicicletas
    {
        public int Id { get; set; }
        public string NumeroSerie { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public string Cor { get; set; }
        public string Imagem { get; set; }
        public string CambioDianteiro { get; set; }
        public string CambioTraseiro { get; set; }
        public string Freio { get; set; }
        public string Suspensao { get; set; }
        public string Aro { get; set; }
        public string Quadro { get; set; }
        public string Informacoes { get; set; }
        //public byte AlertaRoubo { get; set; }
        //public byte Vendendo { get; set; }

        public int MarcasId { get; set; }
        public virtual Marcas Marcas { get; set; }
    }
}