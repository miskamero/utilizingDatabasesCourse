using System;
using System.Collections.Generic;

namespace RPGInventory.Models;

public class Item
{
    public int Id { get; set; }
    public string ItemName { get; set; } = null!;
    public int ItemTypeId { get; set; }
    public int RarityId { get; set; }
    public decimal BaseValue { get; set; }
    public decimal AttValue { get; set; }
    public decimal DefValue { get; set; }

    // Navigation properties
    public virtual ItemType? ItemType { get; set; }
    public virtual ItemRarity? Rarity { get; set; }  // This is the navigation property
}
