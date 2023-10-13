using BlockChain.Data.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlockChain.Data.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IAppDbContext dbContext;
        public Repository(IAppDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();

        }
        public T Find(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }
    }
}


