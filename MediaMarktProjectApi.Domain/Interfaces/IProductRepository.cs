using MediaMarktProjectApi.Domain.Common;

namespace MediaMarktProjectApi.Domain.Interfaces;
public interface IProductRepository
{
    Task<PagedList<Product>> GetAllAsync(ProductsFilterRequest productsFilterRequest);
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product> CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductByIdAsync(Guid id);
}
