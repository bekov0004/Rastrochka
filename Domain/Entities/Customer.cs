namespace Domain.Entities;

public class Customer
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public List<Order> Orders { get; set; }
}