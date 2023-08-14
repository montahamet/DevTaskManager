using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAGE._2023.TEST.Utils
{
    public static class Mailing
    {

        #region Declaration

        #region Constantes

        public static string DATE_FORMAT = "{0:dd-MM-yyyy}";
        public static string TIME_FORMAT = "HH:mm:ss";

        #endregion

        #region Enumerations

        #endregion //Enumerations

        #endregion // Declaration

        #region Constructors

        static Mailing()
        {

        }

        #endregion //Constructors

        #region Treatment

        public static bool sendMailHtml(string Receiver_Name, string Email_To, string Sender_Name, string Email_Subject, string Email_Body, string Email_From, string Email_Pass, string Smtp_Server, int Smtp_Port, bool Use_Ssl, bool Is_HTML = true)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress((string.IsNullOrEmpty(Sender_Name)) ? Email_From : Sender_Name, Email_From));
                message.To.Add(new MailboxAddress((string.IsNullOrEmpty(Receiver_Name)) ? Email_To : Receiver_Name, Email_To));

                message.Subject = (string.IsNullOrEmpty(Email_Subject)) ? "Mail From Me :)" : Email_Subject.Trim();

                var builder = new BodyBuilder();
                if (Is_HTML)
                {
                    builder.HtmlBody = Email_Body;
                }
                else
                {
                    builder.TextBody = Email_Body;
                }

                message.Body = builder.ToMessageBody();

                using (var _MailClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    //_MailClient.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12;

                    _MailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //_MailClient.Connect(Smtp_Server, Smtp_Port, SecureSocketOptions.SslOnConnect);
                    _MailClient.Connect(Smtp_Server, Smtp_Port, Use_Ssl);

                    _MailClient.Authenticate(Email_From, Email_Pass);

                    _MailClient.Send(message);

                    _MailClient.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                string strEx = ex.Message;
                return false;
            }
        }

        #endregion // Treatment
    }
}
