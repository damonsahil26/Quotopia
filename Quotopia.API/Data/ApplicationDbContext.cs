using Microsoft.EntityFrameworkCore;
using Quotopia.API.Models;

namespace Quotopia.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
