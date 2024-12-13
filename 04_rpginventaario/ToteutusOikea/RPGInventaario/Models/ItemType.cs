﻿using System;
using System.Collections.Generic;

namespace RPGInventaario.Models;

public partial class ItemType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
