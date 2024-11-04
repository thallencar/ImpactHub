using MongoDB.Bson;

namespace ImpactHub.Business.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {

        Task<TEntity> GetById(ObjectId? id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<int> SaveChanges();
    }
    
    
}
