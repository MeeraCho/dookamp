# Database Design

## 1. Overview

DOOKAMP uses a relational database to organize learning content and align topics with school curricula.

The database is designed to support:

- Multiple academic subjects and hierarchical topics.
- Reusable lessons associated with multiple topics.
- Curriculum alignment based on location and grade.
- Multilingual learning content.
- Vocabulary, concept checks, and quizzes.

**Technology Stack**

- Database: SQLite
- ORM: Entity Framework Core
- Backend: .NET 10 ASP.NET Core Web API

## 2. Learning Content

This section describes the core entities used to organize and deliver learning content.

### 2.1 Subject

  - Represents a major academic subject (ex.social study, science..).
  - A Subject can contain multiple Topics.
  - Each Topic belongs to one Subject through `Topics.SubjectId`.

### 2.2 Topic

  - Represents a learning topic within a Subject.
  - Topics support hierarchical organization through `ParentTopicId`.

    For example:

    ```text
    Science (Subject)
    |
    +-- Biology (Topic)
    |     |
    |     +-- Cell Structure
    |     +-- Human Body
    |
    +-- Earth Science (Topic)
            |
            +-- Weather
            +-- Climate
    ```

  - A Topic belongs to one Subject.
  - A Topic can have multiple child Topics.
  - A child Topic can have one parent Topic.
  - `ParentTopicId` references `Topics.Id`.
  - A Topic can be associated with multiple Lessons.

### 2.3 Lesson

Represents a reusable learning unit. This allows the same Lesson to be reused across different topics without duplicating content.

- A Lesson can be associated with multiple Topics.
- A Topic can contain multiple Lessons.
- The many-to-many relationship is managed through `LessonTopics`.
- Lessons are independent of Location and Grade.


### 2.4 Lesson Content and Learning Activities

Learning content is separated from the Lesson entity.

The main entities include:

- `LessonContents`: Language-specific lesson content.
- `Vocabularies`: Vocabulary associated with lesson content.
- `QuizQuestions`: Questions used for concept checks and lesson quizzes.
- `QuizOptions`: Answer options associated with quiz questions.

Quiz questions can be associated with either a LessonContent or a Lesson.

- LessonContent-level questions check understanding of a specific section.
- Lesson-level questions evaluate understanding of the overall lesson.

### 2.5 Multilingual Support

DOOKAMP supports multilingual learning content.

The initial MVP supports:
- English (`en`)
- Korean (`ko`)

Language information is managed through the `Languages` entity.

Language-specific content and vocabulary are managed separately from the core Lesson entity.

The database structure allows additional languages to be introduced without creating separate entities for each language.

## 3. Curriculum Alignment

DOOKAMP uses Location and Grade to determine which Topics are relevant to students in a particular educational context.

There is no separate `Curriculum` entity. Instead, curriculum alignment is managed through `TopicLocationGrades`.

### 3.1 TopicLocationGrades

`TopicLocationGrades` connects a Topic to a Location and Grade.

```text
Topics (1) -------- (N) TopicLocationGrades

Locations (1) ----- (N) TopicLocationGrades

Grades (1) -------- (N) TopicLocationGrades
```

Each record represents a specific curriculum alignment.

Example:

```text
Topic: Weather
Location: Alberta
Grade: Grade 5
```

### 3.2 Design Rules

- Location and Grade are associated with Topics, not Lessons.
- A Topic can have multiple Location and Grade combinations.
- The combination of `TopicId`, `LocationId`, and `GradeId` must be unique.
- Only Topics associated with actual learning content need curriculum alignment.
- Lessons remain reusable independently of Location and Grade.

## 4. User Management (Future)

Future database design may include entities to support user accounts and family relationships.

Potential features:
- User authentication and account management.
- Student profiles.
- Parent and family account relationships.

These entities are not part of the current database implementation.

## 5. Learning Progress (Future)

Future database design may include entities to track student learning activities and progress.

Potential features:
- Lesson completion and learning progress.
- Quiz attempts and scores.
- Quiz answer history.
- Vocabulary learning progress.

These features will be designed when learning progress tracking is implemented.