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
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }

        private int _pageSize = 5;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value < 0 ? 5 : Math.Min(value, MAX_PAGE_SIZE);
        }

        private int _pageIndex = 1;
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value < 1 ? 1 : value; 
        }

        private string? search;
        public string? Search
        {
            get => search;
            set => search = value?.ToLower();
        }

        private string? sort;
        public string? Sort
        {
            get => sort;
            set => sort = value?.ToLower();
        }

    }
}
