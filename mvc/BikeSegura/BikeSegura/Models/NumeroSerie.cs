using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class NumeroSerie
    {
        public int Id { get; set; }
        public string Numero { get; set; }

        public int BicicletasId { get; set; }
        public virtual Bicicletas Bicicletas { get; set; }
    }
}