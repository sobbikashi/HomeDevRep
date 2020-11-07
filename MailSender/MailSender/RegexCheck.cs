using System.Text.RegularExpressions;

namespace MailSender
{
    class RegexCheck
    {
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
//RenderTransformOrigin="0.1,0.675"  660,707,0,0