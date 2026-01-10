namespace MediaMarktProjectApi.Infrastructure.Interfaces;
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductByIdAsync(Guid id);
}
