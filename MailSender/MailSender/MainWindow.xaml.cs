using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Net.Mail;
using MailSender.Model;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
             

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmailSender emailSender = new EmailSender();
            
            MailAddress from = new MailAddress(tFrom.Text);
            MailAddress to = new MailAddress(tTo.Text);
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = tSubject.Text;
            mail.Body = tBody.Text;

            emailSender.Send(mail, tPassword.Password);
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tBody.Text += "\n \n \n  " + tSignature.Text;
        }
    }
}
