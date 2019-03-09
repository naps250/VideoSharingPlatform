using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using VideoSharingPlatform.FileStore;
using VideoSharingPlatform.Models;
using VideoSharingPlatform.Models.DTOs;

namespace VideoSharingPlatform.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IFileStore _fileStore;

        public HomeController(IFileStore fileStore)
        {
            _fileStore = fileStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadVideo(FileDataDto fileDataDto)
        {
            var file = Request.Form.Files["FileData"];

            string[] mimeTypes = new[] { "video/mp4", "video/webm" };

            if (mimeTypes.Contains(file.ContentType))
            {
                var fileData = new FileData()
                {
                    Author = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Tags = fileDataDto.Tags?.Split(',')
                };

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    var fileContent = reader.ReadToEnd();
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    fileData.FileName = parsedContentDisposition.FileName.ToString().Trim('"');
                    fileData.FileContents = fileContent;
                }

                _fileStore.AddAsync(fileData);
            }

            return NoContent();
        } 

        [HttpGet]
        public IActionResult GetVideo(string id)
        {
            _fileStore.GetAsync(id);

            return View();
        }

        [HttpGet]
        public IActionResult Search(string searchTerm)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
