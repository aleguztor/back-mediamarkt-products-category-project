using Bogus.Extensions;

namespace MediaMarktProjectApi.Tests.Seed;
public class ProductFaker
{
    public static Faker<Product> CreateFaker(IEnumerable<Category> categories)
    {
        return new Faker<Product>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => f.Random.Decimal(10, 1000))
            .RuleFor(p => p.CategoryId, f => f.PickRandom(categories).Id);
    }
        
    public static Faker<CreateProductRequest> CreateProductRequestFaker(Category category)
    {
        return new Faker<CreateProductRequest>()
            .RuleFor(p => p.Name, f => f.Commerce.ProductName().ClampLength(max:100))
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => f.Finance.Amount(0.01m, 10000000m, 2))
            .RuleFor(p => p.CategoryId, f => category?.Id);
    }
    public static Faker<UpdateProductRequest> CreateUpdateRequestFaker(Guid id, Category category)
    {
        return new Faker<UpdateProductRequest>()
            .RuleFor(p => p.Id, f => id)
            .RuleFor(p => p.Name, f => f.Commerce.ProductName().ClampLength(max: 100))
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Price, f => f.Finance.Amount(0.01m, 10000000m, 2))
            .RuleFor(p => p.CategoryId, f => category?.Id);
    }

}