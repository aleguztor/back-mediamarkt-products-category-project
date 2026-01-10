using MediaMarktProjectApi.Infrastructure.Persistance;

namespace MediaMarktProjectApi.Infrastructure.Repositories;
public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    
    public async Task<Product?> GetByIdAsync(Guid id)
        => await context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Product>> GetAllAsync()
        => await context.Products.Include(p => p.Category).ToListAsync();

    public async Task CreateProductAsync(Product product)
    {
        await context.Products.AddAsync(product);

        await context.SaveChangesAsync();
    }
        
    public async Task UpdateProductAsync(Product product)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task DeleteProductByIdAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }

}
