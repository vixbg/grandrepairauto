using GrandRepairAuto.Services.Contracts;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrandRepairAuto.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }

        public Task SendNewUserRegistraionEmailAsync(string username, string names, string email, string confirmationLink)
        {
            var client = new SendGridClient(config.GetValue<string>("SendGrid:Key"));
            var msg = new SendGridMessage();
            msg.SetFrom("grandrepairautobulgaria@gmail.com", "Grand Repair Auto");
            msg.AddTo(email, names);
            msg.SetTemplateId(config.GetValue<string>("SendGrid:NewUser"));
            msg.SetTemplateData(new
            {
                username = username,
                names = names,
                link = confirmationLink
            });
            return client.SendEmailAsync(msg);
        }
    }
}
