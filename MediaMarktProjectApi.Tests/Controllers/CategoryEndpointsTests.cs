namespace MediaMarktProjectApi.Tests.Controllers;
public class CategoryEndpointsTests : IClassFixture<MediaMarktApiFactory>
{
    private readonly HttpClient _client;

    public CategoryEndpointsTests(MediaMarktApiFactory factory)
    {
        _client = factory.CreateClient();
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        TestDataSeeder.SeedProducts(db);
    }

    [Fact]
    public async Task GetAllCategories_ShouldReturnOkAndListData()
    {
        var response = await _client.GetAsync("/api/category");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var products = await response.Content.ReadFromJsonAsync<List<CategoryDto>>();
        products.Should().NotBeNull();
    }
}
