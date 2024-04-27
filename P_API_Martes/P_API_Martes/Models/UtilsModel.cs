using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace P_API_Martes.Models
{
    public class UtilsModel
    {
        public void SendMail(string destiny, string subject, string content)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["cuentaCorreo"]);
            message.To.Add(new MailAddress(destiny));
            message.Subject = subject;
            message.Body = content;
            message.Priority = MailPriority.Normal;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.office365.com", 587);
            client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["cuentaCorreo"],
                                                                  ConfigurationManager.AppSettings["claveCorreo"]);
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}