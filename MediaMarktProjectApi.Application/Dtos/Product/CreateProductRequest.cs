namespace MediaMarktProjectApi.Application.Dtos.Product;

public class CreateProductRequest
{
    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Range(0.01, 10000000)]
    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    [Required]
    public Guid CategoryId { get; set; }
}

