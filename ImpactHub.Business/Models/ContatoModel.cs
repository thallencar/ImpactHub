using ImpactHub.Business.Enums;

namespace ImpactHub.Business.Models
{
    public class ContatoModel
    {
        public int IdContato { get; set; }
        public int Ddi { get; set; }
        public int Ddd { get; set; }
        public string Telefone { get; set; }
        public TipoContatoEnum TipoContato { get; set; }
        public StatusContatoEnum StatusContato { get; set; }

        /*
        //1..N
        public int IdCadastro { get; set; }
        public CadastroModel Cadastro { get; set; }
        */
    }
}


