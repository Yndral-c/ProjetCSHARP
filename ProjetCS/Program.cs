using System.ComponentModel;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetCS.Data;
using ProjetCS.Model;

var pathProject = PathHelper.SolutionRootPath;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile(pathProject  + "/appsettings.json", optional: false, reloadOnChange: true)
    .Build();
    
var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        // On enregistre le DbContext EF pour gérer la base
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        // On enregistre notre service CSV pour lire le fichier et mapper les objets
        services.AddTransient<DbConnection>();

        services.AddTransient<ICarRepository, CarRepository>();
    })
    .Build();
    
using var scope = host.Services.CreateScope();
ICarRepository carRepository = scope.ServiceProvider.GetRequiredService<ICarRepository>();


String pathCar = $"{pathProject}/Data/voitures.csv";
String pathClient = $"{pathProject}/Data/clients.csv";


List<Cars> cars = new List<Cars>();
List<Customers> customers = new List<Customers>();


var lignesCar = File.ReadAllLines(pathCar);
var lignesCustomer = File.ReadAllLines(pathClient);

// Lecture du CSV Voiture 
for (int i = 1; i < lignesCar.Length; i++) // On commence à 1 pour sauter l'en-tête
{
    string line = lignesCar[i];
    string[] values = line.Split('/');

    Cars car = new Cars
    {
        Brand = values[0],
        Model = values[1],
        Year = values[2],
        PriceHt = Convert.ToDouble(values[3], CultureInfo.InvariantCulture),
        Color = values[4],
        Sale = Convert.ToBoolean(values[5])
    };
    cars.Add(car);
}

// Lecture du CSV Client
for (int i = 1; i < lignesCustomer.Length; i++) // On commence à 1 pour sauter l'en-tête
{
    string line = lignesCustomer[i];
    string[] values = line.Split('%');

    Customers customer = new Customers
    {
        Lastname = values[0],
        Firstname = values[1],
        Birthdate = Convert.ToDateTime(values[2]),
        PhoneNumber = values[3],
        Email = values[4]
    };
    customers.Add(customer);
} 

DbConnection dbConnectionService = scope.ServiceProvider.GetRequiredService<DbConnection>();
dbConnectionService.SaveFullCars(cars);
dbConnectionService.SaveFullCustomers(customers);

Console.WriteLine("1) Voir liste Voitures");
Console.WriteLine("2) Historique d'achats");
Console.WriteLine("3) Ajouter un client");
Console.WriteLine("4) Ajouter une voiture");
Console.WriteLine("5) Faire un achat de voiture");
Console.WriteLine("6) Fin");
    
