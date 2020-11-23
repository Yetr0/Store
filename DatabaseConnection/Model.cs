using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseConnection
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Rental> Sales { get; set; }
        public string Password { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        // public int ReleaseYear { get; set; }
        // public int AgeRestriction { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Actor> Actors { get; set; }
        public virtual List<Rental> Sales { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }

    public class Actor
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual List<Movie> Movies { get; set; }
    }

    public class Rental
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
