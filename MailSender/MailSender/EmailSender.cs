using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender.Model
{
    class EmailSender
    {
        //string addressFrom = new 
        public void Send(MailMessage message, string password)
        {
            try
            {
                string subject = message.Subject;
                string body = message.Body;
                var smtp = new SmtpClient()
                {
                    
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    DeliveryFormat = SmtpDeliveryFormat.International,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("test.send207@gmail.com", password)
                };
                smtp.Send("test.send207@gmail.com", "test.get207@yandex.ru", " ", "Это сообщение отправлено с помощью слепленной на коленке программы");
                Debug.WriteLine("Message has sent");
                MessageBox.Show("The Message has beed sent");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Console.WriteLine(ex);
            }
        }
    }
}
