using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RPGInventaario.Models;

public partial class RpginventaarioContext : DbContext
{
    public RpginventaarioContext()
    {
    }

    public RpginventaarioContext(DbContextOptions<RpginventaarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemRarity> ItemRarities { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RPGInventaario;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Item__3214EC07C5524C2C");

            entity.ToTable("Item");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AttValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BaseValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DefValue).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ItemName).HasMaxLength(100);

            entity.HasOne(d => d.ItemType).WithMany(p => p.Items)
                .HasForeignKey(d => d.ItemTypeId)
                .HasConstraintName("FK__Item__ItemTypeId__286302EC");

            entity.HasOne(d => d.Rarity).WithMany(p => p.Items)
                .HasForeignKey(d => d.RarityId)
                .HasConstraintName("FK__Item__RarityId__29572725");
        });

        modelBuilder.Entity<ItemRarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemRari__3214EC077777E7D4");

            entity.ToTable("ItemRarity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RarityName).HasMaxLength(100);
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ItemType__3214EC07C5406296");

            entity.ToTable("ItemType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
