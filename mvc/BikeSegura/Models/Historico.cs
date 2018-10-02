using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Historico
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Situação Atual")]
        [EnumDataType(typeof(OpcaoSituacao))]
        public OpcaoSituacao SituacaoAtual { get; set; }
        public enum OpcaoSituacao
        {
            Interno,
            Externo,
            Sim
        }

        [DisplayName("Data de Aquisição")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataAquisicao { get; set; }

        [DisplayName("Data de Transferência")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataTransferencia { get; set; }

        [Required(ErrorMessage = "Bicicleta é obrigatório")]
        public int BicicletasId { get; set; }

        [Required(ErrorMessage = "Pessoa é obrigatório")]
        public int PessoasId { get; set; }

        public virtual Bicicletas Bicicletas { get; set; }
        public virtual Pessoas Pessoas { get; set; }
    }
}
