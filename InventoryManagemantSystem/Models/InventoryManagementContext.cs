using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagemantSystem.Models;

public partial class InventoryManagementContext : DbContext
{
    public InventoryManagementContext()
    {
    }

    public InventoryManagementContext(DbContextOptions<InventoryManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=InventoryManagement;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC074E27AD8D");

            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Product_name");
            entity.Property(e => e.ProductQnty)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Product_qnty");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Purchase__3214EC07D95B2BE9");

            entity.ToTable("Purchase");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("date")
                .HasColumnName("Purchase_date");
            entity.Property(e => e.PurchaseProd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Purchase_prod");
            entity.Property(e => e.PurchaseQnty)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Purchase_qnty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
