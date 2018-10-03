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

        [Required(ErrorMessage = "Nome completo é obrigatório")]
        [DisplayName("Nome Completo*")]
        [MaxLength(100, ErrorMessage = "Nome completo deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Endereço de email é obrigatório")]
        [DisplayName("Endereço de Email*")]
        [MaxLength(255, ErrorMessage = "Endereço de email deve ter no máximo 255 caracteres")]
        [EmailAddress(ErrorMessage = "Digite um endereço de email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você deve confirmar seu Email")]
        [DisplayName("Confirmar Email*")]
        [MaxLength(255, ErrorMessage = "Email deve ter no máximo 255 caracteres")]
        [EmailAddress(ErrorMessage = "Digite um endereço de email")]
        [Compare("Email", ErrorMessage = "Os endereços de email não correspondem")]
        public string ConfirmaEmail { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DisplayName("Senha*")]
        [MinLength(8, ErrorMessage = "Sua senha deve ter no mínimo 8 caracteres")]
        [MaxLength(32, ErrorMessage = "Sua senha deve ter no máximo 32 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Você deve confirmar sua Senha")]
        [DisplayName("Confirmar Senha*")]
        [MinLength(8, ErrorMessage = "Sua senha deve ter no mínimo 8 caracteres")]
        [MaxLength(32, ErrorMessage = "Sua senha deve ter no máximo 32 caracteres")]
        [DataType(DataType.Password)]
        [Compare("Senha", ErrorMessage = "As senhas digitadas não correspondem")]
        public string ConfirmaSenha { get; set; }

        [DisplayName("Endereço")]
        [MaxLength(150, ErrorMessage = "Endereço deve ter no máximo 150 caracteres")]
        public string Endereco { get; set; }

        [DisplayName("Número")]
        [MaxLength(10, ErrorMessage = "Número deve ter no máximo 10 caracteres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Complemento deve ter no máximo 100 caracteres")]
        public string Complemento { get; set; }

        [DisplayName("CEP")]
        [MinLength(8, ErrorMessage = "CEP deve ter no mínimo 8 caracteres")]
        [MaxLength(9, ErrorMessage = "CEP deve ter no máximo 9 caracteres")]
        public string Cep { get; set; }

        [MaxLength(50, ErrorMessage = "Bairro deve ter no máximo 50 caracteres")]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = "Cidade deve ter no máximo 50 caracteres")]
        public string Cidade { get; set; }

        [EnumDataType(typeof(OpcaoEstado))]
        public OpcaoEstado? Estado { get; set; }
        public enum OpcaoEstado
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

        [Required(ErrorMessage = "Telefone é obrigatório")]
        [DisplayName("Telefone*")]
        [MinLength(10, ErrorMessage = "Telefone deve ter no mínimo 10 caracteres")]
        [MaxLength(14, ErrorMessage = "Telefone deve ter no máximo 13 caracteres")]
        public string Telefone { get; set; }

        [MinLength(11, ErrorMessage = "Celular deve ter no mínimo 11 caracteres")]
        [MaxLength(15, ErrorMessage = "Celular deve ter no máximo 15 caracteres")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório")]
        [DisplayName("CPF*")]
        [MinLength(11, ErrorMessage = "CPF deve ter no mínimo 11 caracteres")]
        [MaxLength(14, ErrorMessage = "CPF deve ter no máximo 14 caracteres")]
        public string Cpf { get; set; }

        [DisplayName("Data de Nascimento")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]        
        public DateTime? DataNascimento { get; set; }

        [DisplayName("Gênero")]
        [EnumDataType(typeof(OpcaoGenero))]
        public OpcaoGenero? Genero { get; set; }
        public enum OpcaoGenero
        {
            [Display(Name = "Masculino")]
            M,
            [Display(Name = "Feminino")]
            F
        }

        [DisplayName("Imagem de Perfil")]
        public string ImagemPerfil { get; set; }

        [DisplayName("Nome do Contato")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string NomeContato { get; set; }

        [DisplayName("Telefone de Contato")]
        [MinLength(11, ErrorMessage = "Telefone para contato deve ter no mínimo 11 caracteres")]
        [MaxLength(15, ErrorMessage = "Telefone para contato deve ter no máximo 15 caracteres")]
        public string TelefoneContato { get; set; }

        [DisplayName("Tipo de Usuário")]
        [EnumDataType(typeof(OpcaoUsuario))]
        public OpcaoUsuario TipoUsuario { get; set; }
        public enum OpcaoUsuario
        {
            Comum,
            Administrador
        }
    }
}