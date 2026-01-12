namespace MediaMarktProjectApi.Tests.Seed;
public class TestDataSeeder
{
    public static void SeedProducts(ApplicationDbContext db)
    {
        var categories = CategoryFaker.CreateFaker().Generate(3);
        db.Categories.AddRange(categories);

        var products = ProductFaker.CreateFaker(categories).Generate(10);
        db.Products.AddRange(products);

        db.SaveChanges();
    }
}

