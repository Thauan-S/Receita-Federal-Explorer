using HtmlAgilityPack;
using System.IO.Compression;

namespace WorkerService1.Services
{
    public class CSVProcessorService
    {
        private readonly HttpClient httpClient;
        private string _extractPath = @"C:\MeusArquivosCNPJ\ExtractedFiles";

        public CSVProcessorService()
        {
            httpClient = new HttpClient();
        }

        public void DeleteZipFiles()
        {
            if (Directory.Exists(_extractPath))
            {
                Directory.Delete(_extractPath, true);
                Console.WriteLine("Pasta de extração removida com sucesso.");
            }
            else
            {
                Console.WriteLine("A pasta de extração não existe.");
            }
        }

        public PriorityQueue<string, int> EnqueueItensToPriorityQueue()
        {
            var priorityQueue = new PriorityQueue<string, int>();
            var allFiles = Directory.GetFiles(_extractPath);
            string simplesPattern = @".*\d.*\.SIMPLES\.CSV\..+";
            var patternList = new List<(string pattern, int priority)>
            {
                (".CNAECSV", 0),
                (".MOTICSV", 1),
                (".MUNICCSV", 2),
                (".NATJUCSV", 3),
                (simplesPattern,4),
                (".PAISCSV", 5),
                (".QUALSCSV", 6),
                (".EMPRECSV", 7),
                (".SOCIOCSV", 8),
                (".ESTABELE", 9)
            };
            foreach (var (pattern, priority) in patternList)
            {
                var file = allFiles.FirstOrDefault(f => f.Contains(pattern, StringComparison.OrdinalIgnoreCase));
                if (file != null)
                    priorityQueue.Enqueue(file, priority);
            }
            return priorityQueue;
        }

        public async Task ExtractZipFiles(string[] zipFiles)
        {
            var downloadUrl = zipFiles.FirstOrDefault(i => i.Contains("Qualificacoes.zip"));
            if (!Directory.Exists(_extractPath))
            {
                Directory.CreateDirectory(_extractPath);
            }

            var fileName = Path.GetFileName(downloadUrl);
            var localZipPath = Path.Combine(_extractPath, fileName);
            var fileBytes = await httpClient.GetByteArrayAsync(downloadUrl);
            await File.WriteAllBytesAsync(localZipPath, fileBytes);

            ZipFile.ExtractToDirectory(localZipPath, _extractPath);

            //foreach (var zipFile in zipFiles)
            //{
            //    Console.WriteLine($"Extracting {zipFile}");
            //    ZipFile.ExtractToDirectory(zipFile, Path.Combine(extractPath, "ExtractedFiles"));
            //    break;
            //}
        }

        public async Task<string[]> GetZipFilesFromUrl(string url)
        {
            var htmlString = await httpClient.GetStringAsync(url);

            var htmlContent = new HtmlDocument();
            htmlContent.LoadHtml(htmlString);
            var content = htmlContent.DocumentNode.SelectNodes("//a[@href]");
            if (content == null)
            {
                throw new Exception("Nenhum link encontrado na página.");
            }
            var zipFiles = content
               .Select(anchor => anchor.GetAttributeValue("href", string.Empty))
               .Where(href => !string.IsNullOrEmpty(href))
               .Where(href => href.Contains(".zip"))
               .Select(item => $"{url}{item}")
               .ToArray();

            Console.WriteLine(zipFiles.Length + "arquivos encontrados");

            return zipFiles;
        }
        public void ParseCSVToEntity()
        {
        }
    }
}