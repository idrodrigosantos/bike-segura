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
        public static string SHA512(string valor)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(valor);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
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
    }
}