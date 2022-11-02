using Film_Catalog.Models.DBClasses;
using Microsoft.EntityFrameworkCore;

namespace Film_Catalog
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<JwtLoggedOutToken> JwtLoggedOutTokens { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<T> DbSet<T>()where T : class
        {
            return Set<T>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Review>().HasOne(w => w.Author).WithMany(e => e.Reviews);
         modelBuilder.Entity<Review>().HasOne(w => w.Movie).WithMany(e => e.Reviews);
        // modelBuilder.Entity<Review>().HasKey(w => new { w.Author, w.Movie });
        }
    }
}
