using Azure.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Users.Item.SendMail;
using Unicam.Paradigmi.Application.Abstractions.Services;
using Unicam.Paradigmi.Application.Options;

namespace Unicam.Paradigmi.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOption _emailOption;
        public EmailService(IOptions<EmailOption> emailOptions)
        {
            _emailOption = emailOptions.Value;
        }
        public async Task SendEmailAsync(string subject, string body)
        {
           /* List<Recipient> recipients = new List<Recipient>();
           foreach(var to in _emailOption.Tos)
            {
                var recipient = new Recipient()
                {
                    EmailAddress = new EmailAddress()
                    {
                        Address = to
                    }
                };
                recipients.Add(recipient);
            }*/

           


            var clientCredential = new ClientSecretCredential(_emailOption.TenantId
                ,_emailOption.ClientId
                ,_emailOption.ClientSecret
                );
            var client = new GraphServiceClient(clientCredential);

            Message message = new()
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = Microsoft.Graph.Models.BodyType.Text,
                    Content = body
                },
                ToRecipients = _emailOption.Tos
                .Select(s =>
                {
                    return new Recipient()
                    {
                        EmailAddress = new EmailAddress()
                        {
                            Address = s
                        }
                    };
                }).ToList()
                /*new List<Recipient>()
                {
                    new Recipient()
                    {
                        EmailAddress = new EmailAddress() {
                        Address = "f.paoloni@bitonline.it"
                        }
                    }
                }*/
            };

          /*
            if (attachments != null)
            {
                var listAttachments = new List<Microsoft.Graph.Models.Attachment>();
                foreach (var att in attachments)
                {
                    var fileAttachement = new FileAttachment();
                    fileAttachement.Name = att.Filename;
                    fileAttachement.ContentType = GetMimeType(att.Filename);
                    fileAttachement.ContentBytes = att.Content;
                    listAttachments.Add(fileAttachement);
                }
                message.Attachments = listAttachments;
            }
          */

            var postRequestBody = new SendMailPostRequestBody();
            postRequestBody.Message = message;
            postRequestBody.SaveToSentItems = true;


            await client.Users[_emailOption.From]
                .SendMail.PostAsync(postRequestBody);

        }
           
    }
}
