using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class CadastroModel
    {
        public int IdCadastro { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RazaoSocial { get; set; }
        public PorteEmpresaEnum Porte { get; set; }
        public DateOnly DataAbertura { get; set; }

        //Contato, Endereço
        //1..N
        //public int IdEndereco { get; set; }
        public IEnumerable<EnderecoModel> Enderecos { get; set; }

        //1..N
        //public int IdContato { get; set; }
        public IEnumerable<ContatoModel> Contatos { get; set; }

        //Login
        public int IdLogin { get; set; }
        public LoginModel Login { get; set; }
    }
}
