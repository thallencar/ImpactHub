using AutoMapper;
using ImpactHub.API.Requests;
using ImpactHub.API.Responses;
using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResultadosESGController : ControllerBase
    {
        private readonly IResultadoESGRepository _resultadoESGRepository;
        private readonly IMapper _mapper;

        public ResultadosESGController(IResultadoESGRepository resultadoESGRepository, IMapper mapper)
        {
            _resultadoESGRepository = resultadoESGRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResultadoESGResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAlResultadosESG()
        {
            var responseResultadoESG = _mapper.Map<ResultadoESGResponse>(await _resultadoESGRepository.GetAllResultadosESG());

            return Ok(responseResultadoESG);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResultadoESGModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetResultadoESG(string id)
        {
            var objectId = new ObjectId(id);

            var resultadoESG = await GetResultadoESGById(objectId);

            if (resultadoESG == null) return NotFound();

            return Ok(resultadoESG);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResultadoESGModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateResultadoESG([FromBody] ResultadoESGRequest resultadoESGRequest)
        {
            if ((resultadoESGRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var resultadoESG = _mapper.Map<ResultadoESGModel>(resultadoESGRequest);

            await _resultadoESGRepository.Add(resultadoESG);

            return StatusCode(201, resultadoESG);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateResultadoESG(string id, [FromBody] ResultadoESGRequest resultadoESGRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoResultado = await GetResultadoESGById(objectId);

            if (atualizacaoResultado == null) return NotFound();

            _mapper.Map(resultadoESGRequest, atualizacaoResultado);

            await _resultadoESGRepository.Update(atualizacaoResultado);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteResultadoESG(string id)
        {
            var objectId = new ObjectId(id);

            var resultadoESG = await GetResultadoESGById(objectId);

            if (resultadoESG == null) return NotFound();

            await _resultadoESGRepository.Delete(resultadoESG);

            return NoContent();
        }

        private async Task<ResultadoESGModel> GetResultadoESGById(ObjectId id)
        {
            return await _resultadoESGRepository.GetResultadoESG(id);
        }
    }
}
