﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using Domain.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;

namespace Identity
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            return GetUserId<int>(principal);
        }

        public static TKey GetUserId<TKey>(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            string userId = principal.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (typeof(TKey) == typeof(int))
            {
                if (!int.TryParse(userId, out _))
                {
                    throw new ArgumentException("ClaimsPrincipal NameIdentifier is not of type int!");
                }
            }

            return (TKey) Convert.ChangeType(userId, typeof(TKey));

            // this is tiny bit slower, but handles GUID type also
            // return (TKey) TypeDescriptor.GetConverter(typeof(TKey)).ConvertFromInvariantString(userId);

        }

        public static void IdentityAddDefaultRolesAndUsers(this IApplicationBuilder app, UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            /*
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
  
                //var uow = serviceScope.ServiceProvider.GetRequiredService<IAppUnitOfWork>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
*/
            /*
        }
*/
            
            
            if (!roleManager.Roles.Any(r => r.NormalizedName == "FOOBAR"))
            {
                var result = roleManager.CreateAsync(new AppRole() {Name = "FooBar"}).Result;
                if (result == IdentityResult.Success)
                {
                }
            }

            var user = userManager.FindByEmailAsync("foo@bar.com").Result;
            if (user == null)
            {
                var result = userManager.CreateAsync(new AppUser()
                {
                    Email = "foo@bar.com",
                    UserName = "foo@bar.com",
//                    FirstName = "Foo",
//                    LastName = "Bar"
                }, "FooBar").Result;
                if (result == IdentityResult.Success)
                {
                    user = userManager.FindByEmailAsync("foo@bar.com").Result;
                }
            }

            if (user != null && !userManager.IsInRoleAsync(user, "FooBar").Result)
            {
                var result = userManager.AddToRoleAsync(user, "FooBar").Result;
            }
            
        }

    }
}
