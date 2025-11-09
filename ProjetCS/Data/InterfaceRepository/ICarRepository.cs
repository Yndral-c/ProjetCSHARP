namespace ProjetCS.Model;

public interface ICarRepository
{
    List<Cars> GetAllCars();

    void PurchaseCar(Guid IdCar, Guid IdCustomer);
    
    List<Cars> GetPurchaseHistory(int customerId);
    
    void AddCar(Cars car);
}