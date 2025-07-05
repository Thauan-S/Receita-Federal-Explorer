

using Microsoft.EntityFrameworkCore;

using WorkerService1;
using WorkerService1.Context;
using WorkerService1.Repositories.CnaeRepository;
using WorkerService1.Repositories.EmpresaRepository;
using WorkerService1.Repositories.MassiveRepository;
using WorkerService1.Repositories.MotivoRepository;
using WorkerService1.Repositories.MunicipioRepository;
using WorkerService1.Repositories.NaturezaJuridicaRepository;
using WorkerService1.Repositories.PaisRepository;
using WorkerService1.Repositories.QualificacoesRepository;
using WorkerService1.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
var configuration = builder.Configuration;

builder.Services.AddHttpClient();
builder.Services.AddScoped<ICSVParserService, CsvParserService>();
builder.Services.AddScoped<IMassiveRepository, MassiveRepository>();
builder.Services.AddScoped<ICnaeRepository, CnaeRepository>();
builder.Services.AddScoped<IMotivoRepository, MotivoRepository>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<INaturezaRepository, NaturezaRepository>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<IQualificacaoRepository, QualificacaoRepository>();
builder.Services.AddScoped<ICSVParserService, CsvParserService>();
builder.Services.AddScoped<ICSVProcessorService, CSVProcessorService>();
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:database_url"))
);

var host = builder.Build();
host.Run();
