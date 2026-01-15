namespace MediaMarktProjectApi.Domain.Common;

public class PagedList<T>
{
    public List<T> Items { get; set; }
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = count;
        CurrentPage = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    public PagedList<TDestination> Map<TDestination>(Func<T, TDestination> mapFunc)
    {
        var mappedItems = this.Items.Select(mapFunc).ToList();

        // Usamos el constructor existente
        return new PagedList<TDestination>(mappedItems, this.TotalCount, this.CurrentPage, this.PageSize);
    }
}