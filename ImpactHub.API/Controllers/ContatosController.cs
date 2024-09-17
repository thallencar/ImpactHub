using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatosController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatosController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContatoModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllContatos()
        {
            var contato = await _contatoRepository.GetAllContatos();

            return Ok(contato);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContatoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetContato(int id)
        {
            var contato = await GetContatoById(id);

            if (contato == null) return NotFound();

            return Ok(contato);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContatoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateContato([FromBody] ContatoModel contato)
        {
            if (contato == null) return BadRequest();

            await _contatoRepository.Add(contato);

            return StatusCode(201, contato);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateContato(int id, [FromBody] ContatoModel contato)
        {
            if (id != contato.IdContato) return BadRequest();

            var atualizacaoContato = await GetContatoById(id);

            if (atualizacaoContato == null) return NotFound();

            await _contatoRepository.Update(contato);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteContato(int id)
        {
            var contato = await GetContatoById(id);

            if (contato == null) return NotFound();

            await _contatoRepository.Delete(contato);

            return NoContent();
        }

        private async Task<ContatoModel> GetContatoById(int id)
        {
            return await _contatoRepository.GetContato(id);
        }
    }
}
