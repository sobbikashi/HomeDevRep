using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using MailSender.Model;
using System.Text.RegularExpressions;
using System.Media;

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
        public static string currentHost = "";
        public static string currentPass = "";
        public static string currentUsername = "";
        public static int currentPort = 0;

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (RegexCheck.IsValidEmail(tTo.Text) == true)
            {
                EmailSender emailSender = new EmailSender();

                MailAddress from = new MailAddress(tFrom.Text + tcbServer.Text);
                MailAddress to = new MailAddress(tTo.Text);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = tSubject.Text;
                mail.Body = tBody.Text;

                emailSender.Send(mail, currentPass);
                lWarningIncEmail.Visibility = Visibility.Hidden;
            }
            else
            {
                SystemSounds.Exclamation.Play();
                lWarningIncEmail.Visibility = Visibility.Visible;
              
            }
            
        }

        private void btnAddSignature_Click(object sender, RoutedEventArgs e)
        {
            tBody.Text += "\n \n \n  " + tSignature.Text;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tcbServer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
             if (selectedItem.Content.ToString() == "@gmail.com")
            {
                currentHost = ConfigSmtpGMail.host;
                currentPort = ConfigSmtpGMail.port;
                currentUsername = ConfigSmtpGMail.obj;
                currentPass = ConfigSmtpGMail.pass;
            }
            else if (selectedItem.Content.ToString() == "@yandex.ru")
            {
                currentHost = ConfigSmtpYandex.host;
                currentPort = ConfigSmtpYandex.port;
                currentUsername = ConfigSmtpYandex.obj;
                currentPass = ConfigSmtpYandex.pass;
            }

        }
    }
}
