using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastrosController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepository;

        public CadastrosController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        // GET: api/cadastros
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CadastroModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCadastros()
        {
            var cadastros = await _cadastroRepository.GetAllCadastros();

            return Ok(cadastros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CadastroModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetCadastro(int id)
        {
            var cadastro = await GetCadastroById(id);

            if (cadastro == null) return NotFound();

            return Ok(cadastro);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CadastroModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCadastro([FromBody] CadastroModel cadastro)
        {
            if (cadastro == null) return BadRequest();

            await _cadastroRepository.Add(cadastro);

            return StatusCode(201, cadastro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateCadastro(int id, [FromBody] CadastroModel cadastro)
        {
            if (id != cadastro.IdCadastro) return BadRequest();

            var atualizacaoCadastro = await GetCadastroById(id);

            if (atualizacaoCadastro == null) return NotFound();

            await _cadastroRepository.Update(cadastro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteCadastro(int id)
        {
            var cadastro = await GetCadastroById(id);

            if (cadastro == null) return NotFound();

            await _cadastroRepository.Delete(cadastro);

            return NoContent();
        }

        private async Task<CadastroModel> GetCadastroById(int id)
        {
            return await _cadastroRepository.GetCadastro(id);
        }
    }
}
