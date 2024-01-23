using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppOne.tralala;

public partial class PiratesContext : DbContext
{
    public PiratesContext()
    {
    }

    public PiratesContext(DbContextOptions<PiratesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Berth> Berths { get; set; }

    public virtual DbSet<Pirate> Pirates { get; set; }

    public virtual DbSet<Plunder> Plunders { get; set; }

    public virtual DbSet<Ship> Ships { get; set; }

    public virtual DbSet<PiratesPlunders> PiratesPlunders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-79AOHR2;Database=Pirates;Integrated Security=true;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Berth>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Berths__78A1A19C0C588306");

            entity.Property(e => e.Number)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Category)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("B")
                .IsFixedLength();

            entity.HasOne(d => d.Ship).WithMany(p => p.Berths)
                .HasForeignKey(d => d.ShipId)
                .HasConstraintName("FK_Berths_Ships");
        });

        modelBuilder.Entity<Pirate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pirates__3214EC07048ADF56");

            entity.HasIndex(e => e.BerthNumber, "UQ__Pirates__2763A59D13463D21").IsUnique();

            entity.Property(e => e.BerthNumber)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Names)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.NetWealth).HasColumnType("money");
            entity.Property(e => e.Pseudonym)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.BerthNumberNavigation).WithOne(p => p.Pirate)
                .HasForeignKey<Pirate>(d => d.BerthNumber)
                .HasConstraintName("FK_Pirates_Berths");

            entity.HasOne(d => d.Ship).WithMany(p => p.Pirates)
                .HasForeignKey(d => d.ShipId)
                .HasConstraintName("FK_Pirates_Ships");

            entity.HasMany(d => d.Plunders).WithMany(p => p.Pirates)
                .UsingEntity<Dictionary<string, object>>(
                    "PiratesPlunder",
                    r => r.HasOne<Plunder>().WithMany()
                        .HasForeignKey("PlunderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PiratesPl__Plund__35BCFE0A"),
                    l => l.HasOne<Pirate>().WithMany()
                        .HasForeignKey("PirateId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PiratesPl__Pirat__34C8D9D1"),
                    j =>
                    {
                        j.HasKey("PirateId", "PlunderId");
                        j.ToTable("PiratesPlunders");
                    });
        });

        modelBuilder.Entity<Plunder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Plunders__3214EC07511842FD");

            entity.Property(e => e.Location)
                .HasMaxLength(99)
                .IsUnicode(false);
            entity.Property(e => e.Spoils)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Ship>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ships__3214EC0786D3D986");

            entity.Property(e => e.Capacity).HasDefaultValue(10);
            entity.Property(e => e.Name)
                .HasMaxLength(21)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<PiratesPlunders>(entity => {
            entity.HasKey(e => new { e.PirateId, e.PlunderId });
            });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
