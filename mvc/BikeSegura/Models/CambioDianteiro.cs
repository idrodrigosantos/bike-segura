using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class CambioDianteiro
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Câmbio Dianteiro")]
        [MinLength(10, ErrorMessage = "Câmbio dianteiro deve ter no mínimo 10 caracteres")]
        [MaxLength(13, ErrorMessage = "Câmbio dianteiro deve ter no máximo 13 caracteres")]
        public string Velocidade { get; set; }
    }
}