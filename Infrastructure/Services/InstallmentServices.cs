using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class InstallmentServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public InstallmentServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    // продукт, сумма, номер
    //     телефона покупателя и диапазон рассрочки.
    public async Task<Response<List<ProductDto>>> GetProduct(int productid,int deposit,int category)
    { 
       int n = 0; 
       if (deposit == 12) n = 3;
       else if (deposit == 18) n = 6;
       else if (deposit == 24) n = 9;
            
            
       if (deposit is 12 or 18 or 24)
        {
            var result = (
                from p in _context.Products
                where p.CategoryId == category && p.Id==productid
                select new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Installment = deposit,
                    Commissionforgoods = (((p.Price * n) / 100)),
                    TotalAmount =(((p.Price * n) / 100) + p.Price),
                    Paymentpermonth = (((p.Price * n) / 100) + p.Price)/deposit,
                    CategoryId = p.CategoryId

                }).ToList();
            return new Response<List<ProductDto>>(result);
        }
         
        else if(deposit==3 || deposit==9)
        {
            var result2 =(
                from p in _context.Products
                where p.CategoryId == category && p.Id== productid
                select new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Paymentpermonth =p.Price/deposit,
                    CategoryId = p.CategoryId

                }).ToList();
            return new Response<List<ProductDto>>(result2); 
        }

        return new Response<List<ProductDto>>(HttpStatusCode.BadRequest, new List<string>() { "Badrequest" });


    }
}