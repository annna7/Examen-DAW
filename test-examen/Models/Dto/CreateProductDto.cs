namespace test_examen.Models.Dto;

public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Price { get; set; } = 0.0;
}