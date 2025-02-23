using TPaginator.Strategies;
using TPaginator.Models;
namespace TPaginator;

public class Paginator<T>
{
    private readonly IPaginationStrategy<T>? _strategy;
    private readonly IAsyncPaginationStrategy<T>? _asyncStrategy;

    public Paginator(IPaginationStrategy<T> strategy)
    {
        _strategy = strategy;
    }

    public Paginator(IAsyncPaginationStrategy<T> asyncStrategy)
    {
        _asyncStrategy = asyncStrategy;
    }

    public PageResult<T> Paginate(IEnumerable<T> source, int page, int pageSize)
    {
        if (_strategy == null)
            throw new InvalidOperationException("Synchronous pagination strategy not provided.");

        return _strategy.Paginate(source, page, pageSize);
    }

    public async Task<PageResult<T>> PaginateAsync(IQueryable<T> source, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        if (_asyncStrategy == null)
            throw new InvalidOperationException("Async pagination strategy not provided.");

        return await _asyncStrategy.PaginateAsync(source, page, pageSize, cancellationToken);
    }
}
