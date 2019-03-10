using VSP.Data.Repositories;
using VSP.Services.Contracts;
using System;
using System.Linq;
using VSP.Data.Models;
using System.Threading.Tasks;
using System.Text;

namespace VSP.Services
{
    public class VideoService : IVideoService
    {
        private readonly IRepository<FileData> _fileDataGenericRepo;
        private readonly IMongoRepository<FileData> _fileDataMongoRepo;

        public VideoService(IRepository<FileData> fileDataGenericRepo, IMongoRepository<FileData> fileDataMongoRepo)
        {
            _fileDataGenericRepo = fileDataGenericRepo;
            _fileDataMongoRepo = fileDataMongoRepo;
        }

        public Task<string> AddAsync(IFileData fileData, string subDir = null)
        {
            var test = fileData as FileData;

            var uploadVideoTask = new Task<string>(() =>
            {
                test.GridFsId = _fileDataMongoRepo.UploadBytes(test.FileName, Encoding.ASCII.GetBytes(test.FileContents)).ToString();

                _fileDataGenericRepo.Add(test);
                _fileDataGenericRepo.SaveChanges();

                return test.Url;
            });
            uploadVideoTask.Start();

            return uploadVideoTask;
        }

        public Task<IFileData> GetAsync(string url)
        {
            _fileDataGenericRepo.GetById(url);

            throw new NotImplementedException();
        }

        public IQueryable<FileData> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public void Delete(string identifier)
        {
            throw new NotImplementedException();
        }
    }
}
