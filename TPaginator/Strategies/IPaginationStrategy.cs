using TPaginator.Models;

namespace TPaginator.Strategies;

public interface IPaginationStrategy<T>
{
    PageResult<T> Paginate(IEnumerable<T> source, int page, int pageSize);  
}
