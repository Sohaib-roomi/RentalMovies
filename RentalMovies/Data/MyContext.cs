using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalMovies.Data
{
        public class MyContext : DbContext
        {
        public MyContext() : base("RentalMovies")
        {


        }
        public DbSet<Movies> tbl_movies { get; set; }
        public DbSet<Genre> tbl_genres { get; set; }

        public DbSet<Customer> tbl_customer { get; set; }
        public DbSet<MembershipType> tbl_membershiptypes { get; set; }

    }
}