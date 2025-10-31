namespace Projet_CS.Model;

public class Car
{
    [Key]
    public Guid Id { get; set; } = new Guid();

    [Required] private string brand;

    [Required] private string model;

    [Required] private string year;

    [Required] private double priceHt;

    [Required] private string color;

    [Required] private bool sale;
    
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
        set => priceHt = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string Color
    {
        get => color;
        set => color = value ?? throw new ArgumentNullException(nameof(value));
    }
    public bool Sale
    {
        get => sale;
        set => sale = value ?? throw new ArgumentNullException(nameof(value));
    }
}