using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class InformacoesRoubos
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cidade do roubo é obrigatório")]
        [DisplayName("Cidade onde a bicicleta foi roubada (*)")]
        [MaxLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Estado do roubo é obrigatório")]
        [DisplayName("Estado onde a bicicleta foi roubada (*)")]
        [EnumDataType(typeof(OpcaoEstadoInformacoesRoubos))]
        public OpcaoEstadoInformacoesRoubos Estado { get; set; }
        public enum OpcaoEstadoInformacoesRoubos
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

        [Required(ErrorMessage = "Informações sobre o roubo é obrigatório")]
        [DisplayName("Informações sobre o roubo (*)")]
        public string Relato { get; set; }

        [MaxLength(150, ErrorMessage = "Local do roubo deve ter no máximo 150 caracteres")]
        [DisplayName("Informações adicionais do local onde a bicicleta foi roubada")]
        public string LocalAdicional { get; set; }

        [Required(ErrorMessage = "Data do roubo é obrigatório")]
        [DisplayName("Data do Roubo (*)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRoubo { get; set; }

        [Required(ErrorMessage = "Bicicleta roubada é obrigatória")]
        public int BicicletasId { get; set; }

        [EnumDataType(typeof(OpcaoStatusInformacoesRoubos))]
        public OpcaoStatusInformacoesRoubos Ativo { get; set; }
        public enum OpcaoStatusInformacoesRoubos
        {
            Sim,
            Nao
        }

        public virtual Bicicletas Bicicletas { get; set; }
    }
}