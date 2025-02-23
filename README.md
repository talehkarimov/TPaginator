# TPaginator

`TPaginator` is a simple, flexible pagination library for .NET, supporting both **synchronous** and **asynchronous** pagination strategies. It allows you to easily paginate collections of data with minimal complexity.

## Features

- Supports both synchronous and asynchronous pagination strategies.
- Works with **IEnumerable<T>** (sync) and **IQueryable<T>** (async).
- Clean and minimalistic API.
- Fully unit-testable with mocks for strategies.

## Installation

To install `TPaginator`, run the following command in your NuGet Package Manager console:

```bash
dotnet add package TPaginator
```

## Usage
### Synchronous Pagination

To paginate an `IEnumerable<T>` collection, use the `Paginate` method with a synchronous pagination strategy.

```csharp
// Create a collection
var source = Enumerable.Range(1, 100);

// Initialize the paginator with a synchronous strategy
var paginator = new Paginator<int>(new DefaultPaginationStrategy<int>());

// Paginate the collection
var result = paginator.Paginate(source, page: 2, pageSize: 10);
```
### Asynchronous Pagination
```csharp
// Create an IQueryable collection
var source = Enumerable.Range(1, 100).AsQueryable();

// Initialize the paginator with an asynchronous strategy
var paginator = new Paginator<int>(new DefaultAsyncPaginationStrategy<int>());

// Paginate the collection asynchronously
var result = await paginator.PaginateAsync(source, page: 2, pageSize: 10);
```
