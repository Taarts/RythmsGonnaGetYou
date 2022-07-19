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
                Console.Write("What do you want to do?\n (A)dd a band:\n (V)iew all Bands:\n (F)ind a band\n or (Q)uit: ");
                // (U)pdate an employee\n (D)elete an employee\n or  or 

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

                    var Name = PromptForString("What is the name of the new band? ");
                    var CountryOfOrigin = PromptForString("What is the country of origin? ");
                    var NumberOfMembers = PromptForInteger("How many band members are there? ");
                    var Website = PromptForString("what's the band web address? ");
                    var Style = PromptForString("What music genre do they play? ");
                    var IsSigned = PromptForBool("Are they signed to a record label? ");
                    var ContactName = PromptForString("Who is the main contact? ");
                    var ContactPhoneNumber = PromptForString("What is the contact phone number? ");

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

                    Console.WriteLine($"What's the release date? (YYYY-MM-DD) ");
                    var ReleaseDate = DateTime.Parse(Console.ReadLine());

                    var inputValueUTC = ReleaseDate.ToUniversalTime();

                    newAlbum.ReleaseDate = inputValueUTC;
                    context.Albums.Add(newAlbum);
                    context.SaveChanges();
                }
            }
        }

        private static void viewAllBands(RythmsGonnaGetYouContext context)
        {
            Console.WriteLine("These are our bands:");
            foreach (var viewBand in context.Bands)
            {
                Console.WriteLine($" - {viewBand.Name}");
            }
        }
    }
}

