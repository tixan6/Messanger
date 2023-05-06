using System.Net;
using System.Net.Mail;
using static System.Net.Mime.MediaTypeNames;

namespace Messanger.Scripts.SMTPSendingToMail
{
    public class Sending
    {
        private string Sender = "lloshonkov@yandex.by";
        private string Recipient;
        private string text;

        public Sending(string email, string text) 
        {
            this.Recipient = email;
            this.text = text;
        }

        public void SendMessage() 
        {
            //From
            MailAddress from = new MailAddress(Sender, "Регистрация");
            //To
            MailAddress to = new MailAddress(Recipient);
            //body
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Тестовое письмо";
            message.Body = "Код регистрации пользователя, не сообщайте код никому: " + text;

            //SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.yandex.ru", 587);
            smtpClient.Credentials = new NetworkCredential("lloshonkov@yandex.by", "dertropkxwepkwet");
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
        }


        
    }
}
