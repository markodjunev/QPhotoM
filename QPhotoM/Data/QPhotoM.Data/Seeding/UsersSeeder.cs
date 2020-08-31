namespace QPhotoM.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using QPhotoM.Common;
    using QPhotoM.Data.Models;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin.a@abv.bg",
                Description = "Admin",
            };

            var user = new ApplicationUser
            {
                UserName = "gosho",
                Email = "gosho.g@abv.bg",
                Description = "Cool life",
            };

            await SeedUserAsync(userManager, adminUser);
            await SeedUserAsync(userManager, user);

            // await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
            await userManager.AddToRoleAsync(user, GlobalConstants.UserRoleName);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, ApplicationUser user)
        {
            var userExist = await userManager.FindByNameAsync(user.UserName);
            if (userExist == null)
            {
                var result = await userManager.CreateAsync(user, "123456");
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
