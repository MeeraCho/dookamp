# ADR 0001: Adopt Clean Architecture

## Status

Accepted

## Context

DOOKAMP is a curriculum-based bilingual learning platform built with ASP.NET Core Web API.

As the application grows, it needs a maintainable structure that separates business logic, application use cases, API handling, and infrastructure concerns.

Keeping these responsibilities in a single project would make the application harder to maintain, test, and extend.

## Decision

DOOKAMP adopts Clean Architecture with four main layers:

- **Domain:** Contains core business entities and business rules.
- **Application:** Contains use cases, Queries, Handlers, DTOs, validators, and repository interfaces.
- **Infrastructure:** Implements repository interfaces and manages database access using Entity Framework Core and SQLite.
- **API:** Handles HTTP requests, controllers, dependency injection, and exception handling.

### Dependency Rules

- Domain does not depend on other layers.
- Application depends on Domain.
- Infrastructure depends on Application and Domain.
- API connects Application and Infrastructure through dependency injection.

## Consequences

### Benefits

- Separates business logic from infrastructure concerns.
- Makes application logic easier to test independently.
- Allows infrastructure implementations to change without changing core business logic.
- Improves maintainability as new features are added.

### Trade-offs

- Requires more projects, interfaces, and dependency configuration.
- Introduces additional structure compared to a simpler layered architecture.
- May require more initial setup for a small application.

## Implementation

The solution is organized into the following projects:

```text
src/
├── DooKamp.Api/
├── DooKamp.Application/
├── DooKamp.Domain/
└── DooKamp.Infrastructure/
```

Application defines repository interfaces, and Infrastructure provides their implementations through dependency injection.

Related documentation: `docs/architecture.md`