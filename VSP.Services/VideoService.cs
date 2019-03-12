using VSP.Data.Repositories;
using VSP.Services.Contracts;
using System;
using System.Linq;
using VSP.Data.Models;
using System.Threading.Tasks;
using System.Text;
using MongoDB.Bson;

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
            var newFile = fileData as FileData;

            var uploadVideoTask = new Task<string>(() =>
            {
                newFile.GridFsId = _fileDataMongoRepo.UploadBytes(newFile.FileName, newFile.FileContents).ToString();

                _fileDataGenericRepo.Add(newFile);
                _fileDataGenericRepo.SaveChanges();

                return newFile.Id.ToString();
            });
            uploadVideoTask.Start();

            return uploadVideoTask;
        }

        public Task<IFileData> GetAsync(string id)
        {
            var downloadVideoTask = new Task<IFileData>(() =>
            {
                FileData video;
                video = _fileDataGenericRepo.GetById(id);
                video.FileContents = _fileDataMongoRepo.DownloadBytes(new ObjectId(video.GridFsId));

                return video;
            });
            downloadVideoTask.Start();

            return downloadVideoTask;
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
