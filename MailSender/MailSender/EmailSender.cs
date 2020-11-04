﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using System.Net.Mail;
using System.Windows;



namespace MailSender.Model
{
    class EmailSender
    {
        public void Send(MailMessage message, string password)
        {

            try
            {
                string subject = message.Subject;
                string body = message.Body;

                var smtp = new SmtpClient()

                {

                    Host = MainWindow.currentHost,
                    Port = MainWindow.currentPort,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    DeliveryFormat = SmtpDeliveryFormat.International,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(MainWindow.currentUsername, MainWindow.currentPass)
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

