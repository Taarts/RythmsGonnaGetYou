using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace RythmsGonnaGetYou
{
    public class RythmsGonnaGetYouContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RythmDb");

            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }
        public Band FindOneBand(string nameToFind)
        {
            Band foundBand = Bands.FirstOrDefault(Band => Band.Name.ToUpper().Contains(nameToFind.ToUpper()));

            return foundBand;
        }
        public Album FindOneAlbum(string nameToFind)
        {
            Album foundAlbum = Albums.FirstOrDefault(Album => Album.Title.ToUpper().Contains(nameToFind.ToUpper()));

            return foundAlbum;
        }

    }
}