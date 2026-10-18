using Company.Talabat.Domain.Entities;

namespace Company.Talabat.Domain.Specifications.Products
{
    public class ProductWithBrandAndCategorySpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndCategorySpecifications
            (string? sort, int? categoryId, int? brandId, int pageSize, int pageIndex,string? search)
            : base(e =>
                        (string.IsNullOrEmpty(search) || e.Name.ToLower().Contains(search))
                           &&
                        ((!categoryId.HasValue) || e.CategoryId == categoryId.Value)
                           &&
                        (!(brandId.HasValue) || e.BrandId == brandId.Value)
                  )
        {
            AddIncludes();
            AddSorting(sort);

            if (pageSize > 0 && pageIndex > 0)
                AddPagination((pageIndex - 1) * pageSize, pageSize);
        }
        public ProductWithBrandAndCategorySpecifications
            (int? categoryId, int? brandId, string? search)
            : base(e =>
                        (string.IsNullOrEmpty(search) || e.Name.ToLower().Contains(search))
                           &&
                        ((!categoryId.HasValue) || e.CategoryId == categoryId.Value)
                           &&
                        (!(brandId.HasValue) || e.BrandId == brandId.Value)
                  )
        {
            AddIncludes();
        }
        public ProductWithBrandAndCategorySpecifications(int id) : base(id)
        {
            AddIncludes();
        }

        #region Helper Methods

        private protected override void AddIncludes()
        {
            Includes.Add(e => e.Brand!);
            Includes.Add(e => e.Category!);
        }

        private protected override void AddSorting(string? sort)
        {
            switch (sort)
            {
                case "priceAsc":
                    AddOrderBy(e => e.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(e => e.Price);
                    break;
                default:
                    AddOrderBy(e => e.Name);
                    break;
            }
        }

        #endregion    
    }
}
