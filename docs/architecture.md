# Architecture

## 1. Technology Stack

| Category | Technology |
|---|---|
| Backend | .NET 10 |
| Web Framework | ASP.NET Core Web API |
| Architecture | Clean Architecture |
| ORM | Entity Framework Core |
| Database | SQLite |
| Validation | FluentValidation |
| Unit Testing | xUnit, Moq |
| API Testing | ASP.NET Core Integration Testing |

## 3. Architecture Style

### 3.1 Solution Structure

```text
DooKamp
│
├── src/
│   ├── DooKamp.Api/
│   ├── DooKamp.Application/
│   ├── DooKamp.Domain/
│   └── DooKamp.Infrastructure/
│
└── tests/
    ├── DooKamp.Application.Tests/
    └── DooKamp.Api.Tests/
```

### 3.2 Architecture Layers

**API**

- Handles HTTP requests and responses.
- Contains controllers and API configuration.
- Handles global exceptions through GlobalExceptionHandler.
- Registers application and infrastructure dependencies.

**Application**

- Contains application use cases.
- Implements Queries and Handlers.
- Defines repository interfaces.
- Contains DTOs and validation rules.
- Coordinates application operations.

**Domain**

- Contains core business entities and business rules.
- Represents the fundamental concepts of the learning platform.
- Does not depend on other application layers or infrastructure technologies.

**Infrastructure**

- Implements repository interfaces.
- Manages database access through Entity Framework Core.
- Contains DbContext and database configurations.
- Manages database migrations and seed data.

## 4. Dependency Rules

The application follows the Dependency Inversion Principle.

Dependencies point toward the inner layers.

```text

DooKamp.API ──────────────→ DooKamp.Application
                               │         ▲
                               ▼         │
                        DooKamp.Domain   │
                               ▲         │
                               │         │
DooKamp.Infrastructure ────────┘─────────┘
```

Dependency rules:

- Domain does not depend on other layers.
- Application depends on Domain.
- Infrastructure depends on Application and Domain.
- API configures dependency injection to connect Application and Infrastructure services.
- Application defines repository interfaces, while Infrastructure provides their implementations.

This keeps business logic independent of database implementation details.

## 5. Request Processing Flow

DOOKAMP uses a Direct Query/Handler approach instead of MediatR.

Controllers directly invoke the corresponding Handler.

Example: `GET /api/lessons`

```text
Client
  |
  v
LessonsController
  |
  v
GetLessonsQuery
  |
  v
GetLessonsHandler
  |
  +----> FluentValidation
  |
  v
ILessonRepository
  |
  v
LessonRepository
  |
  v
DooKampDbContext
  |
  v
SQLite
```

Request processing steps:

1. The client sends an HTTP request.
2. The controller creates a Query with the request parameters.
3. The controller invokes the corresponding Handler.
4. The Handler validates the Query.
5. The Handler calls the repository interface.
6. The repository retrieves data through Entity Framework Core.
7. The Handler returns the result.
8. The controller returns an HTTP response.

The Handler is responsible for coordinating the use case, while the repository handles data access.

## 6. Cross-Cutting Concerns

DOOKAMP uses shared mechanisms to handle common application concerns.

### 6.1 Validation

- FluentValidation is used to validate application queries.
- Validators are registered through dependency injection.
- Invalid requests are handled through application validation exceptions.

### 6.2 Exception Handling

- GlobalExceptionHandler provides centralized exception handling.
- NotFoundException represents resources that cannot be found.
- ApplicationValidationException represents application validation failures.

### 6.3 Asynchronous Processing

- Asynchronous methods use `async` and `await`.
- CancellationToken is passed through request processing and repository operations where applicable.

### 6.4 Database Query Optimization

- Entity Framework Core is used for database access.
- `AsNoTracking()` is used for read-only queries where appropriate.
- Related entities are loaded when required by the application use case.

## 7. Testing Strategy



## 8. Future Architecture Considerations

The architecture is designed to support future features as DOOKAMP expands.

Potential additions include:

- User authentication and authorization.
- Student and parent account management.
- Lesson progress tracking.
- Quiz attempts and learning history.
- Additional learning activities and language support.