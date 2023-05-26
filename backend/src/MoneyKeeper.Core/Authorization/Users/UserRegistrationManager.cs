using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using Abp.Domain.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoneyKeeper.Authorization.Roles;
using MoneyKeeper.MultiTenancy;

namespace MoneyKeeper.Authorization.Users
{
    public class UserRegistrationManager : DomainService
    {
        public IAbpSession AbpSession { get; set; }

        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        public UserRegistrationManager(
            UserManager userManager,
            RoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

            AbpSession = NullAbpSession.Instance;
        }

        public async Task<User> RegisterAsync(string name, string surname, string emailAddress, string userName, string plainPassword, bool isEmailConfirmed)
        {
            var user = new User
            {
                TenantId = Tenant.DefaultTenantId,
                Name = name,
                Surname = surname,
                EmailAddress = emailAddress,
                IsActive = true,
                UserName = userName,
                IsEmailConfirmed = isEmailConfirmed,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            foreach (var defaultRole in await _roleManager.Roles.Where(r => r.IsDefault).ToListAsync())
            {
                user.Roles.Add(new UserRole(Tenant.DefaultTenantId, user.Id, defaultRole.Id));
            }

            await _userManager.InitializeOptionsAsync(Tenant.DefaultTenantId);

            CheckErrors(await _userManager.CreateAsync(user, plainPassword));
            await CurrentUnitOfWork.SaveChangesAsync();

            return user;
        }

        private void CheckForTenant()
        {
            if (!AbpSession.TenantId.HasValue)
            {
                throw new InvalidOperationException("Can not register host users!");
            }
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
