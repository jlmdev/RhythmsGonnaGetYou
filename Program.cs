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
                Console.WriteLine("Quit Program (q)");

                // TODO: Create Menu Options switch statement
                // Get Option from user
                var optionSelected = Console.ReadLine();

                switch (optionSelected)
                {
                    //      TODO: Option: Add a new band (ab)
                    case "ab":
                        // Get input from user
                        Console.Write("Band Name: ");
                        var newBandName = Console.ReadLine();
                        Console.Write("Country of Origin: ");
                        var newCountryOfOrigin = Console.ReadLine();
                        Console.Write("Number of Members: ");
                        var newNumberOfMembers = int.Parse(Console.ReadLine());
                        Console.Write("Website: ");
                        var newWebsite = Console.ReadLine();
                        Console.Write("Style: ");
                        var newStyle = Console.ReadLine();
                        Console.Write("Is the band signed? (y/n): ");
                        var newIsSigned = true;
                        var newIsSignedYN = Console.ReadLine();
                        if (newIsSignedYN == "y")
                        {
                            newIsSigned = true;
                        }
                        else
                        {
                            newIsSigned = false;
                        }
                        Console.Write("Contact Name: ");
                        var newContactName = Console.ReadLine();
                        Console.Write("Contact Phone Number: ");
                        var newContactPhoneNumber = Console.ReadLine();

                        // Add a new band
                        var newBand = new Band
                        {
                            Name = newBandName,
                            CountryOfOrigin = newCountryOfOrigin,
                            NumberOfMembers = newNumberOfMembers,
                            Website = newWebsite,
                            Style = newStyle,
                            IsSigned = newIsSigned,
                            ContactName = newContactName,
                            ContactPhoneNumber = newContactPhoneNumber
                        };

                        context.Bands.Add(newBand);
                        context.SaveChanges();
                        break;
                    //      TODO: Option: View all bands (vb)
                    case "vb":
                        // Select and display all of the bands
                        foreach (var band in bands)
                        {
                            Console.WriteLine($"{band.Name}");
                        }
                        // pause to leave the display up to read
                        Console.Write("press 'enter' to continue");
                        var doneWithBandDisplay = Console.ReadLine();
                        break;
                    //      TODO: Option: Add an album for a band (aa)
                    case "aa":
                        // Add an album for a band
                        Console.Write("Title: ");
                        var newTitle = Console.ReadLine();
                        Console.Write("Explicit Lyrics? (y/n): ");
                        var newIsExplicit = true;
                        var newIsExplicitYN = Console.ReadLine();
                        if (newIsExplicitYN == "y")
                        {
                            newIsExplicit = true;
                        }
                        else
                        {
                            newIsExplicit = false;
                        }
                        Console.Write("Release Date Year: ");
                        var releaseYear = int.Parse(Console.ReadLine());
                        Console.Write("Release Date Month: ");
                        var releaseMonth = int.Parse(Console.ReadLine());
                        Console.Write("Release Date Day: ");
                        var releaseDay = int.Parse(Console.ReadLine());
                        Console.Write("Band Name: ");
                        var userInputAlbumBandName = Console.ReadLine();
                        var albumBand = bands.FirstOrDefault(band => band.Name == userInputAlbumBandName);
                        var albumBandId = albumBand.Id;
                        var newAlbum = new Album
                        {
                            Title = newTitle,
                            IsExplicit = newIsExplicit,
                            ReleaseDate = new DateTime(releaseYear, releaseMonth, releaseDay),
                            BandId = albumBandId
                        };
                        context.Albums.Add(newAlbum);
                        context.SaveChanges();
                        break;
                    //      TODO: Option: Unsign a band (u)
                    case "u":
                        // Unsign a band
                        Console.WriteLine("Band to Unsign: ");
                        var getBandToUnsign = Console.ReadLine();
                        var unsignThisBand = context.Bands.FirstOrDefault(band => band.Name == getBandToUnsign);

                        if (unsignThisBand != null)
                        {
                            unsignThisBand.IsSigned = false;
                            context.SaveChanges();
                        }
                        break;
                    //      TODO: Option: Re-sign a band (r)
                    case "r":
                        // Sign a band
                        Console.WriteLine("Band to Re-sign");
                        var getBandToSign = Console.ReadLine();
                        var signThisBand = context.Bands.FirstOrDefault(band => band.Name == getBandToSign);

                        if (signThisBand != null)
                        {
                            signThisBand.IsSigned = true;
                            context.SaveChanges();
                        }
                        break;
                    //      TODO: Option: View all albums for a band (vab)
                    case "vab":
                        // Given a band name, view all their albums
                        Console.Write("Band to list albums for: ");
                        var getAllBandAlbumsFor = Console.ReadLine();
                        var bandNameSelector = bands.FirstOrDefault(band => band.Name == getAllBandAlbumsFor);
                        if (bandNameSelector != null)
                        {
                            var bandNameId = bandNameSelector.Id;
                            var bandAlbums = context.Albums.Where(album => album.BandId == bandNameId);
                            foreach (var bandAlbum in bandAlbums)
                            {
                                Console.WriteLine(bandAlbum.Title);
                            }
                        }
                        else
                        {
                            Console.WriteLine("That band isn't in our database.");
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

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
                    //      TODO: Option: Quit Program (q)
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
