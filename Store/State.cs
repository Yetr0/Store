﻿using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using Microsoft.EntityFrameworkCore;

namespace Store
{
    class State
    {
        public static Customer User { get; set; }
        public static List<Movie> Movies { get; set; }
        public static Movie Pick { get; set; }
        public static List<Movie> Rentals { get; set; }
        public static List<Movie> Actions { get; set; }
        public static List<int> Genres { get; set; }
    }
}
