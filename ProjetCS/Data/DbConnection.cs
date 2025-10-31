using ProjetCS.Data;
using ProjetCS.Model;

public class DbConnection
{
    private readonly AppDbContext _appDbContext;
    public DbConnection(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void SaveFullCars(List<Cars> car)
    {
        _appDbContext.Add(car);
        _appDbContext.SaveChanges();
    }
    
    public void SaveFullCustomers(List<Customers> customers)
    {
        _appDbContext.Add(customers);
        _appDbContext.SaveChanges();
    }
}