using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Aro
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tamanho do Aro")]
        [MinLength(5, ErrorMessage = "Tamanho do aro deve ter no mínimo 5 caracteres")]
        [MaxLength(15, ErrorMessage = "Tamanho do aro deve ter no máximo 15 caracteres")]
        public string Medida { get; set; }
    }
}