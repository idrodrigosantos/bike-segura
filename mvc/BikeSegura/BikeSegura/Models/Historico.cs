using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Historico
    {
        public int Id { get; set; }
        //public enum Atual { get; set; }
        public DateTime Data { get; set; }

        public int BicicletasId { get; set; }
        public virtual Bicicletas Bicicletas { get; set; }
        public int PessoasId { get; set; }
        public virtual Pessoas Pessoas { get; set; }
    }
}