using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaAppApi.DataAccess.Entities;

public partial class TestDBContext : DbContext
{
    public TestDBContext()
    {
    }

    public TestDBContext(DbContextOptions<TestDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch_DM> Branch_DM { get; set; }

    public virtual DbSet<Currency_DM> Currency_DM { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch_DM>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Identification)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CurrencyNavigation).WithMany(p => p.Branch_DM)
                .HasForeignKey(d => d.Currency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Branch_DM_Currency_DM");
        });

        modelBuilder.Entity<Currency_DM>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.code)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
