using MongoDB.Bson;
using System;

namespace VSP.Data.Repositories
{
    public interface IMongoRepository<T> : IDisposable where T : class
    {
        ObjectId UploadBytes(string name, byte[] data);

        byte[] DownloadBytes(ObjectId id);
    }
}
