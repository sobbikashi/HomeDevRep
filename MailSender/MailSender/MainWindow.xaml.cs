
using System.Windows;
using System.Windows.Controls;
using System.Net.Mail;
using MailSender.Model;
using System.Media;
using System.Collections.Generic;
using Microsoft.Win32;

namespace MailSender
{
  
    public partial class MainWindow : Window
    {
        static int countMail = 0;
        public List<string> addressList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

        }

        //обработка события нажатия кнопки "Отправить"
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            // Проверка валидности введённого адреса
            if (RegexCheck.IsValidEmail(tTo.Text))
            {
                // Загрузка параметров smtp-сервера
                var smtpParams = GetSmtpParams();
                // Формирование письма: тело, адрес отправителя и получателя
                EmailSender emailSender = new EmailSender(smtpParams.host, smtpParams.pass, smtpParams.port, smtpParams.user);
                MailAddress from = new MailAddress(tFrom.Text + tcbServer.Text);
                MailAddress to = new MailAddress(tTo.Text);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = tSubject.Text;
                mail.Body = tBody.Text;
                // Проверка на наличие аттача
                if (tbAttachmentAddress.Text != "")
                {
                    mail.Attachments.Add(new Attachment(tbAttachmentAddress.Text));
                }

                emailSender.Send(mail);
                lWarningIncEmail.Visibility = Visibility.Hidden;
            }
            else
            {
                SystemSounds.Exclamation.Play();
                lWarningIncEmail.Visibility = Visibility.Visible;
            }

        }

        // Добавление подписи к телу письма во вкладке "Письмо"
        private void btnAddSignature_Click(object sender, RoutedEventArgs e)
        {
            tBody.Text += "\n \n \n  " + tSignature.Text;

        }

        // Закрытие окна
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Переключение вкладок стрелками вправо-влево
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (tcMain.SelectedIndex != tcMain.Items.Count - 1)
            {
                tcMain.SelectedIndex += 1;
            }
            else tcMain.SelectedIndex = 0;
            tFromM.Text = tFrom.Text + tcbServer.Text;
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (tcMain.SelectedIndex != 0)
            {
                tcMain.SelectedIndex -= 1;
            }
            else tcMain.SelectedIndex = tcMain.Items.Count - 1;
            tFromM.Text = tFrom.Text + tcbServer.Text;
        }

        // Получение параметров smtp из комбо-бокса
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
    

        // Добавление подписи к телу письма во вкладке "Рассылка"
        private void btnAddSignatureM_Click(object sender, RoutedEventArgs e)
        {
            tBodyM.Text += "\n \n \n  " + tSignatureM.Text;
        }

        // Формирование списка рассылки
        private void btnAddM_Click(object sender, RoutedEventArgs e)
        {
            tToM.Text += tToSingleM.Text + "; ";
            countMail += 1;
            addressList.Add(tToSingleM.Text);
        }

        // Отправка писем по списку рассылки
        private void btnSendM_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < countMail; i++)
            {
                var smtpParams = GetSmtpParams();
                EmailSender emailSender = new EmailSender(smtpParams.host, smtpParams.pass, smtpParams.port, smtpParams.user);
                MailAddress from = new MailAddress(tFrom.Text + tcbServer.Text);
                MailAddress to = new MailAddress(addressList[i]);
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = tSubject.Text;
                mail.Body = tBody.Text;
                emailSender.Send(mail);
            }
            countMail = 0;
        }

        // Добавление файла-вложения
        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileAddress = new OpenFileDialog();
            if (fileAddress.ShowDialog() == true)
            {
                fileAddress.DefaultExt = ".txt";
                fileAddress.Filter = "Text documents (.txt)|*.txt";
                tbAttachmentAddress.Text = fileAddress.FileName;
            }
            btnAttachDelete.Visibility = Visibility.Visible;
        }

        // Удаление файла-вложения
        private void btnAttachDelete_Click(object sender, RoutedEventArgs e)
        {
            tbAttachmentAddress.Text = "";
            btnAttachDelete.Visibility = Visibility.Hidden;
        }
    }
}
