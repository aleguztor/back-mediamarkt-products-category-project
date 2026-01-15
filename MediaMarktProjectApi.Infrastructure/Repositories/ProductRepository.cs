using MediaMarktProjectApi.Infrastructure.Extensions;

namespace MediaMarktProjectApi.Infrastructure.Repositories;
public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    
    public async Task<Product?> GetByIdAsync(Guid id)
        => await context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<PagedList<Product>> GetAllAsync(ProductsFilterRequest filter)
    {
      var query =  context.Products.Include(p => p.Category).AsQueryable();
        if (!string.IsNullOrWhiteSpace(filter.GeneralSearch))
        {
            var search = filter.GeneralSearch.Trim().ToLower();

            query = query.Where(p =>
                p.Name.ToLower().Contains(search) ||
                p.Description.ToLower().Contains(search) ||
                (p.Category != null && p.Category.Name.ToLower().Contains(search))
            );
        }

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            query = query.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));
        }

        if (filter.MinPrice.HasValue)
        {
            query = query.Where(p => p.Price >= filter.MinPrice.Value);
        }

        if (filter.MaxPrice.HasValue)
        {
            query = query.Where(p => p.Price <= filter.MaxPrice.Value);
        }

        if (filter.Category != null && filter.Category.Length > 0)
        {
            query = query.Where(p => p.Category != null && filter.Category.Contains(p.Category.Name));
        }

        if (!string.IsNullOrWhiteSpace(filter.SortBy))
        {
            query = filter.SortBy.ToLower() switch
            {
                "name" => filter.IsDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
                "price" => filter.IsDescending ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price),
                "category.name" => filter.IsDescending ? query.OrderByDescending(p => p.Category != null ? p.Category.Name : string.Empty) : query.OrderBy(p => p.Category != null ? p.Category.Name : string.Empty),
                _ => query.OrderBy(p => p.Name)
            };
        }
        return await query.ToPagedListAsync(filter.PageNumber, filter.PageSize);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        return product;
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