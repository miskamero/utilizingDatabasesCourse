using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RPGInventaario.Models;

namespace RPGInventaario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly InventoryRepository _inventoryRepo;
        public MainWindow()
        {
            InitializeComponent();
            _inventoryRepo = new InventoryRepository(new RpginventaarioContext());
            BindItemsByRarityToDataGrid("Rare");
        }
        private void BindItemsByRarityToDataGrid(string rarity)
        {
            List<Item> items = _inventoryRepo.GetItemsByRarity(rarity);

            ItemsDataGrid.ItemsSource = items;
        }
    }

}