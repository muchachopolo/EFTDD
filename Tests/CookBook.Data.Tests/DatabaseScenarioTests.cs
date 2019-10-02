using System;
using CookBook.Data.Context;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace CookBook.Data.Tests
{
    /**
     *   Here is all the data sources that we can configured
     *   https://docs.microsoft.com/en-us/ef/core/providers/index
     */
    public class DatabaseScenarioTests
    {
        private DbContextOptionsBuilder<DomainContext> configureContext()
        {
            var options = new DbContextOptionsBuilder<DomainContext>();
            options.UseInMemoryDatabase("CookBookTest");
            return options;
        }

        [Fact]
        public void CanCreateDatabase()
        {
            using (var db = new DomainContext(configureContext().Options))
            {
                bool isCreated = db.Database.EnsureCreated();
                Assert.True(isCreated);
            }
        }

        [Fact]
        public void CanNotCreateDatabaseIfNotConfigured()
        {
            using (var db = new DomainContext(new DbContextOptionsBuilder<DomainContext>().Options))
            {
                bool isCreated = false;
                try
                {
                    isCreated = db.Database.EnsureCreated();
                }
                catch(Exception ex)
                {
                    isCreated = false;
                }
                Assert.False(isCreated);
            }
        }
    }
}
