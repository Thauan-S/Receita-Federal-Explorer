using WorkerService1.Services;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;
            string formatedMonth = currentMonth.ToString().Length == 1 ? $"0{currentMonth}" : currentMonth.ToString();
            var CSVProcessorService = new CSVProcessorService();
           var zipFiles= await CSVProcessorService.GetZipFilesFromUrl($"https://arquivos.receitafederal.gov.br/dados/cnpj/dados_abertos_cnpj/{currentYear}-{formatedMonth}/");
            await CSVProcessorService.ExtractZipFiles(zipFiles);
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    if (_logger.IsEnabled(LogLevel.Information))
            //    {
            //        _logger.LogInformation("Worker ola at: {time}", DateTimeOffset.Now);
            //    }
            //    var currentYear = DateTime.Now.Year;
            //    var currentMonth = DateTime.Now.Month;
            //    string formatedMonth = currentMonth.ToString().Length == 1 ? $"0{currentMonth}" : currentMonth.ToString();
            //    var CSVProcessorService = new CSVProcessorService();
            //    await CSVProcessorService.GetZipFilesFromUrl($"https://arquivos.receitafederal.gov.br/dados/cnpj/dados_abertos_cnpj/{currentYear}-{formatedMonth}/");
            //    await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}
