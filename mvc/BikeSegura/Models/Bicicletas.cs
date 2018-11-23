using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Bicicletas
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Marca")]
        [Required(ErrorMessage = "Marca é obrigatório")]
        public int MarcasId { get; set; }

        [Required(ErrorMessage = "Modelo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Modelo deve ter no máximo 45 caracteres")]
        public string Modelo { get; set; }

        [DisplayName("Tipo da Bicicleta")]
        [Required(ErrorMessage = "Tipo da bicicleta é obrigatório")]
        public int TiposId { get; set; }

        [Required(ErrorMessage = "Cor é obrigatório")]
        [MaxLength(40, ErrorMessage = "Cor deve ter no máximo 40 caracteres")]
        public string Cor { get; set; }

        [DisplayName("Câmbio Dianteiro")]
        public int? CambiosDianteirosId { get; set; }

        [DisplayName("Câmbio Traseiro")]
        public int? CambiosTraseirosId { get; set; }

        [DisplayName("Freios")]
        public int? FreiosId { get; set; }

        [DisplayName("Suspensão")]
        public int? SuspensoesId { get; set; }

        [DisplayName("Medida do Aro")]
        public int? ArosId { get; set; }

        [DisplayName("Material do Quadro")]
        public int? QuadrosId { get; set; }

        [DisplayName("Tamanho do Quadro")]
        [MaxLength(20, ErrorMessage = "Tamanho do quadro deve ter no máximo 20 caracteres")]
        public string Tamanho { get; set; }

        [DisplayName("Informações Adicionais")]
        public string Informacoes { get; set; }

        [DisplayName("Alerta de Roubo")]
        [EnumDataType(typeof(OpcaoAlertaRoubo))]
        public OpcaoAlertaRoubo AlertaRoubo { get; set; }
        public enum OpcaoAlertaRoubo
        {
            Segura = 0,
            Roubada = 1
        }

        [DisplayName("Bicicleta à Venda")]
        [EnumDataType(typeof(OpcaoVendendo))]
        public OpcaoVendendo Vendendo { get; set; }
        public enum OpcaoVendendo
        {
            [Display(Name = "Não")]
            Nao = 0,
            Sim = 1
        }

        [EnumDataType(typeof(OpcaoStatusBicicletas))]
        public OpcaoStatusBicicletas Ativo { get; set; }
        public enum OpcaoStatusBicicletas
        {
            Sim,
            Nao
        }

        public virtual Marcas Marcas { get; set; }
        public virtual Tipos Tipos { get; set; }
        public virtual CambiosDianteiros CambiosDianteiros { get; set; }
        public virtual CambiosTraseiros CambiosTraseiros { get; set; }
        public virtual Freios Freios { get; set; }
        public virtual Suspensoes Suspensoes { get; set; }
        public virtual Aros Aros { get; set; }
        public virtual Quadros Quadros { get; set; }
        public virtual ICollection<Imagens> Imagens { get; set; }
    }
}