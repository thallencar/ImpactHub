using ImpactHub.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace ImpactHub.API.Requests
{
    public class CadastroRequest
    {
        [Required(ErrorMessage = "O campo 'nomeEmpresa' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'nomeEmpresa' deve conter entre 2 e 200 caracteres.")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "O campo 'cnpj' é obrigatório.")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "O campo 'cnpj' deve conter 14 caracteres (ou 18 com os caracteres especiais.).")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "O campo 'inscricaoEstadual' é obrigatório.")]
        [StringLength(14, MinimumLength = 8, ErrorMessage = "O campo 'inscricaoEstadual' deve conter entre 8 e 14 caracteres.")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "O campo 'razaoSocial' é obrigatório.")]
        [StringLength(180, MinimumLength = 2, ErrorMessage = "O campo 'razaoSocial' deve conter entre 2 e 180 caracteres.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo 'porte' é obrigatório.")]
        [Range(1, 3, ErrorMessage = "O campo 'porte' deve ser entre 1 e 3.")]
        public PorteEmpresaEnum Porte { get; set; }

        [Required(ErrorMessage = "O campo 'dataAbertura' é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "O campo 'dataAbertura' deve ser uma data válida.")]
        public DateTime DataAbertura { get; set; }

        [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo 'email' deve conter entre 2 e 30 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'nomeUsuario' é obrigatório.")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "O campo 'nomeUsuario' deve conter entre 2 e 25 caracteres.")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo 'senha' é obrigatório.")]
        [StringLength(16, MinimumLength = 2, ErrorMessage = "O campo 'senha' deve conter entre 2 e 16 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo 'statusMonitoramento' é obrigatório.")]
        [Range(1, 5, ErrorMessage = "O campo 'statusMonitoramento' deve ser entre 1 e 5.")]
        public StatusMonitoramentoEnum StatusMonitoramento { get; set; } 
    }
}
