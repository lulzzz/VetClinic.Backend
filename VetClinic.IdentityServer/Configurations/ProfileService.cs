﻿using IdentityServer4.Models;
using IdentityServer4.Services;
using System.Threading.Tasks;

namespace VetClinic.IdentityServer.Configurations
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.AddRange(context.Subject.Claims);
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
    }
}
