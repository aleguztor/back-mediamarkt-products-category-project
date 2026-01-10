

namespace MediaMarktProjectApi.Application.Services
{
    public class ProductService : IProductService
    {
        public Task<Result<ProductDto>> CreateProductAsync(CreateProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> DeleteProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ProductDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<ProductDto>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateProductAsync(UpdateProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
