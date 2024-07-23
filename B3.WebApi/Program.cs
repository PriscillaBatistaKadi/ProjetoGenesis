using System.Diagnostics.CodeAnalysis;
using B3.WebApi.Domain.Services;
using B3.WebApi.Domain.Services.Interfaces;
using Microsoft.OpenApi.Models;

namespace B3.WebApi;

[ExcludeFromCodeCoverage]
public class Program
{

    protected Program() { }
    public static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<ICalculoCdbService, CalculoCdbServiceWrapper>();

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "B3.WebApi",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "PriscillaBatista",
                    Email = "pri.batista.lima@gmail.com"
                }
            });

            var xmlFile = "B3.WebApi.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        ConfigureCors(builder);

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseHttpsRedirection();

        app.UseCors("PolicyCors");

        app.MapControllers();

        app.Run();

    }

    public static void ConfigureCors(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("PolicyCors", app =>
            {
                app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
    }


}