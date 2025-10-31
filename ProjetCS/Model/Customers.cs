using System.ComponentModel.DataAnnotations;

namespace Projet_CS.Model;

public class Customers
{
    [Key]
    public Guid Id { get; set; } = new Guid();
    
    [Required] private string name;
    
    [Required] private string firstname;
    
    [Required] private DateTime birthdate;
    
    [Required] private string phoneNumber;
    
    [Required] private string email;
    
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string Firstname
    {
        get => firstname;
        set => firstname = value ?? throw new ArgumentNullException(nameof(value));
    }
    public DateTime Birthdate
    {
        get => birthdate;
        set => birthdate = value;
    }
    public string PhoneNumber
    {
        get => phoneNumber;
        set => phoneNumber = value ?? throw new ArgumentNullException(nameof(value));
    }
    public string Email
    {
        get => email;
        set => email = value ?? throw new ArgumentNullException(nameof(value));
    }
}