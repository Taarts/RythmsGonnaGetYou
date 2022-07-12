using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RythmsGonnaGetYouContext();

            var bandCount = context.Bands.Count();

            Console.WriteLine($"There are {bandCount} bands!");

            foreach (var band in context.Bands)
            {
                Console.WriteLine($"There is a band called {band.Name}");
            }
            var bandsWithAlbums = context.Bands.Include(band => band.Album);
            foreach (var band in bandsWithAlbums)
            {
                if (band.Album == null)
                {
                    Console.WriteLine($"{band.Name} have no albums yet. ");

                }
                else
                    Console.WriteLine($"{band.Name} wrote {band.Album.Title}");
            }
            // new band
            // var newBand = 
        }
    }
}