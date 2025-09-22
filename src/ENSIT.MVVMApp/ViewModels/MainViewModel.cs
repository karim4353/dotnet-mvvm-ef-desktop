using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using ENSIT.MVVMApp.Commands;
using ENSIT.MVVMApp.Models;
using ENSIT.MVVMApp.Services;
using Serilog;
using System.Linq;

namespace ENSIT.MVVMApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
        private readonly ILogger _logger = Log.ForContext<MainViewModel>();
        private CancellationTokenSource? _cts;

        public ObservableCollection<Customer> Customers { get; } = new();

        private string? _searchText;
        public string? SearchText
        {
            get => _searchText;
            set { _searchText = value; Raise(); }
        }

        public ICommand SearchCommand { get; }
        public ICommand RunPerfCommand { get; }

        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            SearchCommand = new RelayCommand(async () => await SearchAsync());
            RunPerfCommand = new RelayCommand(async () => await RunPerfAsync());
            // seed initial load
            _ = SearchAsync();
        }

        public async Task SearchAsync()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            try
            {
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var list = await _dataService.SearchCustomersAsync(SearchText ?? string.Empty, _cts.Token);
                sw.Stop();
                _logger.Information("Search took {ElapsedMs}ms and returned {Count} rows", sw.ElapsedMilliseconds, list.Count);
                Customers.Clear();
                foreach (var c in list) Customers.Add(c);
            }
            catch (TaskCanceledException) { _logger.Information("Search canceled"); }
        }

        public async Task RunPerfAsync()
        {
            var r = await _dataService.RunPerfSampleAsync();
            // simple dialog-less feedback via log
            _logger.Information("Perf sample: {Summary}", r);
        }
    }
}
