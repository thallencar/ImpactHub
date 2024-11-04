using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ImpactHub.Repositories
{
    public class CadastroRepository : BaseRepository<CadastroModel>, ICadastroRepository
    {
        public CadastroRepository(ImpactHubDbContext context) : base(context) { }

        
        public async Task<IEnumerable<CadastroModel>> GetAllCadastros()
        {
            return await _context.Cadastros.AsNoTracking().ToListAsync();
        }

        public async Task<CadastroModel> GetCadastro(ObjectId? id)
        {
            return await _context.Cadastros.AsNoTracking().FirstOrDefaultAsync(c => c.IdCadastro == id);
        }
        
     }
    
}
