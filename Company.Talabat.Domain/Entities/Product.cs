namespace Company.Talabat.Domain.Entities
{
    public class Product : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public required decimal Price { get; set; }

        // Foreign keys
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        // Navigation properties
        public virtual ProductCategory? Category { get; set; }
        public virtual ProductBrand? Brand { get; set; }
    }
}
