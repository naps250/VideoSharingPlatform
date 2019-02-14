using MongoDB.Bson.Serialization.Attributes;
using System.IO;
using VideoSharingPlatform.FileStore;

namespace VideoSharingPlatform.Models
{
    public sealed class FileData : IFileData
    {
        public string Author { get; set; }

        public string[] Tags { get; set; }

        public MongoFileData FileContents { get; set; }
    }
}
