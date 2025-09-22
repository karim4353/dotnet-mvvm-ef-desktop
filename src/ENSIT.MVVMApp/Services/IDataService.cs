using ENSIT.MVVMApp.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ENSIT.MVVMApp.Services
{
    public interface IDataService
    {
        Task<IReadOnlyList<Customer>> SearchCustomersAsync(string q, CancellationToken token = default);
        Task<string> RunPerfSampleAsync();
    }
}
