namespace MediaMarktProjectApi.Application.Dtos.Product;

public record UpdateProductRequest
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 10000000)]
    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid? CategoryId { get; set; }
}

