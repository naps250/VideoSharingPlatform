using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using VideoSharingPlatform.FileStore;

namespace VideoSharingPlatform.Models
{
    public class FileData : IFileData
    {
        public long Id { get; set; }

        public string[] Tags { get; set; }

        public string StoredUnderName { get; set; }

        public string Owner { get; set; }

        public HttpPostedFile FileBytes { get; set; }
    }
}
