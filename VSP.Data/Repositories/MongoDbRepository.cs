using MongoDB.Bson;
using System;
using System.Linq;
using VSP.Data.MongoDb;

namespace VSP.Data.Repositories
{
    public class MongoDbRepository<T> : IRepository<T>, IMongoRepository<T> where T : class
    {
        public MongoDbRepository(MongoDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
        }

        protected MongoDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(object id)
        {
            throw new NotImplementedException();
        }

        public virtual ObjectId UploadBytes(string name, byte[] data)
        {
            return Context.Bucket.UploadFromBytes(name, data);
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual T Attach(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Detach(T entity)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
