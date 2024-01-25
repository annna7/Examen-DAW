using test_examen.Models;
using test_examen.Models.Dto;

namespace test_examen.Services;

public interface IProductService
{
    public Task<Product> GetProduct(Guid id);
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task<Product> CreateProduct(CreateProductDto createProductDto);
    public Task DeleteProduct(Guid id);
}