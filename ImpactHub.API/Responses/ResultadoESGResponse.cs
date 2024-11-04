using ImpactHub.Business.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ImpactHub.API.Responses
{
    public class ResultadoESGResponse
    {
        public double PontuacaoAmbiental { get; set; }
        public double PontuacaoSocial { get; set; }
        public double PontucaoGovernanca { get; set; }
        public string StatusResultado { get; set; }
        public DateTime DataGeracao { get; set; }
        public string NomeEmpresa { get; set; }
    }
}
