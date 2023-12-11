using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webAPI.Models;

public partial class TestDatabaseContext : DbContext
{
    public TestDatabaseContext()
    {
    }

    public TestDatabaseContext(DbContextOptions<TestDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Testitaulu> Testitaulus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=tcp:oskatestserver.database.windows.net,1433;Initial Catalog=TestDatabase;Persist Security Info=False;User ID=CloudSA568ac3f7;Password=Kilpikonna123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Testitaulu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("testitaulu", tb => tb.HasComment("testitaulu"));

            entity.Property(e => e.Etunimi)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sukunimi)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
