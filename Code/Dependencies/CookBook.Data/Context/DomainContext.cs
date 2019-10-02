using System;
using CookBook.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Data.Context
{
    public class DomainContext : DbContext
    {
        public DomainContext(DbContextOptions<DomainContext> options) : base(options)
        {
        }

        

        public DbSet<Publisher> Publishers { get; set; }
    }
}
