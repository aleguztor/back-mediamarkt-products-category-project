using MediaMarktProjectApi.Application.Dtos.Common;

public record ProductsFilterRequest : PagingParams
{
    public string? GeneralSearch { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Name { get; set; }
    public string[]? Category { get; set; }
}