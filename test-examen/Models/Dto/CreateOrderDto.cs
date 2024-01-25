namespace test_examen.Models.Dto;

public class CreateOrderDto
{
    public Guid UserId { get; set; }
    public List<Guid> ProductIds { get; set; } = null!;
}