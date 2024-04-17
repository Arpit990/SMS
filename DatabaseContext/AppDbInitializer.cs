using SpeakerManagementSystem.Models;
using SpeakerManagementSystem.Data.Static;
using Microsoft.AspNetCore.Identity;
using SpeakerManagementSystem.DatabaseContext;

namespace SpeakerManagementSystem.Context
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SpeakerMgmtDbContext>();

                if(context != null && context.Database.EnsureCreated())
                {
                    //Tasks
                    /*if (!context.Cities.Any())
                    {
                        context.Cities.AddRange(new List<City>()
                        {
                            new City()
                            {
                                CityName = "City 1",
                                ZipCode = 345396
                            },
                            new City()
                            {
                                CityName = "City 2",
                                ZipCode = 843695
                            },
                            new City()
                            {
                                CityName = "City 3",
                                ZipCode = 284635
                            }
                        });
                        context.SaveChanges();
                    }*/
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.Speaker))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Speaker));

                //Users
                /*var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@shmarketing.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FirstName = "Arpit",
                        LastName = "Santoki",
                        UserName = "arpit_santoki",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.SuperAdmin);
                }
                
                
                string appUserEmail = "user@shmarketing.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FirstName = "Arpit",
                        LastName = "Santoki",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Speaker);
                }*/
            }
        }
    }
}
