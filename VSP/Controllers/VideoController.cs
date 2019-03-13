using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetVideo(string id)
        {
            var video = _videoService.GetAsync(id).Result;

            var file = File(video.FileContents, video.ContentType, video.Url);

            return file;
        }
    }
}