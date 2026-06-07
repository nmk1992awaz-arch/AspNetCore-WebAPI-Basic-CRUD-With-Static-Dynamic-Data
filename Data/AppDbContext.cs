using System;
using System.Collections.Generic;
using Basic_CURD_Operation.Models;
using Microsoft.EntityFrameworkCore;

namespace Basic_CURD_Operation.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderId).ValueGeneratedOnAdd();
            entity.Property(e => e.OrderStatus).HasMaxLength(5);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
