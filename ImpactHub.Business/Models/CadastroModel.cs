using ImpactHub.Business.Enums;
using System.Text.Json.Serialization;

namespace ImpactHub.Business.Models
{
    public class CadastroModel
    {
        public int IdCadastro { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string RazaoSocial { get; set; }
        public PorteEmpresaEnum Porte { get; set; }
        public DateTime DataAbertura { get; set; }
        public string Email { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        /*
        //1..N
        public IEnumerable<EnderecoModel> Enderecos { get; set; }

        //1..N
        public IEnumerable<ContatoModel> Contatos { get; set; }
        */

    }
}
