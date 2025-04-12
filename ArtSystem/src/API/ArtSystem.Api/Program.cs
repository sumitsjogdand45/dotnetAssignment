
using ArtSystem.Api.Extensions;
using ArtSystem.Api.Middleware;
using ArtSystem.Api.SwaggerHelper;
using ArtSystem.Application;
using ArtSystem.Identity;
using ArtSystem.Persistance;
using Asp.Versioning.ApiExplorer;
using Serilog;

namespace ArtSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); 
            // Add services to the container.
            builder.Services.AddInterfaceServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
            builder.Services.AddSwaggerVersionedApiExplorer();
            builder.Services.AddSwaggerGen(options=>options.OperationFilter<SwaggerDefaultValues>());
            builder.Services.AddControllers();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
            builder.Host.UseSerilog();
            
           
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSerilogRequestLogging();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
