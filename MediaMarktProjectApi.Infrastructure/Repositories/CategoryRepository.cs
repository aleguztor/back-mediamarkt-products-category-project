namespace MediaMarktProjectApi.Infrastructure.Repositories;
public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetAllAsync()
    => await context.Categories.ToListAsync();
}
