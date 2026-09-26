# DOOKAMP

**Bilingual Learning Adventure for Grades 1–6**

DOOKAMP is a bilingual learning platform designed to help children learn school curriculum content in English and their home language.

## Vision

Make learning understandable, engaging, and accessible for every child.

## Core Idea

Children learn the same school concepts through:

1. English Explanation
2. Korean Explanation
3. English Vocabulary
4. Korean Vocabulary
5. English Quiz
6. Korean Quiz

The goal is not simply to translate English content.

DOOKAMP provides explanations that children can understand and learn from in both languages.

## Target

- Grades 1–6
- North American students
- Bilingual and multilingual learners
- Children who learn primarily in English but want to maintain or develop another language

## Subjects

- Science
- Social Studies
- More subjects in the future

## Technology

### Frontend

- React
- TypeScript
- Redux
- Vite
- Responsive Web UI

### Backend

- ASP.NET Core
- C#

### Database

- SQL Server
- Entity Framework Core

### Future

- React Native
- AI-assisted content generation
- Personalized learning
- Spaced repetition
- Text-to-Speech
- Additional languages

## Project Structure

```text
dookamp/
│
├── client/                      # React + TypeScript
│   ├── src/
│   │   ├── domain/              # Business rules and entities
│   │   ├── application/         # Use cases and application ports
│   │   ├── infrastructure/     # API, storage, and external adapters
│   │   ├── presentation/        # Pages, components, Redux, and routing
│   │   └── shared/              # Cross-cutting UI utilities and types
│   └── tests/                   # React component and state tests
│
├── server/                      # ASP.NET Core + C#
│   ├── src/
│   │   ├── Dookamp.Domain/      # Entities, value objects, domain rules
│   │   ├── Dookamp.Application/ # Use cases, DTOs, interfaces
│   │   ├── Dookamp.Infrastructure/ # EF Core, SQL Server, integrations
│   │   └── Dookamp.WebApi/      # HTTP endpoints and composition root
│   └── tests/
│       ├── Dookamp.Domain.Tests/
│       ├── Dookamp.Application.Tests/
│       └── Dookamp.WebApi.Tests/
│
├── docs/                        # Product and technical documentation
│
├── .gitignore
├── README.md
└── LICENSE
```

### Dependency Rules

- `Domain` has no dependency on frameworks, databases, HTTP, or UI.
- `Application` depends only on `Domain` and defines ports/interfaces for external concerns.
- `Infrastructure` implements `Application` interfaces and owns EF Core, SQL Server, and external services.
- `Presentation`/`WebApi` receives requests and calls application use cases; business rules do not live here.
- Dependencies are wired in the composition root (`client` bootstrap and `Dookamp.WebApi`).

### Implementation Order

1. **Repository structure** - Created the client/server Clean Architecture folder layout.
2. **Test ownership** - Removed the unused root `tests` folder; client tests live under `client/tests` and backend tests under `server/tests`.
3. **Lesson database design** - Added [docs/database/lesson.dbml](docs/database/lesson.dbml) with Lesson, Language, content, vocabulary, media, audio, and quiz relationships.
4. **Naming decision** - Standardized localized tables on the `Language` suffix, such as `LessonLanguage` and `VocabularyLanguage`.
5. **Domain model** - Added the dependency-free `Dookamp.Domain` project and mapped the DBML entities to C# models.
6. **Domain validation** - Confirmed the Domain project builds successfully with .NET 10.
7. **Infrastructure model** - Added `Dookamp.Infrastructure`, SQLite/EF Core dependencies, and `LessonDbContext` with the DBML indexes and relationships.
8. **Reference seed data** - Added 64 Canadian and United States locations, 12 grades, 6 Lesson/Location/Grade mappings, 22 languages, 4 subjects, 7 question types, 13 hierarchical topics, 2 lessons, 32 English lesson contents, 96 Korean/Spanish/Chinese language rows, 38 English vocabulary entries, 27 vocabulary language rows, 11 lesson-content vocabulary mappings, 11 English quiz questions, additional quiz question language rows, 28 English quiz options, and 84 Korean/Spanish/Chinese option language rows to EF Core seed data.
9. **Database and Web API foundation** - Added the .NET 10 Web API, SQLite connection, `LessonDbContext` DI registration, and design-time DbContext factory.
10. **Database initialization** - Created and applied the `InitialCreate` EF Core migration to SQLite.
11. **Application and API queries** - Added Lesson and Location query use cases, EF query adapters, and their Web API endpoints.
12. **Application tests** - Added query-port tests for Lesson and Location use cases; all 3 tests pass.
13. **Vocabulary API** - Added the multilingual Lesson Vocabulary query use case and `GET /api/lessons/{lessonId}/vocabulary?languageId=1` endpoint.
14. **Quiz API** - Added the multilingual Quiz query use case and `GET /api/lessons/{lessonId}/quiz?languageId=1` endpoint.
15. **API request tests** - Added `server/tests/Dookamp.WebApi.Tests/api.http` covering health, Location, Lesson, Vocabulary, and Quiz endpoints.
16. **Quality cleanup** - Scoped EF Core nullable-constructor warnings; remaining warnings are NuGet security advisories for transitive packages.
17. **Next: quality cleanup** - Automate API integration tests and replace affected packages when fixed versions are available.

> The backend targets .NET 10 and EF Core 10. The SQLite provider currently reports a transitive `SQLitePCLRaw.lib.e_sqlite3 2.1.11` high-severity advisory; review the provider version before production use.

> `LessonLocationGrade` seed rows reference `LessonId` 1, 2, and 3. Before applying the migration, those Lesson rows must also be seeded.
>
> The supplied Language list had duplicate ID `6` and skipped ID `20`; seed IDs were normalized to unique values `1` through `22`.
>
> The supplied translated content IDs `1~96` overlap the English content IDs `1~32`; translated row IDs were normalized to `33~128` while `(LessonContentId, LanguageId)` remains unchanged.
>
> The supplied QuizQuestionLanguage data conflicted with the existing Question 2. It was preserved, and `What tool measures temperature?` was added as new Question 11 with SingleChoice type.

## Status

🚧 In development

DOOKAMP is currently in the product and system design phase.
