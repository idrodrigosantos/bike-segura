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
        public OpcaoTransferencia TipoTransferencia { get; set; }
        public enum OpcaoTransferencia
        {
            [Display(Name = "Transferência Interna")]
            Interna,
            [Display(Name = "Transferência Externa")]
            Externa,
            [Display(Name = "Proprietário Atual")]
            ProprietarioAtual
        }

        [DisplayName("Data de Aquisição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataAquisicao { get; set; }

        [DisplayName("Data de Transferência")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataTransferencia { get; set; }

        [Required(ErrorMessage = "Bicicleta é obrigatório")]
        public int BicicletasId { get; set; }

        [DisplayName("Vendedor")]
        [Required(ErrorMessage = "Vendedor é obrigatório")]
        public int VendedorId { get; set; }

        [DisplayName("Comprador")]
        [Required(ErrorMessage = "Comprador é obrigatório")]
        public int CompradorId { get; set; }

        public virtual Bicicletas Bicicletas { get; set; }
        public virtual Pessoas Vendedor { get; set; }
        public virtual Pessoas Comprador { get; set; }
    }
}