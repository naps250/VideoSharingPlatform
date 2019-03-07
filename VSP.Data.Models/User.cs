namespace Fapp.Data.Models
{
	using Microsoft.AspNetCore.Identity;

    public class FappUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
