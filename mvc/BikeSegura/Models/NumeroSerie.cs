using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class NumeroSerie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Número de série é obrigatório")]
        [DisplayName("Número de Série")]
        [MinLength(5, ErrorMessage = "Número de série deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Número de série deve ter no máximo 50 caracteres")]
        public string Numero { get; set; }

        public int BicicletasId { get; set; }
        public virtual Bicicletas Bicicletas { get; set; }
    }
}