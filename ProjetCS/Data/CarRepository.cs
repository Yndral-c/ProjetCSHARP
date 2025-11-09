using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using ProjetCS.Data;

namespace ProjetCS.Model;

public class CarRepository : ICarRepository
{
    private readonly AppDbContext _appDbContext;

    public CarRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Cars> GetAllCars()
    {
        return _appDbContext.Cars.ToList();
    }

    public void PurchaseCar(Guid IdCar, Guid IdCustomer)
    {
        // Trouver la voiture correspondante 
        Cars carToUpdate = _appDbContext.Cars.FirstOrDefault(c => c.Id == IdCar);
        if (carToUpdate == null)
        {
            throw new ArgumentException($"Car with ID {IdCar} not found.");
        }
        // Mettre à jour les données de la voiture
        carToUpdate.Sale = true;
        carToUpdate.IdCustomer = IdCustomer;

        _appDbContext.Cars.Update(carToUpdate);
        _appDbContext.SaveChanges()
    }
}