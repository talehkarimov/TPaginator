using Microsoft.EntityFrameworkCore;
using TPaginator.Models;

namespace TPaginator.Strategies;

public sealed class AsyncPaginationStrategy<T> : IAsyncPaginationStrategy<T>
{
    public async Task<PageResult<T>> PaginateAsync(IQueryable<T> source, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (page < 1) throw new ArgumentException("Page number must be >= 1.");
        if (pageSize < 1) throw new ArgumentException("Page size must be >= 1.");

        int totalItems = await source.CountAsync(cancellationToken);
        var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

        return new PageResult<T>(items, totalItems, page, pageSize);
    }
}
