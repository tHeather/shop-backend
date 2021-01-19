using System;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using shop_backend.Services.Interfaces;

namespace shop_backend.Services
{
    public class SendgridService : ISendgridService
    {
        private readonly string supportMailAddress;
        private readonly ISendGridClient sendGridClient;

        public SendgridService(ISendGridClient sendGridClient)
        {
            supportMailAddress = Constants.SUPPORT_MAIL_ADDRESS ?? throw new ArgumentNullException("No support mail address provided");
            this.sendGridClient = sendGridClient ?? throw new ArgumentNullException(nameof(sendGridClient));
        }

        public async Task SendOrderConfirmationEmail(string recipientMail, string message)
        {
            await SendMailTextAsync(supportMailAddress, recipientMail, "Order successful", message);
        }

        private async Task<bool> SendMailTextAsync(string senderEmail, string recipientMail, string subject, string message)
        {
            var msg = new SendGridMessage();
            msg.SetFrom(senderEmail);
            msg.AddTo(recipientMail);
            msg.Subject = HttpUtility.HtmlEncode(subject);
            msg.PlainTextContent = message;
            var response = await sendGridClient.SendEmailAsync(msg);

            return response.StatusCode == HttpStatusCode.Accepted;
        }

        private async Task<bool> SendMailTemplateAsync(string senderEmail, string recipientMail, string templateId, dynamic templateData)
        {
            var msg = new SendGridMessage();
            msg.SetFrom(senderEmail);
            msg.AddTo(recipientMail);
            msg.SetTemplateId(templateId);
            msg.SetTemplateData(templateData);
            var response = await sendGridClient.SendEmailAsync(msg);

            return response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
