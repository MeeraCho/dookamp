# DooKamp MVP Scope

## 1. Purpose

The purpose of the Minimum Viable Product (MVP) is to deliver a usable learning experience that helps students and families understand foundational concepts taught in Alberta elementary schools.

The MVP will focus on Alberta Grade 5 Science, with learning content available in English and Korean.

The initial release will validate the core learning experience before expanding to additional grades, subjects, locations, and languages.

## 2. Target Users

### 2.1 Elementary Students

Students who want to learn, review, and strengthen their understanding of Grade 5 Science concepts.

### 2.2 Multilingual Children and Families

Children can study concepts and vocabulary in English and Korean. Parents who are not native English speakers can use Korean explanations to understand what their children are learning at school and support their learning at home.

### 2.3 Adult English Learners

Adults who want to build English vocabulary and understand foundational concepts commonly taught in North American elementary schools.

## 3. MVP Boundaries

| Category | Initial Scope |
|---|---|
| Location | Alberta, Canada |
| Grade | Grade 5 |
| Subject | Science |
| Learning languages | English and Korean |
| Platform | Responsive web application |
| Authentication | User registration, login, and logout |
| Learning | Lessons, vocabulary, and quizzes |
| Progress tracking | Lesson completion and quiz results |


## 4. Functional Requirements

### 4.1 Curriculum-Based Lessons

**Goal:** Help learners explore foundational Science concepts relevant to Alberta Grade 5.

Requirements:

- Display a list of available lessons.
- Allow learners to open an individual lesson.
- Organize learning content by subject and topic.
- Provide lesson content in English and Korean.
- Make published lessons available to learners.

Acceptance criteria:

- Users can retrieve a list of published lessons.
- Users can open a lesson and retrieve its associated learning content.
- Unpublished lessons are not exposed through student-facing lesson endpoints.
- Invalid lesson IDs and missing lessons return appropriate error responses.

### 4.2 Bilingual Learning Content

**Goal:** Support conceptual understanding in English and Korean.

Requirements:

- Provide English and Korean explanations for supported lessons.
- Provide vocabulary words and definitions in both languages.
- Present explanations in clear, age-appropriate language.
- Preserve the meaning of each concept rather than relying solely on literal translation.
- Allow learners to identify which language each content item uses.

Acceptance criteria:

- Supported lessons contain the intended English and Korean content.
- Vocabulary is associated with the correct lesson content and language.
- Missing language content is handled gracefully without breaking the lesson page.

### 4.3 Concept Checks and Quizzes

**Goal:** Help learners check their understanding after studying a concept or lesson.

Requirements:

- Display concept-check questions within the relevant lesson content.
- Provide lesson-level quiz questions.
- Display answer options where applicable.
- Evaluate submitted answers.
- Show feedback and the learner's quiz result.

Acceptance criteria:

- Questions and options are associated with the correct lesson or concept.
- The system evaluates answers using the configured answer data.
- The result accurately reflects the submitted answers.
- Correct-answer information is not exposed unnecessarily through student-facing API responses.

### 4.4 User Authentication

**Goal:** Allow users to access account-based learning features.

Requirements:

- Support user registration.
- Support login and logout.
- Protect account-specific operations.
- Associate learning records with the authenticated user.
- Handle invalid credentials and unauthorized requests appropriately.

Acceptance criteria:

- Users can register and sign in using the selected authentication method.
- Protected endpoints reject unauthenticated requests.
- Users cannot access another user's private learning records.
- Authentication failures return appropriate error responses.

The authentication provider and implementation approach will be selected before this feature is developed.

### 4.5 Learning Progress

**Goal:** Allow learners to track their learning activity over time.

Requirements:

- Record lesson completion.
- Save quiz results for the authenticated user.
- Retrieve the user's previous learning records.
- Preserve saved progress across sessions.

Acceptance criteria:

- Completing a lesson updates the associated user's progress.
- Submitting a quiz saves its result.
- A user can retrieve their own saved progress after signing in again.
- One user cannot read or modify another user's learning records.

## 5. Non-Functional Requirements

### Maintainability

- Keep responsibilities separated across the API, Application, Domain, and Infrastructure layers.
- Use DTOs to define API response contracts.
- Keep validation rules separate from controller logic.

### Reliability

- Return consistent error responses for validation failures and missing resources.
- Handle invalid input without exposing internal exception details.
- Add automated tests for important application behavior.

### Security

