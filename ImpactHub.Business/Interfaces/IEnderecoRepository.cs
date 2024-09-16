using ImpactHub.Business.Models;

namespace ImpactHub.Business.Interfaces
{
    public interface IEnderecoRepository : IBaseRepository<EnderecoModel>
    {
        Task<EnderecoModel> GetEndereco(int id);
        Task<IEnumerable<EnderecoModel>> GetAllEnderecos();
    }
}
