using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Historicos
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Tipo de Transferência")]
        [EnumDataType(typeof(OpcaoTransferencia))]
        public OpcaoTransferencia? TipoTransferencia { get; set; }
        public enum OpcaoTransferencia
        {
            [Display(Name = "Proprietário Atual")]
            ProprietarioAtual,
            [Display(Name = "Transferência Interna")]
            Interna,
            [Display(Name = "Transferência Externa")]
            Externa
        }

        [DisplayName("Data de Aquisição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataAquisicao { get; set; }

        [DisplayName("Data de Transferência")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataTransferencia { get; set; }

        [DisplayName("Bicicleta")]
        public int BicicletasId { get; set; }

        [DisplayName("Vendedor")]
        public int? VendedorId { get; set; }

        [DisplayName("Comprador")]
        public int? CompradorId { get; set; }

        [EnumDataType(typeof(OpcaoStatusHistoricos))]
        public OpcaoStatusHistoricos Ativo { get; set; }
        public enum OpcaoStatusHistoricos
        {
            Sim,
            Nao
        }

        public virtual Bicicletas Bicicletas { get; set; }
        public virtual Pessoas Vendedor { get; set; }
        public virtual Pessoas Comprador { get; set; }
    }
}