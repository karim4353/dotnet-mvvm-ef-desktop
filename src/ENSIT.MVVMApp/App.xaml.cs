using System;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Microsoft.Extensions.Configuration;
using ENSIT.MVVMApp.Views;
using ENSIT.MVVMApp.ViewModels;

namespace ENSIT.MVVMApp
{
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, cfg) =>
                {
                    cfg.AddJsonFile("appsettings.json", optional: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    // register infrastructure services - DbContext and EfDataService registered in infrastructure project via extension
                    Infrastructure.DiExtensions.ConfigureServices(services, context.Configuration);
                })
                .UseSerilog((context, services, configuration) =>
                {
                    configuration.WriteTo.Console()
                                 .WriteTo.File("logs/ensit.log", rollingInterval: Serilog.RollingInterval.Day);
                });

            _host = builder.Build();
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            var mw = _host.Services.GetRequiredService<MainWindow>();
            mw.DataContext = _host.Services.GetRequiredService<MainViewModel>();
            mw.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
