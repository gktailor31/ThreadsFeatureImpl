using Microsoft.EntityFrameworkCore;
using ThreadsFeature.Models;

namespace ThreadsFeature.Data
{
    public class ThreadsFeatureDbContext : DbContext
    {
        public ThreadsFeatureDbContext(DbContextOptions<ThreadsFeatureDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Comment> comments { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Like> likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
            .HasOne(b => b.Creator)
            .WithMany(a => a.Comments)
            .HasForeignKey(b => b.CreaterId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Parent)
                .WithMany(e => e.Child)
                .HasForeignKey(e => e.ParentId)
                .HasPrincipalKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Like>()
        .HasKey(sc => new { sc.UserId, sc.CommentId });

            modelBuilder.Entity<Like>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.LikedComments)
                .HasForeignKey(sc => sc.UserId).OnDelete(DeleteBehavior.NoAction);
                

            modelBuilder.Entity<Like>()
                .HasOne(sc => sc.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(sc => sc.CommentId)
                .OnDelete(DeleteBehavior.Cascade).OnDelete(DeleteBehavior.NoAction); ;

        }
    }
}
