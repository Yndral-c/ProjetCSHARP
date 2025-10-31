using System.ComponentModel;
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

        services.AddTransient<ICarRepository, CarRepository>();
    })
    .Build();
    
using var scope = host.Services.CreateScope();
ICarRepository carRepository = scope.ServiceProvider.GetRequiredService<ICarRepository>();

String pathCar = configuration.GetRequiredSection("CSVFiles")["ProjetCSVVoiture"];
String pathClient = configuration.GetRequiredSection("CSVFiles")["ProjetCSVClient"];


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
        Brand = values[1],
        Model = values[2],
        Year = values[3],
        PriceHt = Convert.ToDouble(values[4]),
        Color = values[5],
        Sale = Convert.ToBoolean(values[6])
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
        Lastname = values[1],
        Firstname = values[2],
        Birthdate = Convert.ToDateTime(values[3]),
        PhoneNumber = values[4],
        Email = values[5]
    };
    customers.Add(customer);
} 


DbConnection dbConnectionService = scope.ServiceProvider.GetRequiredService<DbConnection>();
// Insert data
dbConnectionService.SaveFullCars(cars);
dbConnectionService.SaveFullCustomers(customers);
    
