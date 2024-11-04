using ImpactHub.Business.Models;
using MongoDB.Bson;

namespace ImpactHub.Business.Interfaces
{
    public interface ICadastroRepository : IBaseRepository<CadastroModel>
    {
        Task<CadastroModel> GetCadastro(ObjectId? id);
        Task<IEnumerable<CadastroModel>> GetAllCadastros();
    }
}
