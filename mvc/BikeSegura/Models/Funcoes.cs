using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BikeSegura.Models
{
    public class Funcoes
    {
        // Criptografia SHA512
        // Receber valor da string, valor de entrada
        public static string SHA512(string valor)
        {
            // Importa e cria nova instância
            UnicodeEncoding UE = new UnicodeEncoding();
            // Declara array de bytes, tem hash de bytes, e uma mensagem de bytes
            // Na variável UE gera GetBytes do valor que receber
            byte[] HashValue, MessageBytes = UE.GetBytes(valor);
            // Declara SHA512, gera instância dele
            SHA512Managed SHhash = new SHA512Managed();
            // Declara variável string
            string strHex = "";

            // Chama HashValue, chama o ComputeHash que vai receber a mensagem(MessageBytes), 
            //      que já tem bytes para gerar outros bytes
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                // Somar string strHex, atribuindo nela um formato específico
                // Formato específico: ter hexadecimal em 2 caracteres
                strHex += String.Format("{0:x2}", b);
            }
            // Retorna string de hash
            return strHex;
        }

        public static string CodigoUsuario()
        {
            return "";
        }

        public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg)
        {
            try
            {
                //Cria o endereço de email do remetente
                MailAddress de = new MailAddress("email@email.com");
                //Cria o endereço de email do destinatário -->
                MailAddress para = new MailAddress(emailDestinatario);
                MailMessage mensagem = new MailMessage(de, para);
                mensagem.IsBodyHtml = true;
                //Assunto do email
                mensagem.Subject = assunto;
                //Conteúdo do email
                mensagem.Body = corpomsg;
                //Prioridade E-mail
                mensagem.Priority = MailPriority.Normal;
                //Cria o objeto que envia o e-mail
                SmtpClient cliente = new SmtpClient();
                //Envia o email
                cliente.Send(mensagem);
                return "success|Cadastro efetuado com sucesso.";
            }
            catch { return "error|Erro ao enviar e-mail de confirmação de cadastro."; }
        }

        public static string CodigoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

    }
}