using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Registro
{
    public class ServicioEmail
    {
        private MailMessage email;
        private SmtpClient servidor;

        public ServicioEmail()
        {
            servidor = new SmtpClient();
            servidor.Credentials = new NetworkCredential("56203856cd3bd9", "4bcf0e12c0f132");
            servidor.EnableSsl = true;
            servidor.Port = 2525;
            servidor.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From= new MailAddress("noresponder@ValenArticulos.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>Hola</h1>";
            email.Body = cuerpo;    
        }

        public void enviarEmail()
        {
           
            servidor.Send(email);
        }

    }
}
