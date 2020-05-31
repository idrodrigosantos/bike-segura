using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class RelatosRoubos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cidade onde a bicicleta roubada foi vista é obrigatório")]
        [MaxLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado onde a bicicleta roubada foi vista obrigatório")]
        [EnumDataType(typeof(OpcaoEstadoRelatosRoubos))]
        public OpcaoEstadoRelatosRoubos Estado { get; set; }
        public enum OpcaoEstadoRelatosRoubos
        {
            [Display(Name = "Acre")]
            AC,
            [Display(Name = "Alagoas")]
            AL,
            [Display(Name = "Amapá")]
            AP,
            [Display(Name = "Amazonas")]
            AM,
            [Display(Name = "Bahia")]
            BA,
            [Display(Name = "Ceará")]
            CE,
            [Display(Name = "Distrito Federal")]
            DF,
            [Display(Name = "Espirito Santo")]
            ES,
            [Display(Name = "Goiás")]
            GO,
            [Display(Name = "Maranhão")]
            MA,
            [Display(Name = "Mato Grosso")]
            MT,
            [Display(Name = "Mato Grosso do Sul")]
            MS,
            [Display(Name = "Minas Gerais")]
            MG,
            [Display(Name = "Pará")]
            PA,
            [Display(Name = "Paraíba")]
            PB,
            [Display(Name = "Paraná")]
            PR,
            [Display(Name = "Pernambuco")]
            PE,
            [Display(Name = "Piauí")]
            PI,
            [Display(Name = "Rio de Janeiro")]
            RJ,
            [Display(Name = "Rio Grande do Norte")]
            RN,
            [Display(Name = "Rio Grande do Sul")]
            RS,
            [Display(Name = "Rondônia")]
            RO,
            [Display(Name = "Roraima")]
            RR,
            [Display(Name = "Santa Catarina")]
            SC,
            [Display(Name = "São Paulo")]
            SP,
            [Display(Name = "Sergipe")]
            SE,
            [Display(Name = "Tocantins")]
            TO
        }

        [Required(ErrorMessage = "Relato sobre o roubo é obrigatório")]
        public string Relato { get; set; }

        [MaxLength(150, ErrorMessage = "Local deve ter no máximo 150 caracteres")]
        [DisplayName("Local Adicional")]
        public string LocalAdicional { get; set; }

        [Required(ErrorMessage = "Data que a bicicleta foi vista é obrigatório")]
        [DisplayName("Data do Relato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRelato { get; set; }

        [Required(ErrorMessage = "Relator é obrigatório")]
        [DisplayName("Relator")]
        public int PessoasId { get; set; }

        [DisplayName("Roubo")]
        [Required(ErrorMessage = "Roubo é obrigatório")]
        public int InformacoesRoubosId { get; set; }

        [EnumDataType(typeof(OpcaoStatusRelatosRoubos))]
        public OpcaoStatusRelatosRoubos Ativo { get; set; }
        public enum OpcaoStatusRelatosRoubos
        {
            Sim,
            Nao
        }

        public virtual Pessoas Pessoas { get; set; }
        public virtual InformacoesRoubos InformacoesRoubos { get; set; }
    }
}