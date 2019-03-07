namespace Fapp.Services.Data
{
    using Fapp.Data.Models;
    using Fapp.Data.Repositories;
    using Fapp.Services.Data.Contracts;
    using System.Linq;

    public class UsersService : IUsersService
    {
        private readonly IRepository<FappUser> users;

        public UsersService(IRepository<FappUser> users)
        {
            this.users = users;
        }

        public IQueryable<FappUser> All()
        {
            var all = this.users.All();
            return all;
        }

        public IQueryable<FappUser> GetByUserName(string username)
        {
            var usersByUsername = this.users
                .All()
                .Where(u => u.UserName == username);

            return usersByUsername;
        }
    }
}