- Store credentials securely using an established authentication mechanism.
- Protect private learning records with appropriate authorization.
- Never expose passwords, authentication secrets, or correct answers unnecessarily.

### Usability

- Provide a responsive interface suitable for tablets and desktop browsers.
- Use clear, age-appropriate explanations.
- Make English and Korean content easy to identify and navigate.

## 6. Out of Scope for the Initial MVP

The following features are excluded from the initial release unless they become necessary to validate the core learning experience:

- Additional Canadian provinces and U.S. states.
- Grades other than Grade 5.
- Subjects other than Science.
- Languages other than English and Korean.
- Dedicated parent and child account linking.
- Subscription billing and paid plans.
- Advanced personalization and adaptive learning.
- Social features, leaderboards, and multiplayer learning.
- A full content-authoring administration portal.

These features may be reconsidered after the initial learning experience is validated.

## 7. Technical Architecture and Constraints

### Backend Architecture
- Use ASP.NET Core Web API with .NET 10.
- Follow Clean Architecture principles.
- Separate responsibilities into API, Application, Domain,
  and Infrastructure layers.
- Use direct Query and Handler classes for application use cases.
- Keep business rules independent of infrastructure concerns.
- Use dependency injection to manage dependencies.

### Database
- Use Entity Framework Core for data access.
- Use SQLite for the initial development environment.
- Define entities, relationships, constraints, and indexes
  based on the domain model.
- Use database migrations to manage schema changes.
- Seed the initial reference data and sample learning content.

### API Design
- Expose RESTful endpoints for lesson retrieval and learning operations.
- Use DTOs to define API request and response contracts.
- Validate incoming requests.
- Use centralized exception handling and consistent error responses.
- Avoid exposing internal entities directly through the API.

### Testing and Quality
- Use xUnit for automated tests.
- Test application handlers and validation rules.
- Add integration tests for API and database behavior.
- Run automated tests before merging or deploying changes.

### Deployment
- Configure the application for a production environment.
- Store environment-specific settings outside source code.
- Deploy the application to a cloud hosting environment.
- Verify critical API endpoints after deployment.

## 8. Implementation Milestones

### Milestone 1: Backend Foundation

- [x] Set up the Clean Architecture solution and project structure.
- [x] Design core domain entities and relationships.
- [x] Configure Entity Framework Core and SQLite.
- [x] Implement database initialization and seed data.
- [x] Implement the GetLessons API.
- [x] Implement the GetLesson API.
- [x] Add query validation and centralized exception handling.
- [ ] Complete planned application handler unit tests.
- [ ] Implement API and database integration tests.

### Milestone 2: Learning Content and Quiz APIs

- [ ] Finalize bilingual lesson content and vocabulary structures.
- [ ] Seed quiz questions, options, and answer data.
- [ ] Implement answer submission and quiz evaluation.
- [ ] Define quiz result response contracts.
- [ ] Add automated tests for quiz operations.

### Milestone 3: Frontend Learning Experience
  
- [ ] Set up the React and TypeScript frontend.
- [ ] Implement lesson list and lesson detail pages. 
- [ ] Display English and Korean learning content. 
- [ ] Implement interactive quizzes and answer feedback.
- [ ] Build a responsive interface for desktop, tablet, and mobile.
- [ ] Integrate the frontend with the backend APIs.

### Milestone 4: Authentication and Learning Progress

- [ ] Implement user registration, login and logout.
- [ ] Protect user-specific operations with authentication and authorization.
- [ ] Store lesson completion records.
- [ ] Save and retrieve quiz results. 
- [ ] Ensure learning records are isolated by user.
- [ ] Add automated tests for authentication and progress tracking.

### Milestone 5: Quality Assurance and Release

- [ ] Complete unit and integration test coverage for critical functionality.
- [ ] Verify the complete learning flow from lesson selection to quiz results.
- [ ] Configure GitHub Actions for continuous integration.
- [ ] Review production configuration and security requirements.
- [ ] Deploy the application to Azure.
- [ ] Verify critical API endpoints and user workflows in the deployed environment.

## 8. MVP Completion Criteria

The MVP is considered ready for initial release when:

- Learners can access the published Grade 5 Science lessons.
- Learning content and vocabulary are available in English and Korean.
- Learners can answer quizzes and receive accurate results.
- Lesson completion and quiz results are saved and associated with the correct user.
- Users can register, sign in, and access their own saved learning progress.
- Important application workflows are covered by automated tests.
- The application is deployed to Azure and the core learning workflow has been verified
