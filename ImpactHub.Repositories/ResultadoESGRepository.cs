using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ImpactHub.Repositories
{
    public class ResultadoESGRepository : BaseRepository<ResultadoESGModel>, IResultadoESGRepository
    {
        public ResultadoESGRepository(ImpactHubDbContext context) : base(context) { }

        public async Task<IEnumerable<ResultadoESGModel>> GetAllResultadosESG()
        {
            return await _context.Resultados.AsNoTracking().ToListAsync();
        }

        public async Task<ResultadoESGModel> GetResultadoESG(ObjectId? id)
        {
            return await _context.Resultados.AsNoTracking().FirstOrDefaultAsync(r => r.IdResultado == id);

        }
    }
}
