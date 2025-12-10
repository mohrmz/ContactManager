# Contact Manager API

A clean and production-ready RESTful API built with ASP.NET Core (.NET 10) using the MVC architecture.  
Contact Manager demonstrates best practices in modern API design, including:

- Entity Framework Core with multi-database migrations
- Soft Delete with global query filters
- Pagination
- Swagger/OpenAPI
- Secure file upload (multipart/form-data)
- Minimal third-party dependencies
- Secure coding principles
- Fully cross-platform support

This project is designed as a portfolio-quality backend template showcasing real-world API development skills.

## Project Overview

Contact Manager provides a foundational API for managing contacts with full CRUD operations, file upload support, and robust database architecture.  
The implementation is based on a set of professional-grade requirements emphasizing:

- Clean REST design
- Proper separation of concerns (MVC)
- EF Core migrations supporting SQL Server & PostgreSQL
- Soft delete instead of physical deletion
- Pagination for the “Get All” endpoint
- Handling both multipart/form-data and application/json
- Strong security practices (input validation, safe file operations, SQL injection prevention)
- Multi-platform execution (Linux, macOS, Windows, Docker)

The project is ideal for showcasing backend development expertise in interviews, GitHub portfolio, or technical assessments.

## Architecture


## Key Features

### Full RESTful API
- Clear routing, proper HTTP verbs, and clean resource-based endpoints.

### Entity Framework Core
- Multi-DB functional migrations  
- Providers supported:
  - SQL Server
  - PostgreSQL

### Soft Delete
- Global query filters ensure deleted data is never returned unless explicitly requested.

### File Upload
- Supports:
  - multipart/form-data
  - JSON + file hybrid request models
- Safe file handling prevents:
  - path traversal
  - invalid MIME types
  - oversized uploads

### Swagger Documentation
- Fully configured OpenAPI specification including:
  - endpoint grouping
  - schema documentation
  - file upload support

### Security Best Practices
- EF Core parameterized queries
- Data validation using annotations
- Sanitized file names
- Limited CORS exposure
- Production safe error responses

### Minimal Dependencies
- Only uses:
  - EF Core
  - Swashbuckle (Swagger)
- No heavy third-party packages

### Cross-platform & Docker
- Runs on:
  - Windows
  - Linux
  - macOS
- Includes a production-ready Dockerfile

## Contact Entity

```csharp
public class Contact : ISoftDelete
{
    public int? Id { get; set; }
    public int? CompanyId { get; set; }
    public int? UserId { get; set; }
    public string? Type { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public object? TaxNumber { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public object? Website { get; set; }
    public string? CurrencyCode { get; set; }
    public string? Reference { get; set; }
    public string? CreatedFrom { get; set; }
    public int? CreatedBy { get; set; }
    public string? FileNumber { get; set; }
    public string? Front { get; set; }
    public string? Back { get; set; }
    public bool IsDeleted { get; set; }
}

