namespace MediaMarktProjectApi.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<Result<IEnumerable<CategoryDto>>> GetAllAsync()
    {
        IEnumerable<Category> categoryDtos;
        try
        {
            categoryDtos = await categoryRepository.GetAllAsync();

        }
        catch (Exception ex)
        {
            return Result<IEnumerable<CategoryDto>>.Failure(ex.Message + " \n" + ex.InnerException, ErrorType.Failure);
        }

        IEnumerable<CategoryDto> productDtos = categoryDtos.Select(product => new CategoryDto
        {
            Id = product.Id,
            Name = product.Name
        });

        return Result<IEnumerable<CategoryDto>>.Success(productDtos);
    }
}