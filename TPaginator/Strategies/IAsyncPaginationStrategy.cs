using TPaginator.Models;

namespace TPaginator.Strategies;

public interface IAsyncPaginationStrategy<T>
{
    Task<PageResult<T>> PaginateAsync(IQueryable<T> source, int page, int pageSize, CancellationToken cancellationToken = default);
}
