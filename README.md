# TPaginator

TPaginator is a flexible, easy-to-use, and highly customizable pagination library for .NET, designed to simplify pagination logic in your applications. It supports both synchronous and asynchronous pagination strategies, allowing you to efficiently paginate large collections of data with minimal complexity.

This package provides two primary strategies for pagination:

Synchronous Pagination: For non-async data sources like IEnumerable<T>.
Asynchronous Pagination: For async data sources like IQueryable<T>.
Features
Supports both synchronous and asynchronous pagination strategies.
Generically typed for use with any collection of data (IEnumerable<T>, IQueryable<T>).
Easy to integrate with any .NET application.
Clean and minimalistic API to ensure the best developer experience.
Fully unit-testable with mocks for strategies.
Paginate based on page number and page size.
Installation
To install TPaginator, simply run the following command in your NuGet Package Manager console:
  - dotnet add package TPaginator
Alternatively, you can install it via the NuGet Package Manager in Visual Studio.
