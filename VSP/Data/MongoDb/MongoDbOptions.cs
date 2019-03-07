using System.Configuration;

namespace VideoSharingPlatform.Data.MongoDb
{
    public class MongoDbOptions
    {
        public MongoDbOptions()
        {
            // Reading credentials from app.config file
            MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            MongoUsername = ConfigurationManager.AppSettings["MongoUsername"];
            MongoPassword = ConfigurationManager.AppSettings["MongoPassword"];
            MongoPort = ConfigurationManager.AppSettings["MongoPort"];
            MongoHost = ConfigurationManager.AppSettings["MongoHost"];
        }

        public string MongoDatabaseName { get; set; }
        public string MongoUsername { get; set; }
        public string MongoPassword { get; set; }
        public string MongoPort { get; set; }
        public string MongoHost { get; set; }
    }
}
