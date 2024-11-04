using ImpactHub.API.Configuration;
using ImpactHub.Business.Interfaces;
using ImpactHub.Data;
using ImpactHub.Repositories;
using ImpactHub.Services.CEPService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Runtime.ConstrainedExecution;

namespace ImpactHub.API.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddSwaggerGen(
                x => x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ImpactHub - APPLICATION API",
                    Version = "v1",
                    Description = "API para cadastrar e monitorar as empresas em seu nível de ESG.",
                    Contact = new OpenApiContact() { Email = "impacthub@fivetech.com.br", Name = "FiveTech Collective" }
                }
                )
            );

            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);

            services.AddScoped<ICadastroRepository, CadastroRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IResultadoESGRepository, ResultadoESGRepository>();
            services.AddScoped<IQuestionarioESGRepository, QuestionarioESGRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICEPService, CEPService>();

            return services;
        }

        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, APIConfiguration appConfiguration)
        {
            services.AddDbContext<ImpactHubDbContext>(options =>
            {
                options.UseMongoDB(appConfiguration.MongoDbConnectionString, appConfiguration.MongoDbDatabase);
            });
            return services;
        }
    }
}
