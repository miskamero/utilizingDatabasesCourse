using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RPGInventory.Models;
using System.Windows;
using static InventoryRepository;

namespace RPGInventory
{
    public partial class App : Application
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        public App()
        {
            // Create the service collection
            var serviceCollection = new ServiceCollection();

            // Register DbContext and InventoryRepository
            serviceCollection.AddDbContext<InventoryContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RPGInventory;Trusted_Connection=True;"));

            serviceCollection.AddScoped<InventoryRepository>();

            // Build the service provider and store it in the static property
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
