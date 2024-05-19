using LearnWpf.CustomerDemo.DataAccess.DataContexts;
using LearnWpf.CustomerDemo.Domain.Services;
using LearnWpf.CustomerDemo.Domain.ViewModels;
using LearnWpf.CustomerDemo.UI.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LearnWpf.CustomerDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // TODO Somehow other connection strings fail to create an in-memory sqlite instance?
            var connectionString = "DataSource=file::memory:";
            //var connectionString = "DataSource=file::memory:";
            // Keep alive if multiple db contexts are used
            // Ok for now because repository is singleton
            //var connectionString = "DataSource=file::memory:?cache=shared";
            //_keepAlive = new SqliteConnection(connectionString);
            //_keepAlive.Open();

            // Data access
            services.AddDbContext<CustomerDbContext>(o =>
            {
                o.UseSqlite(connectionString);
            });

            // Domain
            services.AddSingleton<ICustomerRepository, CustomerRepository>();

            //
            services.AddSingleton<MainViewModel>();
            services.AddSingleton(p => new MainWindow() { DataContext = p.GetRequiredService<MainViewModel>() });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }
    }

}
