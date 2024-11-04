
using ImpactHub.API.Configuration;
using ImpactHub.API.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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

            builder.Services.AddSwaggerDocs(appConfiguration);

            builder.Services.AddRepository();

            builder.Services.AddServices();

            builder.Services.AddHealthChecks().AddMongoDb(appConfiguration.MongoDbConnectionString);

            builder.Services.AddMongoDbContext(appConfiguration);

            var app = builder.Build();

            app.UseRouting();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health-check", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = HealthCheckExtensions.WriteResponse
                });
            });

            app.Run();
        }
    }
}
