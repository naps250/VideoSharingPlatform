using VSP.Data.Repositories;
using VSP.Services.Contracts;
using System;
using System.Linq;
using VSP.Data.Models;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.Generic;

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
                FileData video = _fileDataGenericRepo.GetById(id);
                video.FileContents = _fileDataMongoRepo.DownloadBytes(new ObjectId(video.GridFsId));

                return video;
            });
            downloadVideoTask.Start();

            return downloadVideoTask;
        }

        public List<FileData> Search(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            var tags = _fileDataGenericRepo.All()
                .Where(x => x.FileName.ToLower().Contains(searchTerm)
                    || x.Tags.Contains(searchTerm, StringComparer.OrdinalIgnoreCase)
                    || x.Hero.ToString().ToLower().Contains(searchTerm)
                    || x.Author.ToLower().Contains(searchTerm))
                .ToList();

            return tags;
        }

        public void Delete(string identifier)
        {
            throw new NotImplementedException();
        }

        public List<string> GetTagsList()
        {
            var tags = _fileDataGenericRepo.All()
                .Select(x => x.Tags)
                .SelectMany(y => y)
                .Distinct()
                .ToList();

            return tags;
        }
    }
}
