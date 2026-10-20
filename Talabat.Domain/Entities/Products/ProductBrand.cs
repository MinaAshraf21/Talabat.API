namespace Talabat.Domain.Entities.Products
{
    public class ProductBrand : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
