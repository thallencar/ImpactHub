using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ImpactHub.Repositories
{
    public class ContatoRepository : BaseRepository<ContatoModel>, IContatoRepository
    {
        public ContatoRepository(ImpactHubDbContext context) : base(context) { }

        public async Task<IEnumerable<ContatoModel>> GetAllContatos()
        {
            return await _context.Contatos.AsNoTracking().ToListAsync();
        }

        public async Task<ContatoModel> GetContato(ObjectId? id)
        {
            return await _context.Contatos.AsNoTracking().FirstOrDefaultAsync(c => c.IdContato == id);
        }
    }
}
