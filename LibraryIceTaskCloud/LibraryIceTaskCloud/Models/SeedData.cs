using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LibraryIceTaskCloud.Data;
using System;
using System.Linq;


namespace LibraryIceTaskCloud.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new LibraryIceTaskCloudContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<LibraryIceTaskCloudContext>>()))
        {
            // Look for any Books.
            if (context.Library.Any())
            {
                return;   // DB has been seeded
            }
            context.Library.AddRange(
                new Library
                {
                    Title = "Captain Underpants",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Comic comedy",
                    Price = 150
                },
                new Library
                {
                    Title = "Harry Potter",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Adventure Fantasy",
                    Price = 200
                },
                new Library
                {
                    Title = "Heroes of olympus",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Action adventure",
                    Price = 234
                },
                new Library
                {
                    Title = "Berylium",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Sci-Fi",
                    Price = 199
                }
            );
            context.SaveChanges();
        }
    }
}
