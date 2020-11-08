using System.Text.RegularExpressions;

namespace MailSender
{
    class RegexCheck
    {
        // Метод проверки корректности введённого адреса получателя с использованием регулярных выражений
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase);
        }
    }
}
