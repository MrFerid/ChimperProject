using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Chimper.DAL
{
    public class CompanyDB : DbContext
    {
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Covers> Covers { get; set; }
        public CompanyDB() : base("CompanyData")
        {

        }
    }
}