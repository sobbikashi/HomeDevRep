namespace MailSender
{
   
    public static class ConfigSmtpGMail
    {
        public static string host = "smtp.gmail.com";
        public static int port = 587;
        public static string user = "test.send207@gmail.com";
        public static string pass = "Trustno1*";
    }

    public static class ConfigSmtpYandex
    {
        public static string host = "smtp.yandex.ru";
        public static int port = 465;
        public static string user = "test.send207@yandex.ru";
        public static string pass = "trustno1*";
    }
}
