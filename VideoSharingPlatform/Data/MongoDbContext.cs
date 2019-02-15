using MongoDB.Driver;
using System;
using System.Configuration;

namespace VideoSharingPlatform.Data
{
    public class MongoDbContext
    {
        MongoClient _client { get; set; }

        public IMongoDatabase Database { get; set; }

        public MongoDbContext()
        {
            // Reading credentials from Web.config file
            var MongoDatabaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            var MongoUsername = ConfigurationManager.AppSettings["MongoUsername"];
            var MongoPassword = ConfigurationManager.AppSettings["MongoPassword"];
            var MongoPort = ConfigurationManager.AppSettings["MongoPort"];
            var MongoHost = ConfigurationManager.AppSettings["MongoHost"];

            // Creating credentials
            var credential = MongoCredential.CreateCredential
                            (MongoDatabaseName,
                             MongoUsername,
                             MongoPassword);

            // Creating MongoClientSettings
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
            };
            _client = new MongoClient(settings);
            Database = _client.GetDatabase(MongoDatabaseName);
        }
    }
}
