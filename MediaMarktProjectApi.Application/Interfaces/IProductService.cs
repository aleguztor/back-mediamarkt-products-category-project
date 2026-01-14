namespace MediaMarktProjectApi.Application.Interfaces;

public interface IProductService
{
    Task<Result<PagedList<ProductDto>>> GetAllAsync(ProductsFilterRequest productsFilterRequest);
    Task<Result<ProductDto>> GetByIdAsync(Guid id);
    Task<Result<ProductDto>> CreateProductAsync(CreateProductRequest request);
    Task<Result<bool>> UpdateProductAsync(UpdateProductRequest request);
    Task<Result<bool>> DeleteProductByIdAsync(Guid id);
    
}

