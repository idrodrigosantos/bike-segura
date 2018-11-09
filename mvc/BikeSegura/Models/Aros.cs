using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Aros
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Medida do aro é obrigatório")]
        [DisplayName("Medida do Aro")]
        [MaxLength(15, ErrorMessage = "Medida do aro deve ter no máximo 15 caracteres")]
        public string Medida { get; set; }
        
        [EnumDataType(typeof(OpcaoStatusAros))]
        public OpcaoStatusAros Ativo { get; set; }
        public enum OpcaoStatusAros
        {
            Sim,
            Nao
        }
    }
}