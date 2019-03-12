using System;
using System.Linq;

namespace VSP.Data.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(string id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(string id);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
