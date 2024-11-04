using AutoMapper;
using ImpactHub.API.Requests;
using ImpactHub.API.Responses;
using ImpactHub.Business.Models;

namespace ImpactHub.API.Configuration
{
    public class AutoMapperConfiguration : Profile 
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CadastroModel, CadastroRequest>().ReverseMap();
            CreateMap<CadastroModel, CadastroResponse>().ReverseMap();

            CreateMap<ContatoModel, ContatoRequest>().ReverseMap();
            CreateMap<ContatoModel, ContatoResponse>().ReverseMap();

            CreateMap<EnderecoModel, EnderecoRequest>().ReverseMap();
            CreateMap<EnderecoModel, EnderecoResponse>().ReverseMap();

            CreateMap<ResultadoESGModel, ResultadoESGRequest>().ReverseMap();
            CreateMap<ResultadoESGModel, ResultadoESGResponse>().ReverseMap();

            CreateMap<QuestionarioESGModel, QuestionarioESGRequest>().ReverseMap();
            CreateMap<QuestionarioESGModel, QuestionarioESGResponse>().ReverseMap();
        }
    }
}
