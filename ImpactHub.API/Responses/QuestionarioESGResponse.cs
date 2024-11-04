using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ImpactHub.API.Responses
{
    public class QuestionarioESGResponse
    {
        public string IdQuestionario { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Pergunta1 { get; set; }
        public string Pergunta2 { get; set; }
        public string Pergunta3 { get; set; }
        public string Pergunta4 { get; set; }
        public string Pergunta5 { get; set; }
        public string Pergunta6 { get; set; }
        public string Pergunta7 { get; set; }
        public string Pergunta8 { get; set; }
        public string Pergunta9 { get; set; }
        public string Pergunta10 { get; set; }
    }
}
