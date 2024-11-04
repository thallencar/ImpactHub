using ImpactHub.Business.Enums;
using System.ComponentModel.DataAnnotations;

namespace ImpactHub.API.Requests
{
    public class ContatoRequest
    {
        [Required(ErrorMessage = "O campo 'ddi' é obrigatório.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "O campo 'ddi' deve conter entre 1 e 3 caracteres.")]
        public int Ddi { get; set; }

        [Required(ErrorMessage = "O campo 'ddd' é obrigatório.")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "O campo 'ddd' deve conter entre 1 e 3 caracteres.")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "O campo 'telefone' é obrigatório.")]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "O campo 'nomeEmpresa' deve conter 9 caracteres.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo 'tipoContato' é obrigatório.")]
        [Range(1, 6, ErrorMessage = "O campo 'tipoContato' deve ser entre 1 e 6.")]
        public TipoContatoEnum TipoContato { get; set; }

        [Required(ErrorMessage = "O campo 'statusContato' é obrigatório.")]
        [Range(1, 4, ErrorMessage = "O campo 'statusContato' deve ser entre 1 e 4.")]
        public StatusContatoEnum StatusContato { get; set; }

        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "O campo 'codigoOperadora' deve conter entre 1 e 3 caracteres.")]
        public int CodigoOperadora { get; set; }

        [Required(ErrorMessage = "O campo 'nomeResponsavel' é obrigatório.")]
        [StringLength(80, MinimumLength = 9, ErrorMessage = "O campo 'nomeResponsavel' deve conter entre 2 e 80 caracteres.")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "O campo 'nomeEmpresa' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'nomeEmpresa' deve conter entre 2 e 200 caracteres.")]
        public string NomeEmpresa { get; set; }
    }
}
