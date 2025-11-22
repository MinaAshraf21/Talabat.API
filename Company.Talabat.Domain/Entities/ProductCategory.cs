namespace Company.Talabat.Domain.Entities
{
    public class ProductCategory : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        // Navigation property
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
