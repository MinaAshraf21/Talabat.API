
namespace Company.Talabat.Domain.Entities
{
    public class ProductBrand : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
