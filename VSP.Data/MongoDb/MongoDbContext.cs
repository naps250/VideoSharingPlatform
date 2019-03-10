using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;

namespace VSP.Data.MongoDb
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; set; }

        public GridFSBucket Bucket { get; set; }

        public MongoDbContext(MongoDbOptions mongoDbOptions)
        {
            var dbName = mongoDbOptions.MongoDatabaseName;
            // Creating credentials
            var credential = MongoCredential.CreateCredential
                            (dbName,
                             mongoDbOptions.MongoUsername,
                             mongoDbOptions.MongoPassword);

            // Creating MongoClientSettings
            var settings = new MongoClientSettings
            {
                Server = new MongoServerAddress(mongoDbOptions.MongoHost, Convert.ToInt32(mongoDbOptions.MongoPort))
            };

            Database = new MongoClient(settings).GetDatabase(dbName);

            Bucket = new GridFSBucket(Database, new GridFSBucketOptions()
            {
                BucketName = "Highlights"
            });
        }
    }
}
