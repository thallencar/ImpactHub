using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class ResultadoModel
    {
        public int IdResultado { get; set; }
        public string PorcentagemCertificado { get; set; }
        public StatusResultadoEnum StatusResultado { get; set; }
        public DateTime DataValidade { get; set; }

        //1..N
        public int IdQuestionario { get; set; }
        public QuestionarioModel Questionario { get; set; }
        
        //1..N
        public IEnumerable<MonitoramentoModel> Monitoramentos { get; set; }
        //1..N
        public IEnumerable<RelatorioModel> Relatorios { get; set; }
        //1..N
        public IEnumerable<RankingModel> Rankings { get; set; }
    }
}
