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

                Movie movie = new Movie();
                movie.Title = "Toy Story";
                movie.ImageURL = "https://images-na.ssl-images-amazon.com/images/M/MV5BMDU2ZWJlMjktMTRhMy00ZTA5LWEzNDgtYmNmZTEwZTViZWJkXkEyXkFqcGdeQXVyNDQ2OTk4MzI@._V1_UX182_CR0,0,182,268_AL_.jpg";

                Customer customer = new Customer();
                customer.Name = "Björn";
                customer.Password = "Test";

                ctx.AddRange(new List<Customer> {
                    customer,
                    new Customer { Name = "Robin", Password= "Test" },
                    new Customer { Name = "Kalle", Password= "Test" },
                });

                Rental sales = new Rental();
                sales.Customer = customer;
                sales.Movie = movie;
                ctx.Add(sales);

                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\SeedData\MovieGenre.csv");
                for (int i = 1; i < 200; i++)
                {
                    // imdbId,Imdb Link,Title,IMDB Score,Genre,Poster
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');

                    // Hoppa över alla icke-fungerande url:er
                    try{ var test = new Uri(url); }
                    catch (Exception e) { continue; }

                    movies.Add(new Movie { Title = cells[2], ImageURL = url });
                }
                ctx.AddRange(movies);

                ctx.SaveChanges();
            }
        }
    }
}
