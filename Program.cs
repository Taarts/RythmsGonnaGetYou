using System;
using System.Linq;

namespace RythmsGonnaGetYou
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new RythmsGonnaGetYouContext();

            var bandCount = context.Bands.Count();

            Console.WriteLine($"There are {bandCount} bands!");
        }
    }
}
