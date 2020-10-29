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
using System.Windows.Controls;
using System.Windows.Data;

namespace MailSender.Model
{
    //public struct ELetter
    //{
    //    public string addressFrom;
    //    public string addressTo;
    //    public string subject;
    //    public string textBody;
    //}
    

    class EmailSender
    {


        //public string addressFrom;
        //public string addressTo;
        //public string subject;
        //public string textBody;


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
                // smtp.Send(addressFrom, addressTo, subject, textBody);
                smtp.Send(message);
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
