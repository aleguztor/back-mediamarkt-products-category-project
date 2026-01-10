namespace MediaMarktProjectApi.Application.Dtos.Category;
public record CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
