using System.Threading.Tasks;

namespace VideoSharingPlatform.FileStore
{
    public interface IFileStore
    {
        Task AddAsync(IFileData fileData, string subDir = null);

        Task<IFileData> GetAsync(string identifier);

        void Delete(string identifier);
    }
}
