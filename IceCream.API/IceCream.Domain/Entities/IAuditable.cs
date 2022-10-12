namespace IceCream.Domain.Entities;

public class IAuditable
{
    public int CreateUser { get; set; }
    public int UpdateUser { get; set; }
    public int DeleteUser { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime UpdateDate { get; set; } = DateTime.Now;
    public DateTime DeleteDate { get; set; }
    public int State { get; set; } = 1;
}
