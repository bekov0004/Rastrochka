using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("[controller]")]
public class InstallmentController:ControllerBase
{
    private readonly InstallmentServices _installmentServices;

    public InstallmentController(InstallmentServices installmentServices)
    {
        _installmentServices = installmentServices;
    }

    [HttpGet("GetProduct")]
    public async Task<Response<List<ProductDto>>> GetProduct(int productid,int deposit,int category)
    {
       return await _installmentServices.GetProduct(productid,deposit,category);
    }
}