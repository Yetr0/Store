﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DatabaseConnection
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public virtual List<Rental> Sales { get; set; }
        public string Password { get; set; }
        public bool NewUser { get; set; }
        public virtual Genre favoriteGenre { get; set; }

     }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string ReleaseYear { get; set; }
        public string Rating { get; set; }
        public virtual List<Genre> Genres { get; set; }
        public virtual List<Rental> Sales { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
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
