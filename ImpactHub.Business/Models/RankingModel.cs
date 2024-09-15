namespace ImpactHub.Business.Models
{
    public class RankingModel
    {
        public int IdRanking { get; set; }
        public int Posicao { get; set; }

        //1..N
        public int IdResultado { get; set; }
        public ResultadoModel Resultado { get; set; }
    }
}
