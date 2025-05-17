using Microsoft.EntityFrameworkCore;
using SolidBlogsApi.Models;
using System.Text.Json;

namespace SolidBlogsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure Tags as JSON stored in a string column
            modelBuilder.Entity<Blog>()
                .Property(b => b.Tags)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                );
        }
    }
}
