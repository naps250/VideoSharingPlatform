namespace VideoSharingPlatform.Data.MongoDb
{
    public class MongoDbOptions
    {
        public  MongoDbOptions()
        {
        }

        public string MongoDatabaseName { get; set; }
        public string MongoUsername { get; set; }
        public string MongoPassword { get; set; }
        public string MongoPort { get; set; }
        public string MongoHost { get; set; }
    }
}
