namespace IceCream.Application.Dtos.Response;

public class CategoryResponseDto
{
    public int CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDate { get; set; }
    public int State { get; set; }
    public string? StateCategory { get; set; }
}
