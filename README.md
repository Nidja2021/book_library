
# Book Library API (in progress)

This project is a Book Library API built using .NET 6, ASP.NET Core Web API, Entity Framework, PostgreSQL, Docker. The API provides a platform for managing book library operations, including books listing and borrowing.

## Technologies
- .NET 6
- ASP.NET Core Web API
- PostgreSQL
- Entity Framework
- Docker


## API Reference

#### BOOK
*Get list of the books
```http
  GET /api/books
```
*Create book and save to the db
```http
  POST /api/books
```
*Get a book by ID
```http
  GET /api/books/{id:guid}
```
*Update a book by ID
```http
  PATCH /api/books/{id:guid}
```
*Delete a book by ID
```http
  DELETE /api/books/{id:guid}
```

#### USER
*Add a new user
```http
  POST /api/users
```
*Get the user by ID
```http
  GET /api/users/{id:guid}
```
