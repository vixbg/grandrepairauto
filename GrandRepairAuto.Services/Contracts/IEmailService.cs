using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IEmailService
    {
        Task SendNewUserRegistraionEmailAsync(string username, string names, string email, string confirmationLink);
        Task SendForgottenPasswordEmailAsync(string email, string names, string resetLink);
        Task SendOrderDetailsEmailAsync(string email, string names, OrderWithCustomerServicesDTO order);
    }
}
