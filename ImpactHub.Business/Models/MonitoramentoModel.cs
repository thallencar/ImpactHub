using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class MonitoramentoModel
    {
        public int IdMonitoramento { get; set; }
        public DateTime DataValidade { get; set; }
        public StatusMonitoramentoEnum StatusMonitoramento { get; set; }
        public string DescricaoMonitoramento { get; set; }

        //1..N
        public int IdLogin { get; set; }
        public LoginModel Login { get; set; }

        //1..N
        public int IdResultado { get; set; }
        public ResultadoModel Resultado { get; set; }
    }
}
