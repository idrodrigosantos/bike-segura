using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class CambioTraseiro
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Câmbio Traseiro")]
        [MinLength(10, ErrorMessage = "Câmbio traseiro deve ter no mínimo 10 caracteres")]
        [MaxLength(14, ErrorMessage = "Câmbio traseiro deve ter no máximo 14 caracteres")]
        public string Velocidade { get; set; }
    }
}