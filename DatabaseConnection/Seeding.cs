using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace DatabaseConnection
{
    class Seeding
    {
        static void Main() 
        {
            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Sales);
                ctx.RemoveRange(ctx.Movies);
                ctx.RemoveRange(ctx.Customers);
                ctx.RemoveRange(ctx.WatchLists);


                Customer customer = new Customer();
                customer.Name = "Björn";
                customer.Password = "Test";

                ctx.AddRange(new List<Customer> {
                    customer,
                    new Customer { Name = "Robin", Password= "Test" },
                    new Customer { Name = "Kalle", Password= "Test" },
                });

                var genres = new List<Genre>()
                {
                    new Genre { GenreName = "Crime"},
                    new Genre { GenreName = "Action"},
                    new Genre { GenreName = "Comedy"},
                    new Genre { GenreName = "Drama"},
                    new Genre { GenreName = "Thriller"},
                    new Genre { GenreName = "Romance"},
                    new Genre { GenreName = "Adventure"},
                    new Genre { GenreName = "Family"},
                    new Genre { GenreName = "Fantasy"},
                    new Genre { GenreName = "Horror"},
                    new Genre { GenreName = "Mystery"},
                    new Genre { GenreName = "Sci-Fi"},
                };
                ctx.AddRange(genres);

                Movie movie = new Movie();
                movie.Title = "Toy Story";
                movie.ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMDU2ZWJlMjktMTRhMy00ZTA5LWEzNDgtYmNmZTEwZTViZWJkXkEyXkFqcGdeQXVyNDQ2OTk4MzI@._V1_UX182_CR0,0,182,268_AL_.jpg";
                movie.Rating = "10";
                movie.ReleaseYear = "1995";
                movie.Genres = new List<Genre>() { genres[2], genres[6], genres[7], genres[8] };

                Rental sales = new Rental();
                sales.Customer = customer;
                sales.Movie = movie;
                ctx.Add(sales);


                var movies = new List<Movie>();
                movies.Add(movie);
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,Year,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');

                    var url = cells[6].Trim('"');

                    var genre = cells[5].Split("|");

                    var year = cells[3];

                    var rating = cells[4];

                    List<Genre> Gens = new List<Genre>();
                    foreach (var gen in genre)
                    {
                        foreach (var Gen in genres)
                        {
                            if(gen == Gen.GenreName)
                            {
                                Gens.Add(Gen);
                            }
                        }
                    }

                    // Hoppa över alla icke-fungerande url:er
                    try{ var test = new Uri(url); }
                    catch (Exception e) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url, ReleaseYear = year, Genres = Gens, Rating = rating });
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
