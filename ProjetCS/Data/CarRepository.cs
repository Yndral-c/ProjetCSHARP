using Microsoft.EntityFrameworkCore;
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
}