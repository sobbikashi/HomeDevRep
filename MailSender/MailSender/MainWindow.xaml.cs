
using System.Windows;
using System.Windows.Controls;
using System.Net.Mail;
using MailSender.Model;
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
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (RegexCheck.IsValidEmail(tTo.Text))
            {
                var smtpParams = GetSmtpParams();
                EmailSender emailSender = new EmailSender(smtpParams.host, smtpParams.pass, smtpParams.port, smtpParams.user);

                MailAddress from = new MailAddress(tFrom.Text + tcbServer.Text);
                MailAddress to = new MailAddress(tTo.Text);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = tSubject.Text;
                mail.Body = tBody.Text;

                emailSender.Send(mail);
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
                
        private void btnNext_Click(object sender, RoutedEventArgs e)
        { 
            if (tcMain.SelectedIndex != tcMain.Items.Count-1)
            {
                tcMain.SelectedIndex += 1;
            }               
            else tcMain.SelectedIndex = 0;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (tcMain.SelectedIndex != 0)
            {
                tcMain.SelectedIndex -= 1;
            }               
            else tcMain.SelectedIndex = tcMain.Items.Count-1;
        }
       
        private (string host, string pass, int port, string user) GetSmtpParams()
        {
            ComboBox comboBox = (ComboBox)tcbServer;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
          
            switch (selectedItem.Content.ToString())
            {
                case "@gmail.com":
                    return (ConfigSmtpGMail.host, ConfigSmtpGMail.pass, ConfigSmtpGMail.port, ConfigSmtpGMail.user);                   
                case "@yandex.ru": 
                    return (ConfigSmtpYandex.host, ConfigSmtpYandex.pass, ConfigSmtpYandex.port, ConfigSmtpYandex.user);                   
            }
            return (null, null, 0, null);
        }
    }
}
