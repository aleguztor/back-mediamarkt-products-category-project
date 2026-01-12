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
    public async Task PutProduct_ShouldReturnOkAndCompareIfExistDataInDB()
    {
        // CREAMOS UNO
        CreateProductRequest createProduct = ProductFaker.CreateProductRequestFaker(null);
        var postResponse = await _client.PostAsJsonAsync("/api/product", createProduct);
        postResponse.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdProduct = await postResponse.Content.ReadFromJsonAsync<Product>();

        // UPDATE PRODUCT
        UpdateProductRequest newUpdateProduct = ProductFaker.CreateUpdateRequestFaker(createdProduct.Id, null);
        var response = await _client.PutAsJsonAsync("/api/product", newUpdateProduct);
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        //VOLVEMOS A OBTENER POR ID Y COMPROBAMOS
        var getProduct = await _client.GetAsync($"/api/product/{createdProduct.Id}");
        getProduct.Should().NotBeNull();
        var updatedProduct = await getProduct.Content.ReadFromJsonAsync<Product>();
        updatedProduct.Name.Should().NotBe(createdProduct.Name);
    }
    [Fact]
    public async Task CreateProduct_ShouldReturnOkAndReturnProduct()
    {
        CreateProductRequest createProduct = ProductFaker.CreateProductRequestFaker(null);
        var response = await _client.PostAsJsonAsync("/api/product", createProduct);

        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var products = await response.Content.ReadFromJsonAsync<ProductDto>();
        products.Should().NotBeNull();
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnOKAndCheckNotExist()
    {
        CreateProductRequest createProduct = ProductFaker.CreateProductRequestFaker(null);
        var postResponse = await _client.PostAsJsonAsync("/api/product", createProduct);
        if (!postResponse.IsSuccessStatusCode)
        {
            // Esto lee el cuerpo del error 400 que envía ASP.NET Core
            var errorBody = await postResponse.Content.ReadAsStringAsync();
            // Imprime esto en la consola de salida del test
            throw new Exception($"DETALLE DEL ERROR: {errorBody}");
        }
        var createdProduct = await postResponse.Content.ReadFromJsonAsync<Product>();

        var response = await _client.DeleteAsync($"/api/product/{createdProduct.Id}");

        response.StatusCode.Should().Be(HttpStatusCode.OK); 

        var getResponse = await _client.GetAsync($"/api/product/{createdProduct.Id}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
}
