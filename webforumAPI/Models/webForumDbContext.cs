using System;
using Microsoft.EntityFrameworkCore;

namespace webforumAPI.Models
{
    public class webForumDbContext : DbContext
    {
        public webForumDbContext(DbContextOptions<webForumDbContext> options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            //modelBuilder.Entity<User>().HasKey(u => new
            //{
            //    u.id,
            //    u.username,
            //});
        }

        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Reply> replies { get; set; }
    }
}

