namespace ProjetCS.Model;

public interface ICustomerRepository
{
    List<Customers> GetAllCustomers();
    
    void AddCustomer(Customers customer);
}