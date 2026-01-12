namespace MediaMarktProjectApi.Tests.Seed
{
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
    }
}
