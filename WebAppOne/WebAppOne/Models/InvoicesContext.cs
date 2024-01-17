using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppOne.Models;

public partial class InvoicesContext : DbContext
{
    public InvoicesContext()
    {
    }

    public InvoicesContext(DbContextOptions<InvoicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Invoices;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_Addresses_ClientId");

            entity.Property(e => e.City).HasMaxLength(15);
            entity.Property(e => e.Country).HasMaxLength(15);
            entity.Property(e => e.StreetName).HasMaxLength(20);

            entity.HasOne(d => d.Client).WithMany(p => p.Addresses).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(25);
            entity.Property(e => e.NumberVat).HasMaxLength(15);

            entity.HasMany(d => d.Products).WithMany(p => p.Clients)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductsClient",
                    r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId"),
                    l => l.HasOne<Client>().WithMany().HasForeignKey("ClientId"),
                    j =>
                    {
                        j.HasKey("ClientId", "ProductId");
                        j.ToTable("ProductsClients");
                        j.HasIndex(new[] { "ProductId" }, "IX_ProductsClients_ProductId");
                    });
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_Invoices_ClientId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Client).WithMany(p => p.Invoices).HasForeignKey(d => d.ClientId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
