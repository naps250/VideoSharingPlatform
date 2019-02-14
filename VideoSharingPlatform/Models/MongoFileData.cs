using MongoDB.Bson.Serialization.Attributes;

namespace VideoSharingPlatform.Models
{
    public class MongoFileData
    {
        [BsonId]
        public long Id { get; set; }

        [BsonElement("FileData")]
        public string FileContents { get; set; }
    }
}
