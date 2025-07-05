using WorkerService1.Context;
using WorkerService1.Services;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month - 1;
            string formatedMonth = currentMonth.ToString().Length == 1 ? $"0{currentMonth}" : currentMonth.ToString();
            
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var csvProcessorService = scope.ServiceProvider.GetRequiredService<ICSVProcessorService>();
                var zipFiles = await csvProcessorService.GetZipFilesFromUrl($"https://arquivos.receitafederal.gov.br/dados/cnpj/dados_abertos_cnpj/{currentYear}-{formatedMonth}/");
                await csvProcessorService.ExtractZipFiles(zipFiles);
            }
        }
    }
}
