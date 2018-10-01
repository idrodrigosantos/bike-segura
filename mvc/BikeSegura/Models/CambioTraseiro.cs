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

        [Required(ErrorMessage = "Câmbio traseiro é obrigatório")]
        [DisplayName("Câmbio Traseiro")]        
        [MaxLength(20, ErrorMessage = "Câmbio traseiro deve ter no máximo 20 caracteres")]
        public string Velocidade { get; set; }
    }
}
