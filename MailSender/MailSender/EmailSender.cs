using System;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows;


namespace MailSender.Model
{
    public class EmailSender
    {
        private string _host;
        private string _pass;
        private int _port;
        private string _user;

        public EmailSender(string host, string pass, int port, string user)
        {
            _host = host;
            _pass = pass;
            _port = port;
            _user = user;
        }
        public void Send(MailMessage message)
        {
            try
            {
                string subject = message.Subject;
                string body = message.Body;

                var smtp = new SmtpClient()
                {
                    Host = _host,
                    Port = _port,                    
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    DeliveryFormat = SmtpDeliveryFormat.International,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_user, _pass)
                };
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

