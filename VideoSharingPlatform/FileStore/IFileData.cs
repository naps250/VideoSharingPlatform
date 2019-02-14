using VideoSharingPlatform.Models;

namespace VideoSharingPlatform.FileStore
{
    public interface IFileData
    {
        string Author { get; set; }

        string[] Tags { get; set; }

        MongoFileData FileContents { get; set; }
    }
}
