using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class MailTemplate
    {
        public static bool SendMail(string ToEmailId, string CC, string BCC, string Subject, string Message, string Attachment, string separator = null)
        {
            StringBuilder stblr = new StringBuilder();
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            string desclairm = string.Empty;
            try
            {

                mailMessage.From = new System.Net.Mail.MailAddress("jo.avi.1990@gmail.com", "Order Management System");

                // for multiple TO Mail address
                if (!string.IsNullOrEmpty(ToEmailId))
                {
                    string[] arryToEmail = ToEmailId.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tmails in arryToEmail)
                    {
                        mailMessage.To.Add(new System.Net.Mail.MailAddress(tmails));
                    }
                }

                // For multiple CC Mail Address
                if (!string.IsNullOrEmpty(CC))
                {
                    string[] arryCCEmail = CC.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var cmails in arryCCEmail)
                    {
                        mailMessage.CC.Add(new System.Net.Mail.MailAddress(cmails));
                    }
                }

                if (!string.IsNullOrEmpty(BCC))
                {
                    string[] arryBCCEmail = BCC.Split(new char[] { ',',' ',';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var bccmails in arryBCCEmail)
                    {
                        mailMessage.Bcc.Add(new System.Net.Mail.MailAddress(bccmails));
                    }
                }

                mailMessage.Subject = Subject;
                mailMessage.Body = stblr.ToString();

                if (!string.IsNullOrEmpty(Attachment))
                {
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(Attachment));
                }

                mailMessage.IsBodyHtml = true;
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("jo.avi.1990@mail.com.com", AESCrypto.DecryptString("+jhO7v+b/g06yozswPWfjk/MTdZE1pfE+fvcxnpszs4="));

                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                WriteLogs.Error("Error in Sending Mail.", ex);
            }
            return false;
        }
    }
}
