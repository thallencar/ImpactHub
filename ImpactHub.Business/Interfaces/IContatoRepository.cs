using ImpactHub.Business.Models;
using MongoDB.Bson;

namespace ImpactHub.Business.Interfaces
{
    public interface IContatoRepository : IBaseRepository<ContatoModel>
    {
        Task<ContatoModel> GetContato(ObjectId? id);
        Task<IEnumerable<ContatoModel>> GetAllContatos();
    }
}
