using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class LoginModel
    {
        public int IdLogin { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public StatusLoginEnum StatusLogin { get; set; }

        //1..1
        public int IdCadastro { get; set; }
        public CadastroModel Cadastro { get; set; }
    }
}
