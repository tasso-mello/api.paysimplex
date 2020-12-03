namespace data.paysimplex.Context
{
    using data.paysimplex.Entities;
    using Microsoft.EntityFrameworkCore;

    public class PaySimplexContext : DbContext
    {

        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }


        public PaySimplexContext(DbContextOptions<PaySimplexContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Task>().HasKey(c => new { c.Id });
            modelBuilder.Entity<Entities.User>().HasKey(c => new { c.Id });
        }
    }
}
