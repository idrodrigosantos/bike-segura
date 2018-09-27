using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Freio
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tipo do Freio")]
        [MinLength(5, ErrorMessage = "Tipo do freio deve ter no mínimo 5 caracteres")]
        [MaxLength(30, ErrorMessage = "Tipo do freio deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }
    }
}