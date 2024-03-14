using GildedRose.Application.Entities;
using GildedRose.Application.Interfaces.Entities;
using GildedRose.Application.Interfaces.Repositories;
using GildedRose.Application.Interfaces.Services;
using GildedRose.Application.Services;
using GildedRose.Persistence.Connections;
using GildedRose.Persistence.Initializers;
using GildedRose.Persistence.Repoistories;
using GildedRose.UI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GildedRose.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static IHost? AppHost { get; private set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                services.AddSingleton<IDbConnectionFactory>(new SqliteDbConnectionFactory(
                    context.Configuration.GetConnectionString("Items")!
                ));

                services.AddSingleton<IDbInitializer<Item>, SqliteDbInitializer>();
                
                services.AddSingleton<IItemsRepository, ItemsRepository>();
                
                services.AddSingleton<IShop, Shop>();
                
                services.AddSingleton<IItemsService>(s => new ItemsService(
                    s.GetRequiredService<IShop>(),
                    s.GetRequiredService<IItemsRepository>()
                ));
                
                services.AddSingleton(s => new ShopItemsViewModel(
                    s.GetRequiredService<IShop>(), 
                    s.GetRequiredService<IItemsService>()
                ));

                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<ShopItemsViewModel>()
                });

            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var shop = AppHost.Services.GetRequiredService<IShop>();
            shop.Items = await AppHost.Services.GetRequiredService<IDbInitializer<Item>>().InitializeAsync();

            AppHost.Services.GetRequiredService<MainWindow>().Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
