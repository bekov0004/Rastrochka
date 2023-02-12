namespace Domain.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int Installment { get; set; }
    public int Commissionforgoods { get; set; }
    public int TotalAmount { get; set; }
    public int Paymentpermonth { get; set; }
    public int CategoryId { get; set; }
}