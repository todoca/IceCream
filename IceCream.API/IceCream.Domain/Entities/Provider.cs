using System.ComponentModel.DataAnnotations;

namespace IceCream.Domain.Entities;

public class Provider : IAuditable
{
    [Key]
    public int ProviderId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    [StringLength(20)]
    public string Phone { get; set; } = string.Empty;
}
