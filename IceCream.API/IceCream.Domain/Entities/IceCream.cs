using System.ComponentModel.DataAnnotations;

namespace IceCream.Domain.Entities;

public class IceCream : IAuditable
{
    [Key]
    public int IceCreamId { get; set; }
    public string Code { get; set; } = string.Empty;
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public int Stock { get; set; } = 0;
    public string Image { get; set; } = "/noimage.png";
    public decimal SellPrice { get; set; } = 0.00M;
    public decimal OfferPrice { get; set; } = 0.00M;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int ProviderId { get; set; }
    public Provider? Provider { get; set; }
}
