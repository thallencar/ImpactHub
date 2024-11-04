using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.EntityFrameworkCore;

namespace ImpactHub.Business.Models
{
    [Collection("questionario")]
    public class QuestionarioESGModel
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId IdQuestionario { get; set; }

        [BsonElement("titulo")]
        public string Titulo { get; set; }

        [BsonElement("categoria")]
        public string Categoria { get; set; }

        [BsonElement("pergunta1")]
        public string Pergunta1 { get; set; }

        [BsonElement("pergunta2")]
        public string Pergunta2 { get; set; }

        [BsonElement("pergunta3")]
        public string Pergunta3 { get; set; }

        [BsonElement("pergunta4")]
        public string Pergunta4 { get; set; }

        [BsonElement("pergunta5")]
        public string Pergunta5 { get; set; }

        [BsonElement("pergunta6")]
        public string Pergunta6 { get; set; }

        [BsonElement("pergunta7")]
        public string Pergunta7 { get; set; }

        [BsonElement("pergunta8")]
        public string Pergunta8 { get; set; }

        [BsonElement("pergunta9")]
        public string Pergunta9 { get; set; }

        [BsonElement("pergunta10")]
        public string Pergunta10 { get; set; }
    }
}
