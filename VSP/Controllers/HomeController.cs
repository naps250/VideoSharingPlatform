﻿using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using VSP.Data.Models;
using VSP.Models;
using VSP.Models.DTOs.Request;
using VSP.Services.Contracts;
using System;
using System.Text;

namespace VSP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private static readonly char DELIMITER = ',';

        private IVideoService _videoService;

        public HomeController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadVideo(FileDataDto fileDataDto)
        {
            var file = Request.Form.Files["FileData"];

            var id = string.Empty;

            string[] mimeTypes = new[] { "video/mp4", "video/webm" };

            if (mimeTypes.Contains(file.ContentType))
            {
                var fileData = new FileData()
                {
                    ContentType = file.ContentType,
                    Author = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Tags = fileDataDto.Tags?.Split(DELIMITER),
                    Hero = fileDataDto.Hero
                };

                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                    fileData.FileName = parsedContentDisposition.FileName.ToString().Trim('"');
                    fileData.FileContents = fileBytes;
                }

                //using (var reader = new StreamReader(file.OpenReadStream()))
                //{
                //    var fileContent = reader.ReadToEnd();
                //    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                //    fileData.FileName = parsedContentDisposition.FileName.ToString().Trim('"');
                //    fileData.FileContentsString = fileContent;
                //}

                id = _videoService.AddAsync(fileData).Result;
            }

            return Ok(id);
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
