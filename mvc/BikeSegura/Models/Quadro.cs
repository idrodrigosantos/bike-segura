using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Quadro
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Material do Quadro")]
        [MinLength(3, ErrorMessage = "Material do quadro deve ter no mínimo 3 caracteres")]
        [MaxLength(15, ErrorMessage = "Material do quadro deve ter no máximo 15 caracteres")]
        public string Material { get; set; }
    }
}