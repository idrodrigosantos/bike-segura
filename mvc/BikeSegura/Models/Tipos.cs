using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Tipos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tipo da bicicleta é obrigatório")]
        [DisplayName("Tipo da Bicicleta")]
        [MaxLength(40, ErrorMessage = "Tipo da bicicleta deve ter no máximo 40 caracteres")]
        public string Nome { get; set; }

        [EnumDataType(typeof(OpcaoStatusTipos))]
        public OpcaoStatusTipos Ativo { get; set; }
        public enum OpcaoStatusTipos
        {
            Sim,
            Nao
        }
    }
}