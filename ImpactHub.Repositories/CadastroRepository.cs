using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ImpactHub.Repositories
{
    public class CadastroRepository : BaseRepository<CadastroModel>, ICadastroRepository
    {
        public CadastroRepository(ImpactHubDbContext context) : base(context) { }

        
        public async Task<IEnumerable<CadastroModel>> GetAllCadastros()
        {
            return await _context.Cadastros.AsNoTracking().ToListAsync();
        }

        public async Task<CadastroModel> GetCadastro(int id)
        {
            return await _context.Cadastros.AsNoTracking().FirstOrDefaultAsync(c => c.IdCadastro == id);
        }
        
     }
    
}
