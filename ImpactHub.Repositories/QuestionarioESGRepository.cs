using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ImpactHub.Repositories
{
    public class QuestionarioESGRepository : BaseRepository<QuestionarioESGModel>, IQuestionarioESGRepository
    {
        public QuestionarioESGRepository(ImpactHubDbContext context) : base(context) { }

        public async Task<IEnumerable<QuestionarioESGModel>> GetAllQuestionariosESG()
        {
            return await _context.Questionarios.AsNoTracking().ToListAsync();
        }

        public async Task<QuestionarioESGModel> GetQuestionarioESG(ObjectId? id)
        {
            return await _context.Questionarios.AsNoTracking().FirstOrDefaultAsync(q => q.IdQuestionario == id);

        }
    }
}
