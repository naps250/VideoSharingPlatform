namespace Fapp.Services.Data.Contracts
{
    using System.Linq;
    using Fapp.Data.Models;

    public interface IUsersService
    {
        IQueryable<FappUser> All();
        IQueryable<FappUser> GetByUserName(string username);
    }
}
