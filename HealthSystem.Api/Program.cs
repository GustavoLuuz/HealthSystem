using HealthSystem.Aplicacao.Servicos.Interfaces;
using HealthSystem.Infra.Repositorios;
using HealthSystem.Servicos;
using HealthSystem.Servicos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HealthSystem.Infra.Data;
using HealthSystem.Dominio.InterfaceRepositorios;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMedicoServico, MedicoServico>();
builder.Services.AddScoped<IPacienteServico, PacienteServico>();
builder.Services.AddScoped<IConsultaServico, ConsultaServico>();

builder.Services.AddScoped<IMedicoRepositorio, MedicoRepositorio>();
builder.Services.AddScoped<IPacienteRepositorio, PacienteRepositorio>();
builder.Services.AddScoped<IConsultaRepositorio, ConsultaRepositorio>();

builder.Services.AddDbContext<HealthSystemDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=HealthSystemDB;User ID=sa;Password=1q2w3eaa4r@#$"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builderCors =>
        {
            builderCors.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
        });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
