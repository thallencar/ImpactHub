using ImpactHub.Business.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace ImpactHub.Business.Models
{
    [Collection("contatos")]
    public class ContatoModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId IdContato { get; set; }

        [BsonElement("ddi")]
        [BsonRepresentation(BsonType.Int32)]
        public int Ddi { get; set; }

        [BsonElement("ddd")]
        [BsonRepresentation(BsonType.Int32)]
        public int Ddd { get; set; }

        [BsonElement("telefone")]
        public string Telefone { get; set; }

        [BsonElement("tipoContato")]
        [BsonRepresentation(BsonType.String)]
        public TipoContatoEnum TipoContato { get; set; }

        [BsonElement("statusContato")]
        [BsonRepresentation(BsonType.String)]
        public StatusContatoEnum StatusContato { get; set; }

        [BsonElement("codigoOperadora")]
        [BsonRepresentation(BsonType.Int32)]
        public int CodigoOperadora { get; set; }

        [BsonElement("nomeResponsavel")]
        public string NomeResponsavel { get; set; }

        [BsonElement("nomeEmpresa")]
        public string NomeEmpresa { get; set; }
    }
}


