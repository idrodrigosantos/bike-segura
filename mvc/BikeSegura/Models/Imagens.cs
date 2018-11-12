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

        [DisplayName("Fotos da Bicicleta")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "Bicicleta é obrigatório")]
        public int BicicletasId { get; set; }

        [EnumDataType(typeof(OpcaoStatusImagens))]
        public OpcaoStatusImagens Ativo { get; set; }
        public enum OpcaoStatusImagens
        {
            Sim,
            Nao
        }

        public virtual Bicicletas Bicicletas { get; set; }
    }
}