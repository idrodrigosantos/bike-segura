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

        [Required(ErrorMessage = "Marca é obrigatório")]
        public int MarcasId { get; set; }

        [Required(ErrorMessage = "Modelo é obrigatório")]
        [MinLength(2, ErrorMessage = "Modelo deve ter no mínimo 3 caracteres")]
        [MaxLength(45, ErrorMessage = "Modelo deve ter no máximo 45 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Tipo da bicicleta é obrigatório")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "Cor é obrigatório")]
        [MinLength(3, ErrorMessage = "Cor deve ter no mínimo 3 caracteres")]
        [MaxLength(40, ErrorMessage = "Cor deve ter no máximo 40 caracteres")]
        public string Cor { get; set; }

        [DisplayName("Fotos da Bicicleta")]
        public string Imagem { get; set; }

        public int CambioDianteiroId { get; set; }
        public int CambioTraseiroId { get; set; }
        public int FreioId { get; set; }
        public int SuspensaoId { get; set; }
        public int AroId { get; set; }
        public int QuadroId { get; set; }

        [DisplayName("Informações Adicionais")]
        public string Informacoes { get; set; }

        [DisplayName("Alerta de Roubo")]
        [EnumDataType(typeof(OpcaoAlertaRoubo))]
        public OpcaoAlertaRoubo AlertaRoubo { get; set; }
        public enum OpcaoAlertaRoubo
        {
            Desativado = 0,
            Ativado = 1
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

        public virtual Marcas Marcas { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual CambioDianteiro CambioDianteiro { get; set; }
        public virtual CambioTraseiro CambioTraseiro { get; set; }
        public virtual Freio Freio { get; set; }
        public virtual Suspensao Suspensao { get; set; }
        public virtual Aro Aro { get; set; }
        public virtual Quadro Quadro { get; set; }
    }
}