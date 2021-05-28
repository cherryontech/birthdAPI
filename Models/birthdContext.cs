using Microsoft.EntityFrameworkCore;

namespace BirthdAPI.Models
{
        public class BirthdContext : DbContext
        {
            public BirthdContext(DbContextOptions<BirthdContext> options)
                : base(options)
            {
            }

            public DbSet<BirthdItem> BirthdItems { get; set; }
        }
    
}