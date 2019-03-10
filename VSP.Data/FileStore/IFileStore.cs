using System.Threading.Tasks;
using VSP.Data.Models;

namespace VSP.Data.FileStore
{
    public interface IFileStore
    {
        Task<string> AddAsync(IFileData fileData, string subDir = null);

        Task<IFileData> GetAsync(string identifier);

        void Delete(string identifier);
    }
}
