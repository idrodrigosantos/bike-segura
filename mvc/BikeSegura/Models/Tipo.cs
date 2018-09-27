using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tipo da Bicicleta")]
        [MinLength(3, ErrorMessage = "Tipo da bicicleta deve ter no mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Tipo da bicicleta deve ter no máximo 40 caracteres")]
        public string Nome { get; set; }
    }
}