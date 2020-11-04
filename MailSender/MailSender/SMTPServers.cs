using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
   
    public static class ConfigSmtpGMail
    {
        public static string host = "smtp.gmail.com";
        public static int port = 587;
        public static string obj = "test.send207@gmail.com";
        public static string pass = "Trustno1*";
    }

    public static class ConfigSmtpYandex
    {
        public static string host = "smtp.yandex.ru";
        public static int port = 465;
        public static string obj = "test.send207@yandex.ru";
        public static string pass = "trustno1*";
    }


}
