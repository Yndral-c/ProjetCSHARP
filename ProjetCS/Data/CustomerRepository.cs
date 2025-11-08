namespace ProjetCS.Model;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _appDbContext;

    public CustomerRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Customers> GetAllCustomers()
    {
        return _appDbContext.Customers.ToList();
    }
}