using Microsoft.ML.Data;

namespace ImpactHub.Business.Models
{

    public class ESGPrevisaoMlModel
    {
        [LoadColumn(13)] public float EnvironmentScore { get; set; } 
        [LoadColumn(14)] public float SocialScore { get; set; }    
        [LoadColumn(15)] public float GovernanceScore { get; set; } 
    }

    public class PrevisaoESG
    {
        [ColumnName("Score")]
        public float TotalScorePrevisto { get; set; } 
    }
}

