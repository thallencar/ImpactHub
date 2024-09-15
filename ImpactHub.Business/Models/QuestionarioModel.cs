using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class QuestionarioModel
    {
        public int IdQuestionario { get; set; }
        public string DescricaoPergunta { get; set; }
        public string DescricaoResposta { get; set; }

        //1..N
        public int IdTipoQuestionario { get; set; }
        public TipoQuestionarioESGModel TipoQuestionario { get; set; }
        
        //1..N
        public IEnumerable<ResultadoModel> Resultados { get; set; }
    }
}
