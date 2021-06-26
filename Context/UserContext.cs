using CarParkAvailability.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<User> Users { get; set; }

        //Data seeder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User {
                UserId = 1,
                FirstName = "Bob",
                LastName = "The Cat",
                Email = "bobthecat@email.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                ContactNumber = "642946"
            }, new User {
                UserId = 2,
                FirstName = "Aslan",
                LastName = "The Ginger",
                Email = "aslan@email.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                ContactNumber = "642949"
            }, new User
            {
                UserId = 3,
                FirstName = "Tartee",
                LastName = "The Shorthair",
                Email = "tartee@email.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                ContactNumber = "642943"
            });
        }
    }
}
