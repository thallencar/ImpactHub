using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class CadastroModel
    {
        public int IdCadastro { get; set; }
        public string NomeEmpresa { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RazaoSocial { get; set; }
        public PorteEmpresaEnum Porte { get; set; }
        public DateOnly DataAbertura { get; set; }

        //1..N
        public IEnumerable<EnderecoModel> Enderecos { get; set; }

        //1..N
        public IEnumerable<ContatoModel> Contatos { get; set; }

        //1..1
        public int IdLogin { get; set; }
        public LoginModel Login { get; set; }
    }
}
