namespace MediaMarktProjectApi.Application.Dtos.Common;
public record PagingParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
