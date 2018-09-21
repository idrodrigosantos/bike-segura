using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class RelatoRoubo
    {
        public int Id { get; set; }
        public string Relato { get; set; }
        public string Localidade { get; set; }
        public DateTime Data { get; set; }

        public int PessoasId { get; set; }
        public virtual Pessoas Pessoas { get; set; }
        public int InformacoesRouboId { get; set; }
        public virtual InformacoesRoubo InformacoesRoubo { get; set; }
    }
}