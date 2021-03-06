﻿using System;
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
        public static List<Genre> GetGenreList()
        {
            using var ctx = new Context();
            List<Genre> genres = new List<Genre>(); 
                genres = ctx.Genres.ToList();
            return genres;
        }
        public static Genre GetGenre(Customer cust)
        {
            using var ctx = new Context();
            Genre genre = new Genre();
            genre = ctx.Genres.Single(x => x.Id == cust.Id);
            return genre;
        }

        public static List<Movie> GetRentedMovies(Customer user)
        {
            List<Movie> movies = new List<Movie>();
            using var ctx = new Context();
            var rentals = ctx.Customers.FirstOrDefault(c => c.Id == user.Id).Sales.ToArray();
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

        public static void AddCustomer(string name, string password, string address, string email, int phonenumber)
        {
            using var ctx = new Context();
            try
            {
                ctx.AddRange(new Customer() { Name = name, Password = password,
                    Address = address, Email = email, PhoneNumber = phonenumber});
            }
            catch(Exception e)
            {
                Console.WriteLine("Detta gick fel:" + e);
            }
            ctx.SaveChanges();
        }
        public static void UpdateUsername(Customer cust, string name, string nameUpdate)
        {
            using var ctx = new Context();
            try
            {
                cust = ctx.Customers.First(x => x.Name == name);
                cust.Name = nameUpdate;
                ctx.Customers.Update(cust);
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine("Detta gick fel" + e);
            }
        }
        public static void UpdateAddress(Customer cust, string address, string addressUpdate)
        {
            using var ctx = new Context();
            try
            {
                cust = ctx.Customers.First(x => x.Address == address);
                cust.Name = addressUpdate;
                ctx.Customers.Update(cust);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Detta gick fel" + e);
            }
        }
        public static void UpdateEmail(Customer cust, string email, string emailUpdate)
        {
            using var ctx = new Context();
            try
            {
                cust = ctx.Customers.First(x => x.Email == email);
                cust.Name = emailUpdate;
                ctx.Customers.Update(cust);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Detta gick fel" + e);
            }
        }
        public static void UpdatePnumber(Customer cust, int pnumber, int pNumberUpdate)
        {
            using var ctx = new Context();
            try
            {
                cust = ctx.Customers.First(x => x.PhoneNumber == pnumber);
                cust.PhoneNumber = pNumberUpdate;
                ctx.Customers.Update(cust);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Detta gick fel" + e);
            }
        }
        public static void SetFavoriteGenre(Customer cust, string genreName)
        {
            using var ctx = new Context();
            try
            {
                cust.favoriteGenre = ctx.Genres.First(x => x.GenreName == genreName);

                ctx.Customers.Update(cust);
                ctx.SaveChanges();
            }
            catch (Exception e )
            {
                Console.WriteLine("Detta gick fel" + e);
            }
        }
        public static void setNewUserTrue(Customer cust)
        {
            using var ctx = new Context();
            try
            {
                //var customer = ctx.Customers.Where(x => x.Name == cust.Name).FirstOrDefault();
                
                cust.favoriteGenre = ctx.Genres.Find(1);
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
                movie.Genres = null;
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

        public static List<Movie> GetMoviesByGenre(int id)
        {
            List<Movie> movies = new List<Movie>();
            using var ctx = new Context();
            var rentals = ctx.Genres.FirstOrDefault(x => x.Id == id).Movies.ToArray();
            for (int i = 0; i < rentals.Length; i++)
            {
                movies.Add(rentals[i]);
            }
            return movies;
        }
        /*public static List<Movie> GetMoviesByGenre(Genre genre)
        {
            List<Movie> movies = new List<Movie>();
            using var ctx = new Context();
            var rentals = ctx.Genres.FirstOrDefault(x => x == genre).Movies.ToArray();
            for (int i = 0; i < rentals.Length; i++)
            {
                movies.Add(rentals[i]);
            }
            return movies;
        }*/
    }
}
