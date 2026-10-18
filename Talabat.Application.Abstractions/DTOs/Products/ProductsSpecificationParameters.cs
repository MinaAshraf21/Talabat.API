using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Abstractions.DTOs.Products
{
    public class ProductsSpecificationParameters
    {
        private const int MAX_PAGE_SIZE = 50;
        public string? Sort { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value; 
        }
        public int PageIndex { get; set; } = 1;

        private string? search;
        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }

    }
}
