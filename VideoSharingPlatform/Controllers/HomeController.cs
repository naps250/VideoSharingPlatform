using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using VideoSharingPlatform.Data;
using VideoSharingPlatform.Models;
using VideoSharingPlatform.Models.DTOs;

namespace VideoSharingPlatform.Controllers
{
    public class HomeController : Controller
    {
        private IApplicationDbContext _dbContext;
        private IDbContext _mongoDbContext;

        public HomeController(IApplicationDbContext dbContext, IDbContext mongoDbContext)
        {
            _dbContext = dbContext;
            _mongoDbContext = mongoDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadVideo(FileDataDto fileDataDto)
        {
            // Read bytes from http input stream
            BinaryReader b = new BinaryReader(fileDataDto.InputStream);
            byte[] binData = b.ReadBytes(fileDataDto.ContentLength);

            string fileDataString = System.Text.Encoding.UTF8.GetString(binData);

            var fileData = new FileData()
            {
                Author = User.Identity.Name,
                Tags = fileDataDto.Tags,
                FileContents = new MongoFileData()
                {
                    FileContents = fileDataString
                }
            };

            _mongoDbContext.AddAsync(fileData);

            return View();
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
