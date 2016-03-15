using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dannyallegrezzaBlog.Models
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public BlogDataContext()
        {
            Database.EnsureCreated();
        }

        public IQueryable<ArchivedPostSummary> GetArchivedPosts()
        {
            return Posts.GroupBy(x => new { x.PostedDate.Year, x.PostedDate.Month })
                    .Select(group => new ArchivedPostSummary
                    {
                        Count = group.Count(),
                        Year = group.Key.Year,
                        Month = group.Key.Month,
                    });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = @"Server=(LocalDb)\MSSQLLocalDb;Database=AspNetBlog";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForSqlServerUseIdentityColumns();
        }
    }
}
