using AutoMapper;
using ImpactHub.API.Requests;
using ImpactHub.API.Responses;
using ImpactHub.Business.Interfaces;
using ImpactHub.Business.Models;
using ImpactHub.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionarioESGController : ControllerBase
    {
        private readonly IQuestionarioESGRepository _questionarioESGRepository;
        private readonly IMapper _mapper;

        public QuestionarioESGController(IQuestionarioESGRepository questionarioESGRepository, IMapper mapper)
        {
            _questionarioESGRepository = questionarioESGRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionarioESGResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllQuestionarios()
        {
            var responseQuestionarios = _mapper.Map<IEnumerable<QuestionarioESGResponse>>(await _questionarioESGRepository.GetAllQuestionariosESG());

            return Ok(responseQuestionarios);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(QuestionarioESGModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetQuestionario(string id)
        {
            var objectId = new ObjectId(id);

            var questionario = await GetQuestionarioById(objectId);

            if (questionario == null) return NotFound();

            return Ok(questionario);
        }

        [HttpPost]
        [ProducesResponseType(typeof(QuestionarioESGModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCadastro([FromBody] QuestionarioESGRequest questionarioESGRequest)
        {
            if ((questionarioESGRequest == null) || (!ModelState.IsValid)) return BadRequest(ModelState);

            var questionario = _mapper.Map<QuestionarioESGModel>(questionarioESGRequest);

            await _questionarioESGRepository.Add(questionario);

            return StatusCode(201, questionario);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateQuestionario(string id, [FromBody] QuestionarioESGRequest questionarioESGRequest)
        {
            var objectId = new ObjectId(id);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var atualizacaoQuestionario = await GetQuestionarioById(objectId);

            if (atualizacaoQuestionario == null) return NotFound();

            _mapper.Map(questionarioESGRequest, atualizacaoQuestionario);

            await _questionarioESGRepository.Update(atualizacaoQuestionario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteQuestionario(string id)
        {
            var objectId = new ObjectId(id);

            var questionario = await GetQuestionarioById(objectId);

            if (questionario == null) return NotFound();

            await _questionarioESGRepository.Delete(questionario);

            return NoContent();
        }

        private async Task<QuestionarioESGModel> GetQuestionarioById(ObjectId id)
        {
            return await _questionarioESGRepository.GetQuestionarioESG(id);
        }
    }
}
