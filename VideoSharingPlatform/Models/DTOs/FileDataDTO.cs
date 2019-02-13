using System.Web;
using VideoSharingPlatform.FileStore;

namespace VideoSharingPlatform.Models.DTOs
{
    public class FileDataDTO : IFileData
    {
        public string[] Tags { get; set; }

        public string Owner { get; set; }

        HttpPostedFile FileData { get; set; }
    }
}
