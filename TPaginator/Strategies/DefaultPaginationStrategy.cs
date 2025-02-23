using TPaginator.Models;

namespace TPaginator.Strategies;

public sealed class DefaultPaginationStrategy<T> : IPaginationStrategy<T>
{
    public PageResult<T> Paginate(IEnumerable<T> source, int page, int pageSize)
    {
        if(page < 1) throw new ArgumentException("Page number must be >= 1.");
        if (pageSize < 1) throw new ArgumentException("Page size must be >= 1.");

        int totalItems = source.Count();
        var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        
        return new PageResult<T>(items, totalItems, page, pageSize);
    }
}
