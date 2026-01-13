namespace MediaMarktProjectApi.Application.Dtos.Product;

public record ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public CategoryDto? Category { get; set; } = null!;
}

