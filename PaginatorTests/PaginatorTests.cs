using Moq;
using TPaginator.Models;
using TPaginator.Strategies;

namespace TPaginator.Tests
{
    public class PaginatorTests
    {
        [Fact]
        public void TestSyncPagination_ReturnsCorrectPage()
        {
            var mockStrategy = new Mock<IPaginationStrategy<int>>();
            var source = Enumerable.Range(1, 100);
            int page = 2;
            int pageSize = 10;

            var pageResult = new PageResult<int>(source.Skip((page - 1) * pageSize).Take(pageSize).ToList(), 100, page, pageSize);
            mockStrategy.Setup(strategy => strategy.Paginate(It.IsAny<IEnumerable<int>>(), page, pageSize)).Returns(pageResult);

            var paginator = new Paginator<int>(mockStrategy.Object);

            var result = paginator.Paginate(source, page, pageSize);

            Assert.Equal(10, result.Items.Count);  
            Assert.Equal(100, result.TotalItems); 
            Assert.Equal(2, result.CurrentPage);  
            Assert.Equal(10, result.PageSize);   
            Assert.Equal(10, result.TotalPages);  
            Assert.True(result.HasPreviousPage); 
            Assert.True(result.HasNextPage);
        }

        [Fact]
        public async Task TestAsyncPagination_ReturnsCorrectPage()
        {
            var mockAsyncStrategy = new Mock<IAsyncPaginationStrategy<int>>();
            var source = Enumerable.Range(1, 100).AsQueryable(); 
            int page = 2;
            int pageSize = 10;

            var pageResult = new PageResult<int>(source.Skip((page - 1) * pageSize).Take(pageSize).ToList(), 100, page, pageSize);
            mockAsyncStrategy.Setup(strategy => strategy.PaginateAsync(It.IsAny<IQueryable<int>>(), page, pageSize, It.IsAny<CancellationToken>())).ReturnsAsync(pageResult);

            var paginator = new Paginator<int>(mockAsyncStrategy.Object);

            var result = await paginator.PaginateAsync(source, page, pageSize);

            Assert.Equal(10, result.Items.Count);  
            Assert.Equal(100, result.TotalItems);  
            Assert.Equal(2, result.CurrentPage);   
            Assert.Equal(10, result.PageSize);    
            Assert.Equal(10, result.TotalPages);  
            Assert.True(result.HasPreviousPage);  
            Assert.True(result.HasNextPage);      
        }

        [Fact]
        public void TestSyncPagination_ThrowsExceptionWhenStrategyIsNull()
        {
            var paginator = new Paginator<int>(null as IPaginationStrategy<int>);  

            Assert.Throws<InvalidOperationException>(() => paginator.Paginate(Enumerable.Range(1, 100), 1, 10));
        }


        [Fact]
        public async Task TestAsyncPagination_ThrowsExceptionWhenStrategyIsNull()
        {
            var paginator = new Paginator<int>(null as IAsyncPaginationStrategy<int>);

            await Assert.ThrowsAsync<InvalidOperationException>(async () => await paginator.PaginateAsync(Enumerable.Range(1, 100).AsQueryable(), 1, 10));
        }
    }
}
