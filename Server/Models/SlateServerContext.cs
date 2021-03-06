using Microsoft.EntityFrameworkCore;
using Slate.Shared.Entities;

namespace Slate.Server.Models
{
  public class SlateServerContext : DbContext
  {
    public virtual DbSet<Board> Boards { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public SlateServerContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    // #region Required
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Board>()
    //         .Property(b => b.Url)
    //         .IsRequired();
    // }
    // #endregion
  }
}