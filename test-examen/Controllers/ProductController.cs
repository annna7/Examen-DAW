using Microsoft.AspNetCore.Mvc;
using test_examen.Models.Dto;
using test_examen.Services;

namespace test_examen.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        var product = await _productService.CreateProduct(productDto);
        return Ok(product);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
        catch
        {
            return NotFound("Product " + id + " not found!");
        }
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        try
        {
            var product = await _productService.GetProduct(id);
            return Ok(product);
        }
        catch
        {
            return NotFound("Product " + id + " not found!");
        }
    }
}