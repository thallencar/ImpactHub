using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ImpactHub.Repositories
{
    public class EnderecoRepository : BaseRepository<EnderecoModel>, IEnderecoRepository
    {
        public EnderecoRepository(ImpactHubDbContext context) : base(context) { }

        public async Task<IEnumerable<EnderecoModel>> GetAllEnderecos()
        {
            return await _context.Enderecos.AsNoTracking().ToListAsync();
        }

        public async Task<EnderecoModel> GetEndereco(ObjectId? id)
        {
            return await _context.Enderecos.AsNoTracking().FirstOrDefaultAsync(e => e.IdEndereco == id);
        }
    }

}
