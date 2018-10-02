using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class InformacoesRoubo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informações sobre o roubo é obrigatório")]
        [DisplayName("Informações sobre o roubo")]
        public string Relato { get; set; }

        [Required(ErrorMessage = "Local do roubo é obrigatório")]
        [MaxLength(150, ErrorMessage = "Local do roubo deve ter no máximo 150 caracteres")]
        [DisplayName("Local onde a bicicleta foi roubada")]
        public string Local { get; set; }

        [DisplayName("Data do Roubo")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Bicicleta é obrigatório")]
        public int BicicletasId { get; set; }
        public virtual Bicicletas Bicicletas { get; set; }
    }
}
