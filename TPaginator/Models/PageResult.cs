namespace TPaginator.Models;

public sealed class PageResult<T>
{
    public List<T> Items { get; }
    public int TotalItems { get; }
    public int PageSize {  get; }
    public int CurrentPage { get; }
    public int TotalPages { get; }
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;

    public PageResult(List<T> items, int totalItems, int currentPage, int pageSize)
    {
        Items = items;
        TotalItems = totalItems;
        PageSize = pageSize;
        CurrentPage = currentPage;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
    }
}
