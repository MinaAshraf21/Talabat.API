using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Application.Abstractions.DTOs.Products
{
    public class ProductToReturnDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public required decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        public required string Category { get; set; }
        public required string Brand { get; set; }

    }
}
