using System.Web;
using VideoSharingPlatform.FileStore;

namespace VideoSharingPlatform.Models.DTOs
{
    public class FileDataDto : HttpPostedFileBase
    {
        public string Author { get; set; }

        public string[] Tags { get; set; }
    }
}
