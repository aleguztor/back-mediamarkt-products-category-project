namespace MediaMarktProjectApi.Application.Dtos.Product;

public record UpdateProductRequest
{
    [Required(ErrorMessage = "El id es obligatorio.")]
    public required Guid Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 10000000, ErrorMessage = "El precio debe estar entre 0.01 y 10.000.000.")]
    public decimal Price { get; set; }

    [MaxLength(250, ErrorMessage = "La descripción no puede superar los 250 caracteres.")]
    public string Description { get; set; } = string.Empty;

    public Guid? CategoryId { get; set; }
}

