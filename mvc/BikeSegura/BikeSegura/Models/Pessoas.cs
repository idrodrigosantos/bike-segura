using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Pessoas
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public string DataNascimento { get; set; }
        public string Genero { get; set; }
        public string ImagemPerfil { get; set; }
        public string TipoSanguineo { get; set; }
        public string PessoaContato { get; set; }
        public string TelefoneContato { get; set; }
    }
}