
using ImpactHub.API.Configuration;
using ImpactHub.Business.Interfaces;
using ImpactHub.Data.Contexts;
using ImpactHub.Repositories;
using ImpactHub.Services.CEPService;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

namespace ImpactHub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;
            APIConfiguration appConfiguration = new();
            configuration.Bind(appConfiguration);
            builder.Services.Configure<APIConfiguration>(configuration);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(
                x => x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ImpactHub - APPLICATION API",
                    Version = "v1",
                    Description = "API para cadastrar e monitorar as empresas em seu nível de ESG.",
                    Contact = new OpenApiContact() { Email = "impacthub@fivetech.com.br", Name = "FiveTech Collective" }
                }
                )
            );

            builder.Services.AddDbContext<ImpactHubDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("ImpactHubDbContext"));
            });

            builder.Services.AddScoped<ICEPService, CEPService>();
            builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
            builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
