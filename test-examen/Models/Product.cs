namespace test_examen.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; }

    public List<Order> Orders { get; set; }
}