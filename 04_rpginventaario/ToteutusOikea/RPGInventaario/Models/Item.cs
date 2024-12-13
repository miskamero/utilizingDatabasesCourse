using System;
using System.Collections.Generic;

namespace RPGInventaario.Models;

public partial class Item
{
    public int Id { get; set; }

    public string ItemName { get; set; } = null!;

    public int? ItemTypeId { get; set; }

    public int? RarityId { get; set; }

    public decimal? BaseValue { get; set; }

    public decimal? AttValue { get; set; }

    public decimal? DefValue { get; set; }

    public virtual ItemType? ItemType { get; set; }

    public virtual ItemRarity? Rarity { get; set; }
}
