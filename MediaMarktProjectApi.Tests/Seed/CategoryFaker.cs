using Bogus.Extensions;

namespace MediaMarktProjectApi.Tests.Seed;
public class CategoryFaker
{
    public static Faker<Category> CreateFaker()
    {
        return new Faker<Category>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0].ClampLength(max:50));
    }
}