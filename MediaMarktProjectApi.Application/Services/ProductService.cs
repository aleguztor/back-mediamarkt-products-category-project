namespace MediaMarktProjectApi.Application.Services;
public class ProductService(IProductRepository repository) : IProductService
{
    public async Task<Result<ProductDto>> CreateProductAsync(CreateProductRequest request)
    {
        Product? createdProduct;

        Product newProduct = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        try
        {
            createdProduct = await repository.CreateProductAsync(newProduct);

        }catch(Exception ex)
        {
            return Result<ProductDto>.Failure(ex.Message + " \n" + ex.InnerException, ErrorType.Failure);
        }

        ProductDto productDto = new ProductDto
        {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Description = createdProduct.Description,
            Price = createdProduct.Price,
            CategoryId = createdProduct.CategoryId
        };

        return Result<ProductDto>.Success(productDto);
    }

    public async Task<Result<bool>> DeleteProductByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            return Result<bool>.Failure("Id is null or empty", ErrorType.Validation);

        try
        {
            await repository.DeleteProductByIdAsync(id);

        }catch(Exception ex)
        {
            return Result<bool>.Failure(ex.Message + " \n" + ex.InnerException, ErrorType.Failure);
        }

        return Result<bool>.Success(true);
    }

    public async Task<Result<IEnumerable<ProductDto>>> GetAllAsync()
    {
        IEnumerable<Product> products;
        try
        {
            products = await repository.GetAllAsync();

        } catch(Exception ex)
        {
            return Result<IEnumerable<ProductDto>>.Failure(ex.Message + " \n" + ex.InnerException, ErrorType.Failure);
        }

        IEnumerable<ProductDto> productDtos = products.Select(product => new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        });

        return Result<IEnumerable<ProductDto>>.Success(productDtos);
    }

    public async Task<Result<ProductDto>> GetByIdAsync(Guid id)
    {
        Product? product;

        if (id == Guid.Empty)
            return Result<ProductDto>.Failure("Id is null or empty", ErrorType.Validation);

        try
        {
            product = await repository.GetByIdAsync(id);

        }catch(Exception ex)
        {
            return Result<ProductDto>.Failure(ex.Message + " \n" + ex.InnerException, ErrorType.Failure);
        }

        if (product == null)
            return Result<ProductDto>.Failure("Product not found", ErrorType.NotFound);

        ProductDto productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        };

        return Result<ProductDto>.Success(productDto);
    }

    public async Task<Result<bool>> UpdateProductAsync(UpdateProductRequest request)
    {
        Product product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        try
        {
            await repository.UpdateProductAsync(product);

        }catch(Exception ex)
        {
            return Result<bool>.Failure(ex.Message + " \n" + ex.InnerException, ErrorType.Failure);
        }

        return Result<bool>.Success(true);
    }
}