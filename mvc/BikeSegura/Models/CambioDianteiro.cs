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

        [Required(ErrorMessage = "Câmbio dianteiro é obrigatório")]
        [DisplayName("Câmbio Dianteiro")]        
        [MaxLength(20, ErrorMessage = "Câmbio dianteiro deve ter no máximo 20 caracteres")]
        public string Velocidade { get; set; }
    }
}
