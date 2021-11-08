using System.Collections.Generic;
using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IEH_Shared.Model;
using Microsoft.Extensions.Options;
using System.Net;
using Shared.Model;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using MailKit.Net.Smtp;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IEH_Shared.Utility
{
   public class EmailService :IEmailService
    {
        private readonly EmailConfig ec;

        private readonly EmailSettings _emailSettings;
        public EmailService(IOptions<EmailConfig> emailConfig, IOptions<EmailSettings> EmailSettings)
        {
            this.ec = emailConfig.Value;
            this._emailSettings = EmailSettings.Value;
        }
        public async Task SendEmailAsync(String email, String subject, String message)
        {
            try
            {
                var emailMessage = new MimeMessage();
                this.ec.FromAddress = _emailSettings.Email;//"kunal.burangi@smartdatainc.net";
                this.ec.FromName = _emailSettings.FromName;
                this.ec.MailServerAddress = _emailSettings.MailServerAddress;// "smtp.sendgrid.net";
                this.ec.UserPassword = _emailSettings.UserPasswordSmtp;// "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";
                this.ec.MailServerPort = _emailSettings.MailServerPort;//"465";
                this.ec.UserId = _emailSettings.UserId;
                emailMessage.From.Clear();
                emailMessage.From.Add(new MailboxAddress(ec.FromName, ec.FromAddress));

                emailMessage.To.Clear();
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                emailMessage.Body = new TextPart(TextFormat.Html) { Text = message };


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.LocalDomain = ec.LocalDomain;

                    await client.ConnectAsync(ec.MailServerAddress, Convert.ToInt32(ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(ec.UserId, ec.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// email send method
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="attachment"></param>
        /// <param name="fileName"></param>
        /// <param name="contentType"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendEmailAttachmentAsync(string email, string subject, byte[] attachment, string fileName, string contentType, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();

                this.ec.FromAddress = _emailSettings.Email;//"kunal.burangi@smartdatainc.net";
                this.ec.FromName = _emailSettings.FromName;
                this.ec.MailServerAddress = _emailSettings.MailServerAddress;// "smtp.sendgrid.net";
                this.ec.UserPassword = _emailSettings.UserPasswordSmtp;// "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";
                this.ec.MailServerPort = _emailSettings.MailServerPort;//"465";
                this.ec.UserId = _emailSettings.UserId;
                emailMessage.From.Clear();
                emailMessage.From.Add(new MailboxAddress(ec.FromName, ec.FromAddress));

                emailMessage.To.Clear();
                emailMessage.To.Add(new MailboxAddress("", email));
                emailMessage.Subject = subject;
                var builder = new BodyBuilder { HtmlBody = message };

                builder.Attachments.Add(fileName, attachment, ContentType.Parse(contentType));
                emailMessage.Body = builder.ToMessageBody();




                using (var client = new SmtpClient())
                {
                    client.LocalDomain = ec.LocalDomain;

                    await client.ConnectAsync(ec.MailServerAddress, Convert.ToInt32(ec.MailServerPort), SecureSocketOptions.Auto).ConfigureAwait(false);
                    await client.AuthenticateAsync(new NetworkCredential(ec.UserId, ec.UserPassword));
                    await client.SendAsync(emailMessage).ConfigureAwait(false);
                    await client.DisconnectAsync(true).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<bool> sendEmail(String email, String sub, String message)
        {
            try
            {
                var apiKey = _emailSettings.UserPasswordV3;//"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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(_emailSettings.Email, _emailSettings.FromName);
                var subject = sub; //"Sending with SendGrid is Fun";
                var to = new EmailAddress(email);
                var plainTextContent = message;//"and easy to do anywhere, even with C#";
                var htmlContent = message; //"<strong>and easy to do anywhere, even with C#</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                return true; 
            }
            catch (Exception ex)
            {

                return false;
            }
        }
     
    }
}
