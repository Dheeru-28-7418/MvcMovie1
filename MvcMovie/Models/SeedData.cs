using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Evil Dead",
                    ReleaseDate = DateTime.Parse("2012-02-08"),
                    Genre = "Horror",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Insidious",
                    ReleaseDate = DateTime.Parse("2007-01-07"),
                    Genre = "Horror",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Conjuring",
                    ReleaseDate = DateTime.Parse("2001-02-01"),
                    Genre = "Horror",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Rings",
                    ReleaseDate = DateTime.Parse("1995-02-01"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}