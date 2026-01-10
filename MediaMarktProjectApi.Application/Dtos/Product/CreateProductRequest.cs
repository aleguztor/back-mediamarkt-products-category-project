namespace MediaMarktProjectApi.Application.Dtos.Product;

public record CreateProductRequest
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Range(0.01, 10000000)]
    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public Guid? CategoryId { get; set; }
}

