using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetCS.Data;
using ProjetCS.Model;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(@"C:\Users\Landry\RiderProjects\ProjetCSHARP\ProjetCS\appsettings.json", optional: false, reloadOnChange: true)
    .Build();
    
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // On enregistre le DbContext EF pour gérer la base
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        // On enregistre notre service CSV pour lire le fichier et mapper les objets
        services.AddTransient<DbConnection>();

        services.AddTransient<IPersonRepository, PersonRepository>();
    })
    .Build();