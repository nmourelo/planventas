using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Utils;
using planventas.Models.DBContext;
using System.IO;
using System.Linq;

namespace PosWeb.Utilitarios
{
    public class Correo
    {
        public static bool EnviaCorreo(string asunto, string cuerpo, string ClientEmail, string ClientName)
        {
            bool Enviado = false;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MaratónSJ", "ccdrsj2014@gmail.com"));
            message.To.Add(new MailboxAddress(ClientName, ClientEmail));
            message.Cc.Add(new MailboxAddress("Administrador", "nestor.mourelo@gmail.com"));
            message.Subject = asunto;

            //NESTOR - CODIGOUTIL - Ejemplo para  enviar a diferentes direcciones se puede hacer con  un foreach desde una lista en un modelo
            //InternetAddressList Lista = new();
            //Lista.Add(new MailboxAddress("nesty","nestor.mourelo@gmail.com"));
            //Lista.Add(new MailboxAddress("Loki", "loquitico@gmail.com"));
            //message.To.AddRange(Lista);


            var builder = new BodyBuilder();
            builder.TextBody = "Comprobante de adquisición de medallas de ediciones de la Maratón de San José anteriores al 2022";
            var currentDirectory = Directory.GetCurrentDirectory();
            var filesDirectory = Path.Combine(currentDirectory, "wwwroot", "img");

            string EmailLogoHeader = "EmailHeader.png";
            string BodyHtml = cuerpo;
            string EmailLogoFooter = "EmailFooterok.png";

            if (true)
            {
                // If we have any headers or footers, inject those into the HTML body
                if (!string.IsNullOrEmpty(EmailLogoHeader) && !string.IsNullOrEmpty(EmailLogoFooter))
                {
                    var imageHead = builder.LinkedResources.Add(Path.Combine(filesDirectory, EmailLogoHeader));

                    imageHead.ContentId = MimeUtils.GenerateMessageId();
                    var imageFoot = builder.LinkedResources.Add(Path.Combine(filesDirectory, EmailLogoFooter));

                    imageFoot.ContentId = MimeUtils.GenerateMessageId();
                    builder.HtmlBody = string.Format(@"<img src='cid:{0}'><br>{1}<br><img src='cid:{2} '>", imageHead.ContentId, BodyHtml, imageFoot.ContentId);
                }
                else if (!string.IsNullOrEmpty(EmailLogoFooter))
                {
                    var imageFoot = builder.LinkedResources.Add(Path.Combine(filesDirectory, EmailLogoFooter));

                    imageFoot.ContentId = MimeUtils.GenerateMessageId();
                    builder.HtmlBody = string.Format(@"{0}<br><img src='cid={1}'>", BodyHtml, imageFoot.ContentId);
                }
                else if (!string.IsNullOrEmpty(EmailLogoHeader))
                {
                    var imageHead = builder.LinkedResources.Add(Path.Combine(filesDirectory, EmailLogoHeader));
                    imageHead.ContentId = MimeUtils.GenerateMessageId();
                    builder.HtmlBody = string.Format(@"<img src='cid:{0}'><br>{1}", imageHead.ContentId, BodyHtml);
                }
                else
                {
                    builder.HtmlBody = BodyHtml;
                }
            }
            builder.TextBody = "texto";
            message.Body = builder.ToMessageBody();
            using var client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ccdrsj2014@gmail.com", "2019ccdrsj2019");
            client.Send(message);
            client.Disconnect(true);
            Enviado = true;
            return Enviado;
        }
    
        public static string GetMessage(int Proceso, string NumSol, string FechaHora, string FullEmp, string ElUser)
        {
            string MessageBody = "";
            switch (Proceso)
            {
                case 101:
                    MessageBody = string.Format(@"<br/><div>
                            <p>Ha recibido la solicitud de justificación de asistencia Nº [" + NumSol + "] para su aprobación.</p>" +
                            "<div class='col-md-12'><hr size ='2px' width ='80%' noshade ='noshade' align ='left'/>" + "</div><br/>" +
                            "<div><p style='text-align:left'><b>Fecha y Hora de Envío:</b>&nbsp;[" + FechaHora  + "]</p><br/>" +
                            "<b>Funcionario que Solicita:</b>&nbsp;[" + FullEmp + "]</div><br/>" +
                            "<b>Usuario que envia:</b>&nbsp;[" + ElUser + "]</div><br/>" +
                             "Ingrese al sistema Financiero-Administrativo para procesar la solicitud pendiente.</div><br/>");
                    break;
            }
            return MessageBody;
        }


        //public  static string GetEmailDestino(string Dusuario, Context db)
        //{
        //    var eDestino = db.UsuariosPlan2000.Where(f => f.Usuario == Dusuario).FirstOrDefault().Email.ToString();
        //    return eDestino;
        //}

    }
}
