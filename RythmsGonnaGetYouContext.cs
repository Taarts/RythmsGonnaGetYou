using Microsoft.EntityFrameworkCore;

namespace RythmsGonnaGetYou
{
    public class RythmsGonnaGetYouContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RythmsGonnaGetYou");
        }
    }
}