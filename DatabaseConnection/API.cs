using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace DatabaseConnection
{
    public class API
    {
        public static List<Movie> GetMovieSlice(int a, int b)
        {
            using var ctx = new Context();
            return ctx.Movies.OrderBy(m => m.Title).Skip(a).Take(b).ToList();
        }


        public static List<Movie> GetRentedMovies(Customer user)
        {
            List<Movie> movies = new List<Movie>();
            using var ctx = new Context();
            var rentals = ctx.Customers.Find(user.Id).Sales.ToArray();
            for (int i = 0; i < rentals.Length; i++)
            {
                movies.Add(rentals[i].Movie);
            }
            return movies;
        }

        public static Customer GetCustomerByName(string name, string password)
        {
            using var ctx = new Context();
                var user = ctx.Customers.FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
            if (user != null)
            {
                return user.Password == password ? user : null;
            }
            else
            {
                return null;
            }
        }

        public static void AddCustomerByName(string name, string password)
        {
            using var ctx = new Context();
            try
            {
                ctx.AddRange(new Customer() { Name = name, Password = password });
            }
            catch(Exception e)
            {
                Console.WriteLine("Detta gick fel:" + e);
            }
            ctx.SaveChanges();
        }
        public static void setNewUserTrue(Customer cust)
        {
            using var ctx = new Context();
            try
            {
                //var customer = ctx.Customers.Where(x => x.Name == cust.Name).FirstOrDefault();

                cust.NewUser = true;
                ctx.Customers.Update(cust);
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Fixa fel msg sen");
            }
        }
        public static bool RegisterSale(Customer customer, Movie movie)
        {
            using var ctx = new Context();
            try
            {
                // Här säger jag åt contextet att inte oroa sig över innehållet i dessa records.
                // Om jag inte gör detta så kommer den att försöka updatera databasens Id och cracha.
                ctx.Entry(customer).State = EntityState.Unchanged;
                ctx.Entry(movie).State = EntityState.Unchanged;

                ctx.Add(new Rental() { Date = DateTime.Now, Customer = customer, Movie = movie });
                return ctx.SaveChanges() == 1;
            }
            catch(DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
        public static bool AddToWatchList(Customer customer, Movie movie)
        {
            using var ctx = new Context();
            ctx.Entry(customer).State = EntityState.Unchanged;
            ctx.Entry(movie).State = EntityState.Unchanged;
            ctx.Add(new WatchList { Customer = customer, Movie = movie });
            return ctx.SaveChanges() == 1;
        }
    }
}
