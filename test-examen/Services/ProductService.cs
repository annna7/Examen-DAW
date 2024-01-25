using Microsoft.EntityFrameworkCore;
using test_examen.Models;
using test_examen.Models.Dto;

namespace test_examen.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    
    public ProductService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Product> GetProduct(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new Exception("Product not found!");
        }
        return product;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }

    public async Task<Product> CreateProduct(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price
        };
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProduct(Guid id)
    {
        var product = await GetProduct(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}