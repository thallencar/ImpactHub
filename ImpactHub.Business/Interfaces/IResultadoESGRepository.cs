using ImpactHub.Business.Models;
using MongoDB.Bson;

namespace ImpactHub.Business.Interfaces
{
    public interface IResultadoESGRepository : IBaseRepository<ResultadoESGModel>
    {
        Task <ResultadoESGModel> GetResultadoESG (ObjectId? id);
        Task<IEnumerable<ResultadoESGModel>> GetAllResultadosESG();
    }
}
