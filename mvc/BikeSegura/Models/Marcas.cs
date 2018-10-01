using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Marcas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da marca é obrigatório")]
        [DisplayName("Nome da Marca")]        
        [MaxLength(30, ErrorMessage = "Nome da marca deve ter no máximo 30 caracteres")]
        public string Nome { get; set; }
    }
}
