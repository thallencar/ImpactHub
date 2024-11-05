using AutoMapper;
using ImpactHub.API.Requests;
using ImpactHub.API.Responses;
using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Services.CEPService;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly ICEPService _cepService;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoRepository enderecoRepository, ICEPService cepService, IMapper mapper)
        {
            _enderecoRepository = enderecoRepository;
            _cepService = cepService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<EnderecoResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var responseEnderecos = _mapper.Map<IEnumerable<EnderecoResponse>>(await _enderecoRepository.GetAllEnderecos());

            return Ok(responseEnderecos);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EnderecoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetEndereco(string id)
        {
            var objectId = new ObjectId(id);

            var endereco = await GetEnderecoById(objectId);

            if (endereco == null) return NotFound();

            return Ok(endereco);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EnderecoModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateEndereco([FromBody] EnderecoRequest enderecoRequest)
        {
            if ((enderecoRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var endereco = _mapper.Map<EnderecoModel>(enderecoRequest);

            await _enderecoRepository.Add(endereco);

            return StatusCode(201, endereco);

        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateEndereco(string id, [FromBody] EnderecoRequest enderecoRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoEndereco = await _enderecoRepository.GetEndereco(objectId);

            if (atualizacaoEndereco == null) return NotFound();

            _mapper.Map(enderecoRequest, atualizacaoEndereco);

            await _enderecoRepository.Update(atualizacaoEndereco);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteEndereco(string id)
        {
            var objectId = new ObjectId(id);

            var endereco = await _enderecoRepository.GetEndereco(objectId);

            if (endereco == null) return NotFound();

            await _enderecoRepository.Delete(endereco);

            return NoContent();
        }

        private async Task<EnderecoModel> GetEnderecoById(ObjectId id)
        {
            return await _enderecoRepository.GetEndereco(id);
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
