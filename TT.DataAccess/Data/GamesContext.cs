using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TT.Models;

namespace TT.DataAccess.Data;

public partial class GamesContext : DbContext
{
    public GamesContext(DbContextOptions<GamesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Move>(entity =>
        {
            entity.HasOne(d => d.Game).WithMany(p => p.Moves)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Moves_Games");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
