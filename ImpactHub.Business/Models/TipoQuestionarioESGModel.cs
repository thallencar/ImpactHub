using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class TipoQuestionarioESGModel
    {
        public int IdTipoQuestionario { get; set; }
        public TipoQuestionarioESGEnum TipoQuestionario { get; set; }
        public string Descricao { get; set; }

        //1..N
        public IEnumerable<QuestionarioModel> Questionarios { get; set; }
    }
}
