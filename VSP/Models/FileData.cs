using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using VideoSharingPlatform.FileStore;

namespace VideoSharingPlatform.Models
{
    public sealed class FileData : IFileData
    {
        private static readonly char DELIMITER = '|';

        [BsonIgnore]
        public int Id { get; set; }

        [BsonIgnore]
        public string FileName { get; set; }

        [BsonIgnore]
        public string Author { get; set; }

        [BsonIgnore]
        private string _tags;

        [BsonIgnore]
        [NotMapped]
        public string[] Tags
        {
            get
            {
                return _tags.Split(DELIMITER);
            }
            set
            {
                _tags = value != null ? string.Join($"{DELIMITER}", value) : null;
            }
        }

        [BsonId]
        public long MongoId { get; set; }

        [NotMapped]
        [BsonElement("FileData")]
        public string FileContents { get; set; }
    }
}
