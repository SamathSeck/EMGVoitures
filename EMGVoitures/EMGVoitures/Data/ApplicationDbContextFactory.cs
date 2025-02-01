using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EMGVoitures.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Créer un objet DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Charger la configuration à partir de appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Assurez-vous que le répertoire de travail est correct
                .AddJsonFile("appsettings.json") // Charger le fichier appsettings.json
                .Build();

            // Utiliser la chaîne de connexion de la configuration
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
