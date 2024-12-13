using RPGInventory.Models;
using Microsoft.EntityFrameworkCore;  // Ensure to import this for EF Core methods

public class InventoryRepository
{
    private readonly InventoryContext _context;
    public class InventoryContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<ItemRarity> ItemRarities { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }
    }

    public InventoryRepository(InventoryContext context)
    {
        _context = context;
    }

    // Get items by rarity
    public List<Item> GetItemsByRarity(string rarity)
    {
        return _context.Items
            .Include(item => item.Rarity)  // Ensure to include Rarity for navigation
            .Where(item => item.Rarity != null && item.Rarity.RarityName == rarity) // Check for null
            .ToList();
    }

    // Get item by Id and update the BaseValue
    public void UpdateBaseValue(int itemId, decimal newBaseValue)
    {
        var item = _context.Items.Find(itemId);
        if (item != null)
        {
            item.BaseValue = newBaseValue;
            _context.SaveChanges();
        }
    }

    // Delete item by Id
    public void DeleteItem(int itemId)
    {
        var item = _context.Items.Find(itemId);
        if (item != null)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }
    }

    // Get items by type
    public List<Item> GetItemsByType(string type)
    {
        return _context.Items
            .Include(item => item.ItemType)  // Include ItemType for navigation
            .Where(item => item.ItemType != null && item.ItemType.TypeName == type)  // Ensure ItemType is not null
            .ToList();
    }

    // Get average values
    public (decimal avgBaseValue, decimal avgAttValue, decimal avgDefValue) GetAverageValues()
    {
        var avgBaseValue = _context.Items.Average(i => i.BaseValue);
        var avgAttValue = _context.Items.Average(i => i.AttValue);
        var avgDefValue = _context.Items.Average(i => i.DefValue);

        return (avgBaseValue, avgAttValue, avgDefValue);
    }

    // Get items with AttValue greater than a given value
    public List<Item> GetItemsWithHighAttackValue(decimal value)
    {
        return _context.Items
            .Where(item => item.AttValue > value)
            .ToList();
    }
}
