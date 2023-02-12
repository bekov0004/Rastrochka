using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Price { get; set; }
    public int Installment { get; set; }
    public int Commissionforgoods { get; set; }
    public int TotalAmount { get; set; }
    public int Paymentpermonth { get; set; }
    public string PhoneNumber { get; set; }
    public int CustomerId{ get; set; }
    public Customer Customer { get; set; }
}