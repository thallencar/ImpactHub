using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using MongoDB.Bson.Serialization.IdGenerators;

namespace ImpactHub.Business.Models
{
    [Collection("enderecos")]
    public class EnderecoModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId IdEndereco { get; set; }

        [BsonElement("cep")]
        public string Cep { get; set; }

        [BsonElement("estado")]
        public string Estado { get; set; }

        [BsonElement("cidade")]
        public string Cidade { get; set; }

        [BsonElement("bairro")]
        public string Bairro { get; set; }

        [BsonElement("logradouro")]
        public string Logradouro { get; set; }

        [BsonElement("numero")]
        [BsonRepresentation(BsonType.Int32)]
        public int Numero { get; set; }

        [BsonElement("complemento")]
        public string? Complemento { get; set; }

        [BsonElement("pontoDeReferencia")]
        public string PontoReferencia { get; set; }

        [BsonElement("nomeEmpresa")]
        public string NomeEmpresa { get; set; }
    }
}
