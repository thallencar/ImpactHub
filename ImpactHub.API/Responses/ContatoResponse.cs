namespace ImpactHub.API.Responses
{
    public class ContatoResponse
    {
        public string IdContato { get; set; }
        public int Ddi { get; set; }
        public int Ddd { get; set; }
        public string Telefone { get; set; }
        public string TipoContato { get; set; }
        public string StatusContato { get; set; }
        public int CodigoOperadora { get; set; }
        public string NomeResponsavel { get; set; }
        public string NomeEmpresa { get; set; }
    }
}
