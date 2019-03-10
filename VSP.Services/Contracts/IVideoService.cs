using System.Linq;
using System.Threading.Tasks;
using VSP.Data.Models;

namespace VSP.Services.Contracts
{
    public interface IVideoService
    {
        Task<string> AddAsync(IFileData fileData, string subDir = null);

        Task<IFileData> GetAsync(string identifier);

        IQueryable<FileData> Search(string searchTerm);

        void Delete(string identifier);
    }
}
