using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Imagem Perfil")]
        [MaxLength(100)]
        public string ImagemPerfil { get; set; }

        [DisplayName("Nome Contato")]
        [MinLength(5)]
        [MaxLength(100)]
        public string PessoaContato { get; set; }

        [DisplayName("Telefone Contato")]
        [MaxLength(15)]
        public string TelefoneContato { get; set; }

        public int PessoasId { get; set; }
        public virtual Pessoas Pessoas { get; set; }
    }
}