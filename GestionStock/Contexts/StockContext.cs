﻿using GestionStock.Models;
using GestionStock.Models.Entitiy;
using GestionStock.Seeds;
using Microsoft.EntityFrameworkCore;

namespace GestionStock.Contexts
{
    public class StockContext : DbContext
    {
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<StockProductStore> StockProductStores { get; set; } = null!;
        public DbSet<Sector> Sectors { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<StockLedger> StockLedgers { get; set; } = null!;

        public StockContext(DbContextOptions<StockContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Product");
                p.HasKey(p => p.Id);
                p.HasOne<Category>(c => c.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                p.HasMany<StockProductStore>(s => s.Stock)
                    .WithOne(p => p.Product)
                    .HasForeignKey(p => p.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
                p.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
                p.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()");
                p.Property(p => p.Name).IsRequired().HasMaxLength(100);
                p.Property(p => p.Code).IsRequired().HasMaxLength(20);
                p.Property(p => p.Description).IsRequired().HasMaxLength(512);
            });

            modelBuilder.Entity<Store>(s =>
            {
                s.ToTable("Store");
                s.HasKey(s => s.Id);
                s.HasMany<StockProductStore>(s => s.Stock)
                    .WithOne(s => s.Store)
                    .HasForeignKey(s => s.StoreId)
                    .OnDelete(DeleteBehavior.Cascade);
                s.HasMany<Sector>(s => s.Sectors)
                    .WithOne(s => s.Store)
                    .HasForeignKey(s => s.StoreId)
                    .OnDelete(DeleteBehavior.Cascade);
                s.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
                s.Property(s => s.UpdatedAt).HasDefaultValueSql("GETDATE()");
                s.Property(s => s.Name).IsRequired().HasMaxLength(100);
                s.Property(s => s.Address).IsRequired().HasMaxLength(100);
                s.Property(s => s.Phone).IsRequired().HasMaxLength(50);
                s.Property(s => s.Email).IsRequired().HasMaxLength(100);
                s.Property(s => s.Description).IsRequired().HasMaxLength(512);
            });

            modelBuilder.Entity<Sector>(s =>
            {
                s.ToTable("Sector");
                s.HasKey(s => s.Id);
                s.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
                s.Property(s => s.UpdatedAt).HasDefaultValueSql("GETDATE()");
                s.Property(s => s.Name).IsRequired().HasMaxLength(100);
                s.Property(s => s.Description).IsRequired().HasMaxLength(512);
            });

            modelBuilder.Entity<Category>(c =>
            {
                c.ToTable("Category");
                c.HasKey(c => c.Id);
                c.Property(c => c.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<StockProductStore>(s =>
            {
                s.ToTable("StockProductStore");
                s.HasKey(s => new { s.ProductId, s.StoreId });
                s.HasOne<Sector>(s => s.Sector)
                    .WithMany(s => s.Stock)
                    .HasForeignKey(s => s.SectorId)
                    .OnDelete(DeleteBehavior.Restrict);
                s.Property(s => s.Quantity).IsRequired();
                s.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
                s.Property(s => s.UpdatedAt).HasDefaultValueSql("GETDATE()");
            });

            modelBuilder.Entity<StockLedger>(s =>
            {
                s.ToTable("StockLedger");
                s.HasKey(s => s.Id);
                s.HasOne<Product>(s => s.Product)
                    .WithMany()
                    .HasForeignKey(s => s.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
                s.HasOne<Store>(s => s.Store)
                    .WithMany()
                    .HasForeignKey(s => s.StoreId)
                    .OnDelete(DeleteBehavior.Restrict);
                s.Property(s => s.Quantity).IsRequired();
                s.Property(s => s.Action).IsRequired();
                s.Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
            });
            ///Seeds
            modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new ProductSeed());
            modelBuilder.ApplyConfiguration(new StoreSeed());
            modelBuilder.ApplyConfiguration(new SectorSeed());
            modelBuilder.ApplyConfiguration(new StockSeed());
            modelBuilder.ApplyConfiguration(new LedgerSeed());
        }
    }
}
