namespace MediaMarktProjectApi.Application.Interfaces;
public interface ICategoryService
{
    Task<Result<IEnumerable<CategoryDto>>> GetAllAsync();
}
