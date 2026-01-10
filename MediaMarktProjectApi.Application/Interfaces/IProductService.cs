namespace MediaMarktProjectApi.Application.Interfaces;

public interface IProductService
{
    Task<Result<IEnumerable<ProductDto>>> GetAllAsync();
    Task<Result<ProductDto>> GetByIdAsync(string id);
    Task<Result<ProductDto>> CreateProductAsync(CreateProductRequest request);
    Task<Result<bool>> UpdateProductAsync(UpdateProductRequest request);
    Task<Result<bool>> DeleteProductByIdAsync(string id);
    
}

