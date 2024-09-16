using ImpactHub.Business.Models;

namespace ImpactHub.Business.Interfaces
{
    public interface ICadastroRepository : IBaseRepository<CadastroModel>
    {
        Task<CadastroModel> GetCadastro(int id);
        Task<IEnumerable<CadastroModel>> GetAllCadastros();
    }
}
