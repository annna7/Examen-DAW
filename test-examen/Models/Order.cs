namespace test_examen.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
    public virtual User? User { get; set; }
}