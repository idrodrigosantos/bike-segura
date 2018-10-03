using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Quadros
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Material do quadro é obrigatório")]
        [DisplayName("Material do Quadro")]
        [MaxLength(30, ErrorMessage = "Material do quadro deve ter no máximo 30 caracteres")]
        public string Material { get; set; }
    }
}