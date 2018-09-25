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

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Número de Série*")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Marca*")]
        public int MarcasId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [Display(Name = "Tipo de Bicicleta")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cor { get; set; }

        [DisplayName("Fotos da Bicicleta")]
        public string Imagem { get; set; }

        [DisplayName("Câmbio Dianteiro")]
        public int CambioDianteiroId { get; set; }

        [DisplayName("Câmbio Traseiro")]
        public int CambioTraseiroId { get; set; }

        [DisplayName("Tipo de Freio")]
        public int FreioId { get; set; }

        [DisplayName("Tipo de Suspensão")]
        public int SuspensaoId { get; set; }

        [DisplayName("Tamanho do Aro")]
        public int AroId { get; set; }

        [DisplayName("Tipo do Quadro")]
        public int QuadroId { get; set; }

        [DisplayName("Informações Adicionais")]
        public string Informacoes { get; set; }

        //public bool AlertaRoubo { get; set; }
        [DisplayName("Alerta de Roubo")]
        [EnumDataType(typeof(Opcao1))]
        public Opcao1 AlertaRoubo { get; set; }
        public enum Opcao1
        {
            Desativado = 0,
            Ativado = 1
        }

        //public bool Vendendo { get; set; }
        [DisplayName("Bicicleta à Venda")]
        [EnumDataType(typeof(Opcao2))]
        public Opcao2 Vendendo { get; set; }
        public enum Opcao2
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