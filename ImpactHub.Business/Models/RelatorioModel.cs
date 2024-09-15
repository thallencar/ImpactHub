using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class RelatorioModel
    {
        public int IdRelatorio { get; set; }
        public string Melhorias { get; set; }
        public string PontosFaltantesMelhorias { get; set; }
        public StatusRelatorioEnum StatusRelatorio { get; set; }

        //1..N
        public int IdLogin { get; set; }
        public LoginModel Login { get; set; }

        //1..N
        public int IdResultado { get; set; }
        public ResultadoModel Resultado { get; set; }
    }
}
