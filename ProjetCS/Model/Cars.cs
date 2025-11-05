using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetCS.Model;

public class Cars
{
    [Key]
    public Guid Id { get; set; } = new Guid();

    [Required] private string brand;

    [Required] private string model;

    [Required] private string year;

    [Required] private double priceHt;

    [Required] private string color;

    [Required] private bool sale;

    [ForeignKey("fk_customer_cars")]
    public Guid? IdCustomer {get; set;}
    
    public Customers? Customers {get; set;}
    
    public string Brand
    {
        get => brand;
        set => brand = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string Model
    {
        get => model;
        set => model = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string Year
    {
        get => year;
        set => year = value ?? throw new ArgumentNullException(nameof(value));
    }
    public double PriceHt
    {
        get => priceHt;
        set => priceHt = value;
    }
    public string Color
    {
        get => color;
        set => color = value ?? throw new ArgumentNullException(nameof(value));
    }
    public bool Sale
    {
        get => sale;
        set => sale = value;
    }
}