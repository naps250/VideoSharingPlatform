namespace Fapp.Data.DbInitializer
{
    using Fapp.Data.Models;
	using Microsoft.AspNetCore.Identity;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public static class DbInitializer
    {
        public static async Task Initialize(FappDbContext context, UserManager<FappUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new FappUser[] {
                new FappUser()
                {
                    FirstName = "Stefan",
                    LastName = "Hristov",
                    UserName = "stefan@fapp.com",
                    Email = "stefan@fapp.com"
                },
                new FappUser
                {
                    FirstName = "Atanas",
                    LastName = "Bozhanin",
                    UserName = "atanasb@fapp.com",
                    Email = "atanasb@fapp.com"
                }
            };

            foreach (var user in users)
            {
                var result = await userManager.CreateAsync(user, "Admin123!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Failed to create default user");
                }
            }

			context.SaveChanges();
        }
    }
}
