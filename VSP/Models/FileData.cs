using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VideoSharingPlatform.FileStore;

namespace VideoSharingPlatform.Models
{
    public sealed class FileData : IFileData
    {
        private static readonly char DELIMITER = '|';

        [BsonIgnore]
        public int Id { get; set; }

        [Required]
        [BsonIgnore]
        public string FileName { get; set; }

        [Required]
        [BsonIgnore]
        public string Author { get; set; }

        [BsonIgnore]
        private string _tags;

        [NotMapped]
        [BsonIgnore]
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

        [BsonRequired]
        public string GridFsId { get; set; }

        [NotMapped]
        [BsonIgnore]
        public string FileContents { get; set; }

        [Required]
        [BsonIgnore]
        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
