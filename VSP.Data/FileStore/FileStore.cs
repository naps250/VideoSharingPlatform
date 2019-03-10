using System;
using System.Text;
using System.Threading.Tasks;
using VSP.Data.Models;
using VSP.Data.MongoDb;
using VSP.Data.Repositories;

namespace VSP.Data.FileStore
{
    public class FileStore : IFileStore
    {
        private ApplicationDbContext _dbContext;
        private MongoDbContext _mongoDbContext;

        public FileStore(ApplicationDbContext dbContext, MongoDbContext mongoDbContext, IRepository<FileData> videos)
        {
            _dbContext = dbContext;
            _mongoDbContext = mongoDbContext;
        }

        public Task<string> AddAsync(IFileData fileData, string subDir = null)
        {
            var test = fileData as FileData;

            var uploadVideoTask = new Task<string>(() =>
            {
                test.GridFsId = _mongoDbContext.Bucket.UploadFromBytes(test.FileName, Encoding.ASCII.GetBytes(test.FileContents)).ToString();

                _dbContext.FileDatas.Add(test);
                _dbContext.SaveChanges();

                return test.Url;
            });
            uploadVideoTask.Start();

            return uploadVideoTask;
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
