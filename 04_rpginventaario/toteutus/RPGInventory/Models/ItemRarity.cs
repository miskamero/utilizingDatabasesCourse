using System;
using System.Collections.Generic;

namespace RPGInventory.Models;

public partial class ItemRarity
{
    public int Id { get; set; }

    public string RarityName { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
