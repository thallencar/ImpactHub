using ImpactHub.Business.Models;
using MongoDB.Bson;

namespace ImpactHub.Business.Interfaces
{
    public interface IQuestionarioESGRepository : IBaseRepository<QuestionarioESGModel>
    {
        Task<QuestionarioESGModel> GetQuestionarioESG(ObjectId? id);
        Task<IEnumerable<QuestionarioESGModel>> GetAllQuestionariosESG();
    }
}
