using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Suspensao
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tipo da Suspensão")]
        [MinLength(2, ErrorMessage = "Tipo da suspensção deve ter no mínimo 2 caracteres")]
        [MaxLength(30, ErrorMessage = "Tipo da suspensção deve ter no máximo 40 caracteres")]
        public string Nome { get; set; }
    }
}