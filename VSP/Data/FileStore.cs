using System;
using System.Text;
using System.Threading.Tasks;
using VideoSharingPlatform.Data.MongoDb;
using VideoSharingPlatform.FileStore;
using VideoSharingPlatform.Models;

namespace VideoSharingPlatform.Data
{
    public class FileStore : IFileStore
    {
        private ApplicationDbContext _dbContext;
        private MongoDbContext _mongoDbContext;

        public FileStore(ApplicationDbContext dbContext, MongoDbContext mongoDbContext)
        {
            _dbContext = dbContext;
            _mongoDbContext = mongoDbContext;
        }

        public Task AddAsync(IFileData fileData, string subDir = null)
        {
            var test = fileData as FileData;

            test.GridFsId = _mongoDbContext.Bucket.UploadFromBytes(test.FileName, Encoding.ASCII.GetBytes(test.FileContents)).ToString();

            _dbContext.FileDatas.Add(test);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<IFileData> GetAsync(string identifier)
        {
            throw new NotImplementedException();
        }

        public void Delete(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
