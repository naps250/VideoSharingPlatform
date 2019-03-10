using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VSP.Data.Models.Enums;

namespace VSP.Data.Models
{
    public sealed class FileData : IFileData
    {
        private static readonly char DELIMITER = '|';

        private string _tags;
        private string _url;
        private HeroesEnum _hero;

        [BsonIgnore]
        public int Id { get; set; }

        [Required]
        [BsonIgnore]
        public string Url
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_url))
                {
                    _url = CreateMD5Url($"{FileName}{Author}{Tags}{UploadDate}");
                }
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        [Required]
        [BsonIgnore]
        public string FileName { get; set; }

        [Required]
        [BsonIgnore]
        public string Author { get; set; }

        [Required]
        [BsonIgnore]
        public int Hero
        {
            get
            {
                return (int)_hero;
            }
            set
            {
                _hero = (HeroesEnum)value;
            }
        }

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

        private string CreateMD5Url(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
