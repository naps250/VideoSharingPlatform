using MongoDB.Driver;
using System;
using Microsoft.Extensions.Options;

namespace VideoSharingPlatform.Data.MongoDb
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; set; }

        public MongoDbContext(IOptionsMonitor<MongoDbOptions> optionsAccessor)
        {
            var options = optionsAccessor.CurrentValue;
            var dbName = options.MongoDatabaseName;
            // Creating credentials
            var credential = MongoCredential.CreateCredential
                            (dbName,
                             options.MongoUsername,
                             options.MongoPassword);

            // Creating MongoClientSettings
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(options.MongoHost, Convert.ToInt32(options.MongoPort))
            };

            Database = new MongoClient(settings).GetDatabase(dbName);
        }
    }
}
