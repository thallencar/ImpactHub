using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Services.CEPService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ICEPService _cepService;

        public EnderecoController(IEnderecoRepository enderecoRepository, ICEPService cepService)
        {
            _enderecoRepository = enderecoRepository;
            _cepService = cepService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnderecoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEndereco(int id)
        {
            var endereco = await _enderecoRepository.GetEndereco(id);

            if (endereco == null) return NotFound();

            return Ok(endereco);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EnderecoModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var enderecos = await _enderecoRepository.GetAllEnderecos();

            return Ok(enderecos);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EnderecoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEndereco([FromBody] EnderecoModel endereco)
        {
            if (endereco == null) return BadRequest();

            await _enderecoRepository.Add(endereco);

            return StatusCode(201, endereco);

        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateEndereco(int id, [FromBody] EnderecoModel endereco)
        {
            if (id != endereco.IdEndereco) return BadRequest();

            var atualizacaoEndereco = await _enderecoRepository.GetEndereco(id);

            if (atualizacaoEndereco == null) return NotFound();

            await _enderecoRepository.Update(endereco);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _enderecoRepository.GetEndereco(id);

            if (endereco == null) return NotFound();

            await _enderecoRepository.Delete(endereco);

            return NoContent();
        }

        [HttpGet("BuscarCEP")]
        [ProducesResponseType(typeof(CEPResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> BuscarCEP(string cep)
        {
            var cepResponse = await _cepService.BuscarCEP(cep);

            if (cepResponse == null) return NoContent();

            return Ok(cepResponse);
        }

        [HttpGet("DescobrirCEP")]
        [ProducesResponseType(typeof(IEnumerable<CEPResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> NaoSeiMeuCEP(string estado, string cidade, string rua)
        {
            var cepResponses = await _cepService.NaoSeiMeuCEP(estado, cidade, rua);

            if (cepResponses == null || !cepResponses.Any()) return NoContent();

            return Ok(cepResponses);

        }
    }
}
