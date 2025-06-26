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
var configuration=builder.Configuration;

builder.Services.AddDbContext<AppDbContext>(options =>

    
          options.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:database_url"))
);
builder.Services.AddScoped<CsvParserService>();
//builder.Services.AddScoped<ReceitaCsvProcessor>();
//builder.Services.AddScoped<FileDownloaderService>();
//builder.Services.AddScoped<FileExtractorService>();
//builder.Services.AddScoped<ReceitaFederalFileHandler>();

builder.Services.AddScoped<IMassiveRepository, MassiveRepository>();
builder.Services.AddScoped<ICnaeRepository, CnaeRepository>();
builder.Services.AddScoped<IMotivoRepository, MotivoRepository>();
builder.Services.AddScoped<IMunicipioRepository, MunicipioRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<INaturezaRepository, NaturezaRepository>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<IQualificacaoRepository, QualificacaoRepository>();
var host = builder.Build();
host.Run();
