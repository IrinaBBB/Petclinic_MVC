using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace Petclinic.Services
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        private readonly ILogger<MailJetEmailSender> _logger;
        private MailJetOptions _mailJetOptions;

        public MailJetEmailSender(IConfiguration config, ILogger<MailJetEmailSender> logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)

        {
            _mailJetOptions = _config.GetSection("MailJet").Get<MailJetOptions>();

            var client = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);
            var request = new MailjetRequest

                {
                    Resource = Send.Resource,
                }

                .Property(Send.FromEmail, "irinabbb@protonmail.com")
                .Property(Send.FromName, "Petclinic")
                .Property(Send.Subject, subject)
                .Property(Send.HtmlPart, htmlMessage)
                .Property(Send.Recipients, new JArray {
                    new JObject {
                        {"Email", email}
                    }
                });



            var response = await client.PostAsync(request);

            if (response.IsSuccessStatusCode)

            {
                _logger.LogInformation($"Total: {response.GetTotal()}, Count: {response.GetCount()}\n");
                _logger.LogInformation(response.GetData().ToString());
            }

            else

            {
                _logger.LogError($"StatusCode: {response.StatusCode}\n");
                _logger.LogError($"ErrorInfo: {response.GetErrorInfo()}\n");
                _logger.LogError(response.GetData().ToString());
                _logger.LogError($"ErrorMessage: {response.GetErrorMessage()}\n");
            }

        }

    }

}

    //    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    //    {
    //        _mailJetOptions = _config.GetSection("MailJet").Get<MailJetOptions>();
    //        var client
    //            = new MailjetClient(_mailJetOptions.ApiKey, _mailJetOptions.SecretKey);

    //        var request = new MailjetRequest
    //            {
    //                Resource = SendV31.Resource,
    //            }
    //            .Property(Send.Messages, new JArray
    //            {
    //                new JObject
    //                {
    //                    {
    //                        "From", new JObject
    //                        {
    //                            { "Email", "irinabbb@protonmail.com" },
    //                            { "Name", "Petclinic" }
    //                        }
    //                    },
    //                    {
    //                        "To",
    //                        new JArray
    //                        {
    //                            new JObject
    //                            {
    //                                { "Email", "petclinic@protonmail.com" },
    //                                { "Name", "Petclinic" }
    //                            }
    //                        }
    //                    },
    //                    {
    //                        "Subject", subject
    //                    },
    //                    {
    //                        "TextPart", "My first Mailjet email"
    //                    },
    //                    {
    //                        "HTMLPart", htmlMessage
    //                    }
    //                }
    //            });
    //        var response = await client.PostAsync(request);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            _logger.LogInformation($"Total: {response.GetTotal()}, Count: {response.GetCount()}\n");
    //            _logger.LogInformation(response.GetData().ToString());
    //        }
    //        else
    //        {
    //            _logger.LogError($"StatusCode: {response.StatusCode}\n");
    //            _logger.LogError($"ErrorInfo: {response.GetErrorInfo()}\n");
    //            _logger.LogError(response.GetData().ToString());
    //            _logger.LogError($"ErrorMessage: {response.GetErrorMessage()}\n");
    //        }
    //    }
    //}
