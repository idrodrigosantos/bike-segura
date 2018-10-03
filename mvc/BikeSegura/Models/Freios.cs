using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Freios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo do freio é obrigatório")]
        [DisplayName("Tipo do Freio")]
        [MaxLength(30, ErrorMessage = "Tipo do freio deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }
    }
}