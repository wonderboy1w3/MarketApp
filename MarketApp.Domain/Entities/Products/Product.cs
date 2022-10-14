using MarketApp.Domain.Commons;

namespace MarketApp.Domain.Entities;

public class Product : Auditable
{
    public string ItemName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
