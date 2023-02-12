using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class OrderController:ControllerBase
{
    private readonly OrderServices _orderServices;

    public OrderController(OrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    [HttpPost]
    public async Task<Response<OrderDto>> AddOrder(int productid,int prices,string phonenumber,int deposit)
    {
        return await _orderServices.WillBuyPhone(productid, prices, phonenumber, deposit);
    }
}