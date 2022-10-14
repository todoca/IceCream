namespace IceCream.Domain.Entities;

public abstract class IAuditable
{
    public int Id { get; set; }
    public int? CreateUser { get; set; }
    public int? UpdateUser { get; set; }
    public int? DeleteUser { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public int State { get; set; } = 1;
}
