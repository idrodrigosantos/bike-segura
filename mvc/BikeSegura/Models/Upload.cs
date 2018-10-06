using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BikeSegura.Models
{
    public class Upload
    {
        public static bool CriarDiretorio()
        {
            string novodiretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\";
            if (!Directory.Exists(novodiretorio))
            {
                //Caso não exista devermos criar
                Directory.CreateDirectory(novodiretorio);
                return true;
            }
            else
                return false;
        }
        public static bool ExcluirArquivo(string arquivoimg)
        {
            if (File.Exists(arquivoimg))
            {
                File.Delete(arquivoimg);
                return true;
            }
            else
                return false;
        }
        public static string UploadArquivo(HttpPostedFileBase arquivoUpload, string nome)
        {
            try
            {
                double permitido = 900;
                if (arquivoUpload != null)
                {
                    string arquivoimg = Path.GetFileName(arquivoUpload.FileName);
                    double tamanho = Convert.ToDouble(arquivoUpload.ContentLength) / 1024;
                    string extensao = Path.GetExtension(arquivoUpload.FileName);
                    string diretorio = HttpContext.Current.Request.PhysicalApplicationPath + "Uploads\\" + nome;
                    if (tamanho > permitido)
                        return "Tamanho Máximo permitido é de " + permitido + " kb!";
                    else if ((extensao != ".png" && extensao != ".jpg"))
                        return "Extensão inválida, só são permitidas .png e .jpg!";
                    else
                    {
                        if (!File.Exists(diretorio))
                        {
                            arquivoUpload.SaveAs(diretorio);
                            return "sucesso";
                        }
                        else
                            return "Já existe um arquivo com esse nome!";
                    }
                }
                else
                    return "Erro no Upload!";
            }
            catch { return "Erro no Upload"; }
        }
    }
}