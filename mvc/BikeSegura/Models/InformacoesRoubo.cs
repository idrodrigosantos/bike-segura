using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class InformacoesRoubo
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Relato sobre o roubo")]
        public string Relato { get; set; }

        [MaxLength(150, ErrorMessage = "Local deve ter no máximo 150 caracteres")]
        public string Local { get; set; }

        [DisplayName("Data do Roubo")]
        public DateTime Data { get; set; }

        public int BicicletasId { get; set; }
        public virtual Bicicletas Bicicletas { get; set; }
    }
}