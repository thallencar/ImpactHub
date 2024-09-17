using ImpactHub.Business.Models;

namespace ImpactHub.Business.Interfaces
{
    public interface IContatoRepository : IBaseRepository<ContatoModel>
    {
        Task<ContatoModel> GetContato(int id);
        Task<IEnumerable<ContatoModel>> GetAllContatos();
    }
}
