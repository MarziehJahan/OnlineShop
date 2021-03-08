using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PresentationHost.EmailSend
{
    public class EmailHelper
    {
        public bool SendEmailTwoFactorCode(string userEmail, string code)
        {
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("jahankhani1994@gmail.com");
            //mailMessage.To.Add(new MailAddress(userEmail));

            //mailMessage.Subject = "Two Factor Code";
            //mailMessage.IsBodyHtml = true;
            //mailMessage.Body = code;

            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("jahankhani1994@gmail.com", "0017220947");
            //client.Host = "smtpout.secureserver.net";
            //client.Port = 80;

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            //client.Port = 587;
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("jahankhani1994", "0017220947", "gmail.com");
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(userEmail));
            msg.From = new MailAddress("jahankhani1994@gmail.com");
            msg.Subject = "Two Factor Code";
            msg.Body = code;
            //client.Send(msg);

            try
            {
                client.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }
    }
}
