using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGInventaario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace RPGInventaario.Models
{
    public class InventoryRepository
    {
        private readonly RpginventaarioContext _context;

        public InventoryRepository(RpginventaarioContext context)
        {
            _context = context;
        }

        // Get items by rarity
        public List<Item> GetItemsByRarity(string rarity)
        {
            // Fetch all ItemRarity records in memory
            var rarityId = _context.ItemRarities
                .AsEnumerable() // Switch to client-side evaluation
                .Where(r => r.RarityName.Equals(rarity, StringComparison.OrdinalIgnoreCase))
                .Select(r => r.Id)
                .FirstOrDefault();

            if (rarityId == 0)
            {
                return new List<Item>();
            }

            // Fetch items with the matching rarityId from the database
            return _context.Items
                .Where(item => item.RarityId == rarityId)
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
                .Where(item => item.ItemType.TypeName == type)
                .ToList();
        }

        // Get average values
        //public (decimal avgBaseValue, decimal avgAttValue, decimal avgDefValue) GetAverageValues()
        //{
        //    var avgBaseValue = _context.Items.Average(i => i.BaseValue);
        //    var avgAttValue = _context.Items.Average(i => i.AttValue);
        //    var avgDefValue = _context.Items.Average(i => i.DefValue);

        //    return (avgBaseValue, avgAttValue, avgDefValue);
        //}

        // Get items with AttValue greater than a given value
        public List<Item> GetItemsWithHighAttackValue(decimal value)
        {
            return _context.Items
                .Where(item => item.AttValue > value)
                .ToList();
        }
    }
}

