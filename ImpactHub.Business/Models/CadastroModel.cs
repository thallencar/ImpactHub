using ImpactHub.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace ImpactHub.Business.Models
{
    [Collection("cadastros")]
    public class CadastroModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId IdCadastro { get; set; }

        [BsonElement("nome")]
        public string NomeEmpresa { get; set; }

        [BsonElement("cnpj")]
        public string Cnpj { get; set; }

        [BsonElement("inscricaoEstadual")]
        public string InscricaoEstadual { get; set; }

        [BsonElement("razaoSocial")]
        public string RazaoSocial { get; set; }

        [BsonElement("porte")]
        [BsonRepresentation(BsonType.String)]
        public PorteEmpresaEnum Porte { get; set; }

        [BsonElement("dataAbertura")]
        public DateTime DataAbertura { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("usuario")]
        public string NomeUsuario { get; set; }

        [BsonElement("senha")]
        public string Senha { get; set; }

        [BsonElement("statusMonitoramento")]
        [BsonRepresentation(BsonType.String)]
        public StatusMonitoramentoEnum StatusMonitoramento { get; set; } = StatusMonitoramentoEnum.NaoIniciado;
    }
}
