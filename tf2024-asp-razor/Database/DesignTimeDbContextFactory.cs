using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace tf2024_asp_razor.Database
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            // Charger la configuration depuis appSettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false)
                .Build();

            // Obtenir la chaîne de connexion
            string connectionString = config.GetConnectionString("Aeroport");

            // Configurer les options du DbContext
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, // Nombre maximal de tentatives
                    maxRetryDelay: TimeSpan.FromSeconds(30), // Délai maximal entre les tentatives
                    errorNumbersToAdd: null); // Numéros d'erreur SQL spécifiques à prendre en compte pour les nouvelles tentatives (optionnel)
            });

            return new DataContext(optionsBuilder.Options);
        }
    }
}