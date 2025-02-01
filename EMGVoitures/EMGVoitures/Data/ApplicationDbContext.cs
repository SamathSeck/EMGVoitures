using EMGVoitures.Models;
using Microsoft.EntityFrameworkCore;

namespace EMGVoitures.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Voiture> Voitures { get; set; }
    }
}