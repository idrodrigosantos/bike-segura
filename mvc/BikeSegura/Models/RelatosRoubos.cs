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

        [Required(ErrorMessage = "Relato sobre o roubo é obrigatório")]
        [DisplayName("Relato sobre a bicicleta roubada")]
        public string Relato { get; set; }

        [Required(ErrorMessage = "Local é obrigatório")]
        [MaxLength(150, ErrorMessage = "Local deve ter no máximo 150 caracteres")]
        [DisplayName("Local onde a bicicleta roubada foi vista")]
        public string Local { get; set; }

        [DisplayName("Data que a bicicleta roubada foi vista")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Pessoa é obrigatório")]
        public int PessoasId { get; set; }

        [Required(ErrorMessage = "Sobre qual bicicleta roubada")]
        public int InformacoesRoubosId { get; set; }

        public virtual Pessoas Pessoas { get; set; }
        public virtual InformacoesRoubos InformacoesRoubos { get; set; }
    }
}