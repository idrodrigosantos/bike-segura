using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class InformacoesRoubo
    {
        [Key]
        public int Id { get; set; }
        public string Relato { get; set; }
        public string Localidade { get; set; }
        public string Data { get; set; }
        //public DateTime Data { get; set; }

        public int BicicletasId { get; set; }
        public virtual Bicicletas Bicicletas { get; set; }
    }
}