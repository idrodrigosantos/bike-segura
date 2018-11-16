using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Imagens
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Foto da Bicicleta")]
        public string Imagem { get; set; }

        [DisplayName("Bicicleta")]
        [Required(ErrorMessage = "Bicicleta é obrigatório")]
        public int BicicletasId { get; set; }

        public virtual Bicicletas Bicicletas { get; set; }
    }
}