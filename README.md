# DooKamp

**Understand what schools teach. Learn in English and your home language.**

DooKamp is a curriculum-based learning platform that makes foundational knowledge taught in Canadian and American elementary schools accessible to learners of different ages and language backgrounds.

### Who Is It For?

- **Elementary Students:** Learn and review foundational school concepts.
- **Multilingual Children and Families:** Understand school subjects in English and their home language.
- **Adult English Learners:** Build English vocabulary while learning foundational academic concepts.

## MVP Scope

The initial release focuses on **Alberta Grade 5 Science**, with learning content in English and Korean.

The MVP aims to provide a complete learning experience that includes:

- Curriculum-aligned lessons and bilingual vocabulary.
- Concept checks and interactive quizzes.
- User registration and authentication.
- Quiz results and saved learning progress.

The detailed requirements, technical constraints, implementation milestones, and completion criteria are documented in [`docs/mvp-scope.md`](docs/mvp-scope.md).

## Learning Experience

The planned learning experience follows this flow:

1. Browse available lessons.
2. Explore concepts through English and Korean explanations.
3. Learn key vocabulary in both languages.
4. Answer concept-check questions and lesson quizzes.
5. Review quiz results and track learning progress.

## Technology Stack

### Backend
- C#
- .NET 10 and ASP.NET Core Web API
- Clean Architecture
- Entity Framework Core
- SQLite
- FluentValidation
- xUnit

### Frontend - Planned 
- React
- TypeScript
- Redux
- RTK Query 

### Development and Deployment - Planned 
- GitHub Actions for continuous integration
- Azure for cloud deployment

## Architecture
DooKamp follows Clean Architecture principles to separate application responsibilities and improve maintainability.

```text
Client
  |
  v
ASP.NET Core Web API
  |
  v
Application Layer
  Queries and Handlers
  |
  v
Infrastructure Layer
  Repository and Data Access
  |
  v
Entity Framework Core
  |
  v
SQLite Database
```

The Domain layer contains the core entities and business concepts. The Application layer handles use cases, while the Infrastructure layer implements data access.

## Current Development Status

### Implemented
- Clean Architecture solution and project structure.
- Core domain entities and database relationships.
- Entity Framework Core and SQLite configuration.
- Database initialization and seed data.
- `GET /api/lessons` — Retrieve published lessons with optional location and grade filters.
- `GET /api/lessons/{id}` — Retrieve lesson details, bilingual content, vocabulary, and quiz questions.
- FluentValidation for query validation.
- Centralized exception handling with consistent error responses.
- Initial automated unit tests for application handlers.

### Planned
- Expanding automated test coverage.
- Building out the learning content and quiz functionality.
- Quiz answer submission and evaluation.
- React and TypeScript frontend.
- User registration and authentication.
- Lesson completion and quiz result persistence.
- Integration testing and continuous integration.
- Azure deployment and production verification.
See [`docs/mvp-scope.md`](docs/mvp-scope.md) for detailed requirements and implementation milestones.

## Getting Started

### Prerequisites
- .NET 10 SDK
- Git

### Run the Backend API

Clone the repository:

```bash
git clone https://github.com/MeeraCho/dookamp.git
cd dookamp
```

Restore dependencies:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

Run the API:

```bash
dotnet run --project src/DooKamp.Api
```

The API will start at the local URL shown in the terminal.

### API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| GET | `/api/lessons` | Retrieve published lessons |
| GET | `/api/lessons?locationId=1&gradeId=5` | Filter lessons by location and grade |
| GET | `/api/lessons/1` | Retrieve a lesson's details |

The filter values depend on the reference data seeded in the local database.

### Run Automated Tests

From the solution root:

```bash
dotnet test
```


