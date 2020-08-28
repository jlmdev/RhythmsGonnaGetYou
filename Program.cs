using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace RhythmsGonnaGetYou
{
    // Create Band class to represent Bands table in database
    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public bool IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
    }

    // Create Album class to represent Albums table in database
    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int BandId { get; set; }
        public Band Band { get; set; }
    }

    // Create context to connect to database
    class RhythmTestContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=localhost;database=RhythmsGonnaGetYou");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the connection context and references to the tables
            var context = new RhythmTestContext();

            var bands = context.Bands;
            var albums = context.Albums.Include(album => album.BandId);

            // Create While Loop for Program
            var runProgram = true;
            while (runProgram)
            {
                // TODO: Show Menu
                // Clear the console
                Console.Clear();

                // Display the menu options
                Console.WriteLine("*** Main Menu ***");
                Console.WriteLine("Options:");
                Console.WriteLine("Add a new band (ab)");
                Console.WriteLine("View all bands (vb)");
                Console.WriteLine("Add an album for a band (aa)");
                Console.WriteLine("Unsign a band (u)");
                Console.WriteLine("Re-sign a band (r)");
                Console.WriteLine("View all albums for a band (vab)");
                Console.WriteLine("View all albums sorted by release date (vaa)");
                Console.WriteLine("View all bands that are signed (vs)");
                Console.WriteLine("View all bands that are unsigned (vu)");
                Console.WriteLine("Quit Program");

                // TODO: Create Menu Options switch statement
                // Get Option from user
                var optionSelected = Console.ReadLine();

                switch (optionSelected)
                {
                    //      TODO: Option: Add a new band (ab)
                    case "ab":
                        break;
                    //      TODO: Option: View all bands (vb)
                    case "vb":
                        break;
                    //      TODO: Option: Add an album for a band (aa)
                    case "aa":
                        break;
                    //      TODO: Option: Unsign a band (u)
                    case "u":
                        break;
                    //      TODO: Option: Re-sign a band (r)
                    case "r":
                        break;
                    //      TODO: Option: View all albums for a band (vab)
                    case "vab":
                        break;
                    //      TODO: Option: View all albums sorted by release date (vaa)
                    case "vaa":
                        break;
                    //      TODO: Option: View all bands that are signed (vs)
                    case "vs":
                        break;
                    //      TODO: Option: View all bands that are unsigned (vu)
                    case "vu":
                        break;
                    //      TODO: Option: Quit Program
                    case "q":
                        runProgram = false;
                        break;
                    default:
                        break;

                }
            }
            Console.WriteLine("*** Goodbye ***");
        }

    }
}
