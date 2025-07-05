using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService1.Services
{
    public interface ICSVProcessorService
    {
        PriorityQueue<FileProcessingInfo, int> EnqueueItensToPriorityQueue();
        Task ExtractZipFiles(string[] zipFiles);
        void DeleteZipFiles();
        Task<string[]> GetZipFilesFromUrl(string url);
    }
}
