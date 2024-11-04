using ImpactHub.Business.Models;
using MongoDB.Bson;

namespace ImpactHub.Business.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<EnderecoModel>
    {
        Task<EnderecoModel> GetEndereco(ObjectId? id);
        Task<IEnumerable<EnderecoModel>> GetAllEnderecos();
    }
}
