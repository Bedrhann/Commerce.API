using FinalProject.Application;
using Microsoft.OpenApi.Models;
using Paycore.FinalProject.Infrastructure;
using Paycore.FinalProject.Persistance;
using Serilog;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Filters;
using FinalProject.Application.Validators.Products;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
Log.Information("Application is starting.");

var connStr = builder.Configuration.GetConnectionString("PostgreSqlConn");
builder.Services.AddControllers()
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductCommandRequestValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddResponseCaching();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(connStr);
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


builder.Services.AddSwaggerGen(options =>//Swagger arayüzünde Authentication kullanabilmek icin arayuz ekliyoruz.
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "ATTEMPT (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseResponseCaching();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
