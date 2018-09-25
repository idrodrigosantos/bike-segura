using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Pessoas
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Nome Completo*")]
        [MinLength(5)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Endereço de Email*")]
        [MinLength(5)]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Confirmar Email*")]
        [MinLength(5)]
        [MaxLength(255)]
        [EmailAddress]
        [Compare("Email")]
        public string ConfirmaEmail { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Senha*")]
        [MinLength(5)]
        [MaxLength(25)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Confirmar Senha*")]
        [MinLength(5)]
        [MaxLength(25)]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        public string ConfirmaSenha { get; set; }

        [DisplayName("Endereço")]
        [MinLength(5)]
        [MaxLength(150)]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [MinLength(1)]
        [MaxLength(20)]
        public string Numero { get; set; }

        [MaxLength(100)]
        public string Complemento { get; set; }

        [DisplayName("CEP")]
        [MaxLength(10)]
        public string Cep { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Bairro { get; set; }

        [MinLength(5)]
        [MaxLength(30)]
        public string Cidade { get; set; }

        [EnumDataType(typeof(Opcao))]
        public Opcao Estado { get; set; }
        public enum Opcao
        {
            [Display(Name = "Selecione Estado")]
            Vazio,
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
            [Display(Name = "Mato Grosso do Sul")]
            MS,
            [Display(Name = "Mato Grosso")]
            MT,
            [Display(Name = "Minas Gerais")]
            MG,
            [Display(Name = "Pará")]
            PA,
            [Display(Name = "Paraíba")]
            PB,
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

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("Telefone*")]
        [MinLength(4)]
        [MaxLength(14)]
        public string Telefone { get; set; }

        [MinLength(4)]
        [MaxLength(15)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [DisplayName("CPF*")]
        [MinLength(11)]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        [MaxLength(10)]
        public string DataNascimento { get; set; }

        [DisplayName("Gênero")]
        public string Genero { get; set; }

        [DisplayName("Imagem Perfil")]
        [MaxLength(45)]
        public string ImagemPerfil { get; set; }

        [DisplayName("Tipo Sanguíneo")]
        [MaxLength(3)]
        public string TipoSanguineo { get; set; }

        [DisplayName("Nome Contato")]
        [MinLength(5)]
        [MaxLength(100)]
        public string PessoaContato { get; set; }

        [DisplayName("Telefone Contato")]
        [MaxLength(15)]
        public string TelefoneContato { get; set; }
    }
}