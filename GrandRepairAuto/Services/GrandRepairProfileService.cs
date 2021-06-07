using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;

namespace GrandRepairAuto.Web.Services
{
    public class GrandRepairProfileService : IProfileService
    {
        private readonly UserManager<User> userManager;

        public GrandRepairProfileService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(id);
            var claims = context.Subject.Claims.ToList();
            claims.Add(new Claim("GrandRepair_Names", $"{user.FirstName} {user.LastName}"));
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var id = context.Subject.GetSubjectId();
            var user = await userManager.FindByIdAsync(id);
            context.IsActive = user.DeletedOn == null;
        }
    }
}
