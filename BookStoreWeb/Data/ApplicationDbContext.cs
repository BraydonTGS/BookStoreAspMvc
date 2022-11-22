using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Establish the Connection with Entity Framework //
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) 
        { 

        }

        // Create a DB Set to create a table in your database //
        public DbSet<Category> Categories { get; set; } 

    }


}
