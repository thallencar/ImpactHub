using System.ComponentModel.DataAnnotations;

namespace ImpactHub.API.Requests
{
    public class QuestionarioESGRequest
    {
        [Required(ErrorMessage = "O campo 'titulo' é obrigatório.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O campo 'nomeEmpresa' deve conter entre 2 e 80 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo 'categoria' é obrigatório.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "O campo 'nomeEmpresa' deve conter 1 caractere.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta1' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta1' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta1 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta2' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta2' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta2 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta3' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta3' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta3 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta4' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta4' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta4 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta5' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta5' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta5 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta6' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta6' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta6 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta7' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta7' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta7 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta8' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta8' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta8 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta9' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta9' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta9 { get; set; }

        [Required(ErrorMessage = "O campo 'pergunta10' é obrigatório.")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "O campo 'pergunta10' deve conter entre 2 e 200 caracteres.")]
        public string Pergunta10 { get; set; }
    }
}
