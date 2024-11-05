using ImpactHub.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace ImpactHub.API.Requests
{
    public class ResultadoESGRequest
    {
        [Required(ErrorMessage = "O campo 'pontuacaoAmbiental' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'pontuacaoAmbiental' deve ser entre 0.0 e 100.0")]
        public double PontuacaoAmbiental { get; set; }

        [Required(ErrorMessage = "O campo 'pontuacaoSocial' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'pontuacaoSocial' deve ser entre 0.0 e 100.0")]
        public double PontuacaoSocial { get; set; }

        [Required(ErrorMessage = "O campo 'pontuacaoGovernanca' é obrigatório.")]
        [Range(0.0, 100.0, ErrorMessage = "O campo 'pontuacaoGovernanca' deve ser entre 0.0 e 100.0")]
        public double PontuacaoGovernanca { get; set; }

        [Required(ErrorMessage = "O campo 'statusResultado' é obrigatório.")]
        [Range(1, 6, ErrorMessage = "O campo 'statusResultado' deve ser entre 1 e 6.")]
        public StatusResultadoEnum StatusResultado { get; set; }

        [Required(ErrorMessage = "O campo 'nomeEmpresa' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'nomeEmpresa' deve conter entre 2 e 200 caracteres.")]
        public string NomeEmpresa { get; set; }
    }
}
