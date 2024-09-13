namespace ImpactHub.Services.CEPService
{
    public interface ICEPService
    {
        Task<CEPResponse> BuscarCEP(string cep);
        Task<IEnumerable<CEPResponse>> NaoSeiMeuCEP(string estado, string cidade, string rua);
    }
}
