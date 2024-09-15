using ImpactHub.Repositories;
using ImpactHub.Services.CEPService;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ImpactHub.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly ICEPService cepService;

        public EnderecoController(ICEPService _cepService)
        {
            cepService = _cepService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CEPResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public Task<CEPResponse> BuscarCEP(string cep)
        {
            LogManager.Instance.Log("EnderecoController: Chamada do método para buscar o CEP");

            return cepService.BuscarCEP(cep);
        }

        [HttpGet]
        [Route("DescobrirMeuCEP")]
        [ProducesResponseType(typeof(CEPResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public Task<IEnumerable<CEPResponse>> NaoSeiMeuCEP(string estado, string cidade, string rua)
        {
            LogManager.Instance.Log("EnderecoController: Chamada do método para descobrir o CEP, baseado nas informações requeridas.");

            return cepService.NaoSeiMeuCEP(estado, cidade, rua);
        }

    }
}
