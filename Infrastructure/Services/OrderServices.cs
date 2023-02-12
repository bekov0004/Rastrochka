using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class OrderServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public OrderServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
// продукт, сумма, номер
    //     телефона покупателя и диапазон рассрочки.
    public async Task<Response<OrderDto>> WillBuyPhone(int productid,int prices,string phonenumber,int deposit)
    {
        int n = 0; 
        if (deposit == 12) n = 3;
        else if (deposit == 18) n = 6;
        else if (deposit == 24) n = 9;
            
            
        if (deposit is 12 or 18 or 24)
        {
            var result = (
                from p in _context.Products
                where p.CategoryId == 1 && p.Id==productid  
                select new OrderDto()
                {
                    Id = p.Id,
                    ProductId = productid,
                    Price = p.Price,
                    Installment = deposit,
                    Commissionforgoods = (((p.Price * n) / 100)),
                    TotalAmount =(((p.Price * n) / 100) + p.Price),
                    Paymentpermonth = (((p.Price * n) / 100) + p.Price)/deposit,
                    PhoneNumber = phonenumber

                }).ToList();
        await _context.Orders.AddAsync(_mapper.Map<Order>(result.ToList()));
        await _context.SaveChangesAsync();
            
        }

        return new Response<OrderDto>(HttpStatusCode.BadRequest, new List<string>() { "Hello" });
    }
    
}