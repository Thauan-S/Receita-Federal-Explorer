using CsvHelper.Configuration;
using HtmlAgilityPack;
using System.IO;
using System.IO.Compression;
using WorkerService1.Entityes;
using WorkerService1.Mappers;
using WorkerService1.Repositories.MassiveRepository;

namespace WorkerService1.Services
{
    public record FileProcessingInfo(string FilePath, Type EntityType, Type MapperType, int Priority);

    public class CSVProcessorService: ICSVProcessorService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private const string EXTRACTPATH = @"C:\MeusArquivosCNPJ\ExtractedFiles";
        private readonly IMassiveRepository _massiveRepository;
        private readonly ICSVParserService _csvParserService;
        private  const string SIMPLES_PATTERN = "SIMPLES.CSV";
        private  string  localZipPath = "";
        private readonly Dictionary<Type, Func<FileProcessingInfo, Task>> _fileProcessors;
        public CSVProcessorService(ICSVParserService csvParserService, IMassiveRepository massiveRepository, IHttpClientFactory httpClientFactory = null)
        {

            _csvParserService = csvParserService;
            _massiveRepository = massiveRepository;
            _fileProcessors = new Dictionary<Type, Func<FileProcessingInfo, Task>>
            {
                { typeof(Cnae), file => ProcessFile<Cnae, CnaeMapper>(file) },
                { typeof(Motivo), file => ProcessFile<Motivo, MotivoMapper>(file) },
                { typeof(Municipio), file => ProcessFile<Municipio, MunicipioMapper>(file) },
                { typeof(NaturezaJuridica), file => ProcessFile<NaturezaJuridica, NaturezaJuridicaMapper>(file) },
                { typeof(Simples), file => ProcessFile<Simples, SimplesMapper>(file) },
                { typeof(Pais), file => ProcessFile<Pais, PaisMapper>(file) },
                { typeof(QualificacaoSocio), file => ProcessFile<QualificacaoSocio, QualificacoesSocioMapper>(file) },
                { typeof(Empresa), file => ProcessFile<Empresa, EmpresaMapper>(file) },
                { typeof(Socio), file => ProcessFile<Socio, SocioMapper>(file) },
                { typeof(Estabelecimento), file => ProcessFile<Estabelecimento, EstabelecimentoMapper>(file) }
            };
            _httpClientFactory = httpClientFactory;
        }

        public PriorityQueue<FileProcessingInfo, int> EnqueueItensToPriorityQueue()
        {
            var priorityQueue = new PriorityQueue<FileProcessingInfo, int>();
            var allFiles = Directory.GetFiles(EXTRACTPATH);

                    var patternList = new List<(string pattern, Type entityType, Type mapperType, int priority)>
            {
                (".CNAECSV", typeof(Cnae), typeof(CnaeMapper), 0),
                (".MOTICSV", typeof(Motivo), typeof(MotivoMapper), 1),
                (".MUNICCSV", typeof(Municipio), typeof(MunicipioMapper), 2),
                (".NATJUCSV", typeof(NaturezaJuridica), typeof(NaturezaJuridicaMapper), 3),
                (".PAISCSV", typeof(Pais), typeof(PaisMapper), 4),
                (".QUALSCSV", typeof(QualificacaoSocio), typeof(QualificacoesSocioMapper), 5),
                (".EMPRECSV", typeof(Empresa), typeof(EmpresaMapper), 6),
                (".SOCIOCSV", typeof(Socio), typeof(SocioMapper), 7),
                (".ESTABELE", typeof(Estabelecimento), typeof(EstabelecimentoMapper), 8),
                (SIMPLES_PATTERN, typeof(Simples), typeof(SimplesMapper), 9),
            };
            
            foreach (var (pattern, entityType, mapperType, priority) in patternList)
            {
                var file = allFiles.FirstOrDefault(f => f.Contains(pattern, StringComparison.OrdinalIgnoreCase));
                if (file != null)
                {
                    var fileInfo = new FileProcessingInfo(file, entityType, mapperType, priority);
                    priorityQueue.Enqueue(fileInfo, priority);
                }
            }
            return priorityQueue;
        }

        public async Task ExtractZipFiles(string[] zipFiles)
        {
            

            if (!Directory.Exists(EXTRACTPATH))
            {
                Directory.CreateDirectory(EXTRACTPATH);
            }

              await DownloadAndSaveZipFiles(zipFiles);
            try
            {
                var zipfiles = Directory.GetFiles(EXTRACTPATH, "*.zip");
                foreach (var zipFile in zipfiles)
                {

                   var fileName = Path.GetFileName(zipFile);

                    localZipPath = Path.Combine(EXTRACTPATH, fileName);
                    Console.WriteLine($"Extracting {zipFile}");
                    ZipFile.ExtractToDirectory(localZipPath, EXTRACTPATH);

                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            var priorityQueue = EnqueueItensToPriorityQueue();


            // Processar todos os arquivos na ordem de prioridade
            while (priorityQueue.Count > 0)
            {
                var fileInfo = priorityQueue.Dequeue();
                Console.WriteLine($"Processando arquivo: {fileInfo.FilePath}");

                if (_fileProcessors.TryGetValue(fileInfo.EntityType, out var processor))
                {
                    await processor(fileInfo);
                    File.Delete(fileInfo.FilePath);
                }
                else
                {
                    Console.WriteLine($"Nenhum processador para tipo {fileInfo.EntityType.Name}");
                }
            }


        }

        private  async Task DownloadAndSaveZipFiles(string[] zipFiles)
        {
            using var httpClient = _httpClientFactory.CreateClient();
            foreach (var zipFile in zipFiles)
            {
                var fileName = Path.GetFileName(zipFile);

                localZipPath = Path.Combine(EXTRACTPATH, fileName);

                using var request = new HttpRequestMessage(HttpMethod.Get, zipFile);
                using var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

                response.EnsureSuccessStatusCode();

                await using var stream = await response.Content.ReadAsStreamAsync();
                await using var fileStream = File.Create(localZipPath);
                await stream.CopyToAsync(fileStream);
            }

        }

        public void DeleteZipFiles()
        {
            string[] files = Directory.GetFiles(EXTRACTPATH);

            foreach (string file in files)
            {
                File.Delete(file);
                Console.WriteLine($"Arquivo deletado: {file}");
            }
        }

        public async Task<string[]> GetZipFilesFromUrl(string url)
        {
            using var httpClient = _httpClientFactory.CreateClient();

            var htmlString = await httpClient.GetStringAsync(url);

            var htmlContent = new HtmlDocument();
            htmlContent.LoadHtml(htmlString);
            var content = htmlContent.DocumentNode.SelectNodes("//a[@href]")!;

            var zipFiles = content
               .Select(anchor => anchor.GetAttributeValue("href", string.Empty))
               .Where(href => !string.IsNullOrEmpty(href))
               .Where(href => href.Contains(".zip"))
               .Select(item => $"{url}{item}")
               .ToArray();

            Console.WriteLine(zipFiles.Length + " Arquivos encontrados");

            return zipFiles;
        }
        private async Task ProcessFile<TEntity, TMap>(FileProcessingInfo filePath)
               where TEntity : class
               where TMap : ClassMap<TEntity>
        {
            var entities = await _csvParserService.ParseToEntities<TEntity, TMap>(filePath.FilePath);

                await _massiveRepository.InsertDataAsync(entities);
        }
    }
}