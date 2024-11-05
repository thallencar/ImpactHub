using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using MongoDB.Bson.Serialization.IdGenerators;
using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    [Collection("resultados")]
    public class ResultadoESGModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId IdResultado { get; set; }

        [BsonElement("pontuacaoAmbiental")]
        [BsonRepresentation(BsonType.Double)]
        public double PontuacaoAmbiental { get; set; }

        [BsonElement("pontuacaoSocial")]
        [BsonRepresentation(BsonType.Double)]
        public double PontuacaoSocial { get; set; }

        [BsonElement("pontuacaoGovernanca")]
        [BsonRepresentation(BsonType.Double)]
        public double PontuacaoGovernanca { get; set; }

        [BsonElement("statusResultado")]
        [BsonRepresentation(BsonType.String)]
        public StatusResultadoEnum StatusResultado { get; set; } = StatusResultadoEnum.NaoAvaliado;

        [BsonElement("dataGeracao")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DataGeracao { get; set; } = DateTime.UtcNow;

        [BsonElement("nomeEmpresa")]
        public string NomeEmpresa { get; set; }
    }
}
