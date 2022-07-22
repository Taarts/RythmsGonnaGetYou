using System;
// using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RythmsGonnaGetYou
{
    class Program
    {
        static void DisplayGreeting()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("    Welcome to Miami Sound Machine!     ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput;
        }
        static bool PromptForBool(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            if (userInput == "y" || userInput == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 'No' as your answer.");
                return 'N';
            }
        }


        static void Main(string[] args)
        {
            var context = new RythmsGonnaGetYouContext();
            // Console.WriteLine($"{newBand}");
            var bandCount = context.Bands.Count();
            Console.WriteLine($"There are {bandCount} bands.");


            var keepGoing = true;

            DisplayGreeting();

            // While the user hasn't said QUIT yet
            while (keepGoing)
            {
                // Insert a blank line then prompt them and get their answer (force uppercase)
                Console.WriteLine();
                Console.Write("What do you want to do?\n (A)dd a band:\n (V)iew all Bands:\n (F)ind a band\n Add new (S)ong\n or (Q)uit: ");
                // (U)pdate an employee\n (D)elete an employee\n 

                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "A":
                        addBand();
                        break;
                    case "V":
                        viewAllBands(context);
                        break;
                    case "F":
                        findBand(context);
                        break;
                    // case "G"
                    // 
                    // 
                    case "S":
                        var albumName = PromptForString("What Album are you looking for? ");

                        Album foundAlbum = context.FindOneAlbum(albumName);

                        if (foundAlbum == null)
                        {
                            Console.WriteLine("Album doesn't exist.");
                        }
                        // add album?
                        else
                        {
                            var newSong = new Song();
                            Console.WriteLine();
                            Console.WriteLine($"Do you want to add a song to {foundAlbum.Title}? [Y/N] ");
                            var answer = Console.ReadLine();

                            if (answer == "Y")
                            {
                                newSong.TrackNumber = PromptForInteger("Track number? ");
                                newSong.Title = PromptForString("What's the title of the track? ");
                                newSong.Duration = PromptForInteger("Duration of the song in (MM:SS)? ");
                                newSong.AlbumId = foundAlbum.Id;
                                // var songContext = new RythmsGonnaGetYouContext();

                                context.Songs.Add(newSong);
                                context.SaveChanges();
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("☠️ ☠️ ☠️ ☠️ ☠️ NOPE! ☠️ ☠️ ☠️ ☠️ ☠️");
                        break;

                }
            }


            static Band addBand()
            {
                var newBand = new Band();
                {
                    var context = new RythmsGonnaGetYouContext();

                    newBand.Name = PromptForString("What is the name of the new band? ");
                    newBand.CountryOfOrigin = PromptForString("What is the country of origin? ");
                    newBand.NumberOfMembers = PromptForInteger("How many band members are there? ");
                    newBand.Website = PromptForString("what's the band web address? ");
                    newBand.Style = PromptForString("What music genre do they play? ");
                    newBand.IsSigned = PromptForBool("Are they signed to a record label? ");
                    newBand.ContactName = PromptForString("Who is the main contact? ");
                    newBand.ContactPhoneNumber = PromptForString("What is the contact phone number? ");

                    context.Bands.Add(newBand);
                    context.SaveChanges();
                }
                return newBand;
            }

            // private static void bandsWithAlbums(RythmsGonnaGetYouContext context)

        }

        private static void findBand(RythmsGonnaGetYouContext context)
        {
            var name = PromptForString("What band are you looking for? ");

            Band foundBand = context.FindOneBand(name);

            if (foundBand == null)
            {
                Console.WriteLine("Band doesn't exist.");
            }
            // add album?
            else
            {
                var newAlbum = new Album();
                Console.WriteLine($"Do you want to add an album to {foundBand.Name}? [Y/N] ");
                var answer = Console.ReadLine();

                if (answer == "Y")
                {
                    newAlbum.Title = PromptForString("What is the name of album you want to add? ");
                    newAlbum.IsExplicit = PromptForString("Does the album have any explicit tracks? [Y/N]");
                    newAlbum.Band = foundBand;
                    newAlbum.ReleaseDate = PromptForDate($"What's the release date? (YYYY-MM-DD) ");
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();
                }
            }
        }

        private static DateTime PromptForDate(string prompt)
        {
            Console.WriteLine(prompt);
            var ReleaseDate = DateTime.Parse(Console.ReadLine());
            var inputValueUTC = ReleaseDate.ToUniversalTime();
            return inputValueUTC;
        }

        private static void viewAllBands(RythmsGonnaGetYouContext context)
        {
            Console.WriteLine($"Would you like to see a list of bands that are (S)igned or (U)nsigned? ");
            var signedOrNot = Console.ReadLine().ToUpper() == "S" ? true : false;
            foreach (var viewBand in context.Bands.Where(b => b.IsSigned == signedOrNot))
            {
                Console.WriteLine($" - {viewBand.Name}");

            }


            // Console.WriteLine("These are our bands:");
            // foreach (var viewBand in context.Bands)
            // {
            //     Console.WriteLine($" - {viewBand.Name}");
            // }
        }
    }
}
