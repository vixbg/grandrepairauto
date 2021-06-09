using GrandRepairAuto.Services.Contracts;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GrandRepairAuto.Services.Models.OrderDTOs;

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

        public async Task SendForgottenPasswordEmailAsync(string email, string names, string resetLink)
        {
            var client = new SendGridClient(config.GetValue<string>("SendGrid:Key"));
            var msg = new SendGridMessage();
            msg.SetFrom("grandrepairautobulgaria@gmail.com", "Grand Repair Auto");
            msg.AddTo(email, names);
            msg.SetTemplateId(config.GetValue<string>("SendGrid:ResetPassword"));
            msg.SetTemplateData(new
            {
                names = names,
                link = resetLink
            });
            var result = await client.SendEmailAsync(msg);
            return;
        }

        public async Task SendOrderDetailsEmailAsync(string email, string names, OrderWithCustomerServicesDTO order) 
            
        {
            var client = new SendGridClient(config.GetValue<string>("SendGrid:Key"));
            var msg = new SendGridMessage();
            msg.SetFrom("grandrepairautobulgaria@gmail.com", "Grand Repair Auto");
            msg.AddTo(email, names);
            msg.SetTemplateId(config.GetValue<string>("SendGrid:OrderDetails"));
            msg.SetTemplateData(order);
            var result = await client.SendEmailAsync(msg);
            return;
        }
    }
}
