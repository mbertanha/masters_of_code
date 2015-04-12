using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace HomeSupply.Utils
{
    public class Email
    {

        public Boolean enviarEmail()
        {
            SmtpClient smtp = new SmtpClient();
            MailMessage email = new MailMessage();

            try
            {
                //Instanciar objeto smtp
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("samsungs3da@gmail.com", "samsung.");
                

                email.Sender = new MailAddress("jukaroxteam@gmail.com", "Jukarox");
                email.From = new MailAddress("jukaroxteam@gmail.com", "Jukarox");
                email.To.Add(new MailAddress("jukarox@gmail.com", "Juquinha"));
                email.Subject = "Notificação de pagamento!";
                email.Body = "Seu pagamento foi efetuado com sucesso.";
                email.IsBodyHtml = false;
                email.Priority = MailPriority.High;

                smtp.Send(email);

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
