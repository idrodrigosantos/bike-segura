﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class RelatoRoubo
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
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Pessoa é obrigatório")]
        public int PessoasId { get; set; }        

        [Required(ErrorMessage = "Sobre qual bicicleta roubada")]
        public int InformacoesRouboId { get; set; }

        public virtual Pessoas Pessoas { get; set; }
        public virtual InformacoesRoubo InformacoesRoubo { get; set; }
    }
}
