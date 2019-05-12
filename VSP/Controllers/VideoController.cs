using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;
using VSP.Services.Contracts;

namespace VSP.Controllers
{
    public class VideoController : Controller
    {
        private IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult Watch(string id)
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 946707779, Location = ResponseCacheLocation.Any)]
        public IActionResult GetVideo(string id)
        {
            var video = _videoService.GetAsync(id).Result;

            if(video == null)
            {
                return NotFound();
            }

            var stream = new MemoryStream(video.FileContents);

            var fileStreamResult = new FileStreamResult(stream, new MediaTypeHeaderValue(video.ContentType).MediaType)
            {
                EnableRangeProcessing = true,
                FileDownloadName = video.FileName
            };

            return fileStreamResult;

        }
    }
}