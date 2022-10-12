using System.ComponentModel.DataAnnotations;

namespace IceCream.Domain.Entities;

public class Category : IAuditable
{
    [Key]
    public int CategoryId { get; set; }
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid ImageId { get; set; }
    public string Image { get; set; } = "/noimage.png";
}
