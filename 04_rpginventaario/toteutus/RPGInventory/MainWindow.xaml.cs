using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace RPGInventory
{
    public partial class MainWindow : Window
    {
        public required InventoryRepository _inventoryRepository;

        public MainWindow()
        {
            InitializeComponent();

            // check if null
            if (App.ServiceProvider != null)
            {
                _inventoryRepository = App.ServiceProvider.GetRequiredService<InventoryRepository>();
            }
            else
            {
                MessageBox.Show("Service provider is null");
            }
        }

        private void LoadItemsByRarity(string rarity)
        {
            var items = _inventoryRepository.GetItemsByRarity(rarity);
            ItemsListView.ItemsSource = items;  // Assuming you have a ListView to display the items
        }
    }
}
