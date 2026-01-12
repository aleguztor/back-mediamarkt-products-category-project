using MediaMarktProjectApi.Tests.Seed;

namespace MediaMarktProjectApi.Tests.Controllers;

public class ProductEndpointsTests : IClassFixture<MediaMarktApiFactory>
{

    private readonly HttpClient _client;

    public ProductEndpointsTests(MediaMarktApiFactory factory)
    {
        _client = factory.CreateClient();
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        TestDataSeeder.SeedProducts(db);
    }

    [Fact]
    public async Task GetAllProducts_ShouldReturnOkAndListData()
    {
        var response = await _client.GetAsync("/api/product");

        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var products = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
        products.Should().NotBeNull();
    }

    [Fact]
    public async Task CreateProduct_WithInvalidData_ShouldReturnBadRequest()
    {
        var invalidProduct = new CreateProductRequest { Name = "", Price=-1 }; 

        var response = await _client.PostAsJsonAsync("/api/product", invalidProduct);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}
