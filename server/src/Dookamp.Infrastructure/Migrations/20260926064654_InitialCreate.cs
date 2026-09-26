using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dookamp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MediaType = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    AltText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vocabulary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vocabulary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ParentTopicId = table.Column<int>(type: "INTEGER", nullable: true),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Topics_Topics_ParentTopicId",
                        column: x => x.ParentTopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyAudio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VocabularyId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    AudioUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyAudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyAudio_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyAudio_Vocabulary_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabulary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VocabularyId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Word = table.Column<string>(type: "TEXT", nullable: false),
                    Definition = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VocabularyLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyLanguages_Vocabulary_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabulary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VocabularyMedia",
                columns: table => new
                {
                    VocabularyId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VocabularyMedia", x => new { x.VocabularyId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_VocabularyMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VocabularyMedia_Vocabulary_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabulary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TopicId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonContents_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonLanguages_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonLocationGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLocationGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonLocationGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonLocationGrades_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonLocationGrades_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestions_QuestionTypes_QuestionTypeId",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonContentAudio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    AudioUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContentAudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonContentAudio_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonContentAudio_LessonContents_LessonContentId",
                        column: x => x.LessonContentId,
                        principalTable: "LessonContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonContentLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContentLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonContentLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonContentLanguages_LessonContents_LessonContentId",
                        column: x => x.LessonContentId,
                        principalTable: "LessonContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonContentMedia",
                columns: table => new
                {
                    LessonContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContentMedia", x => new { x.LessonContentId, x.MediaId });
                    table.ForeignKey(
                        name: "FK_LessonContentMedia_LessonContents_LessonContentId",
                        column: x => x.LessonContentId,
                        principalTable: "LessonContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonContentMedia_Media_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonContentVocabulary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonContentId = table.Column<int>(type: "INTEGER", nullable: false),
                    VocabularyId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonContentVocabulary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonContentVocabulary_LessonContents_LessonContentId",
                        column: x => x.LessonContentId,
                        principalTable: "LessonContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonContentVocabulary_Vocabulary_VocabularyId",
                        column: x => x.VocabularyId,
                        principalTable: "Vocabulary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuizQuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: false),
                    SortOrder = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizOptions_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizQuestionLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuizQuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestionLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizQuestionLanguages_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizOptionLanguages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuizOptionId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizOptionLanguages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizOptionLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizOptionLanguages_QuizOptions_QuizOptionId",
                        column: x => x.QuizOptionId,
                        principalTable: "QuizOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Grade 1" },
                    { 2, "Grade 2" },
                    { 3, "Grade 3" },
                    { 4, "Grade 4" },
                    { 5, "Grade 5" },
                    { 6, "Grade 6" },
                    { 7, "Grade 7" },
                    { 8, "Grade 8" },
                    { 9, "Grade 9" },
                    { 10, "Grade 10" },
                    { 11, "Grade 11" },
                    { 12, "Grade 12" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "en", "English" },
                    { 2, "ko", "Korean" },
                    { 3, "es", "Spanish" },
                    { 4, "zh-CN", "Mandarin Chinese (Simplified)" },
                    { 5, "ar", "Arabic" },
                    { 6, "bn", "Bengali" },
                    { 7, "de", "German" },
                    { 8, "fa", "Persian" },
                    { 9, "fil", "Filipino" },
                    { 10, "fr", "French" },
                    { 11, "hi", "Hindi" },
                    { 12, "id", "Indonesian" },
                    { 13, "it", "Italian" },
                    { 14, "ja", "Japanese" },
                    { 15, "ms", "Malay" },
                    { 16, "pt", "Portuguese" },
                    { 17, "ru", "Russian" },
                    { 18, "th", "Thai" },
                    { 19, "tr", "Turkish" },
                    { 20, "vi", "Vietnamese" },
                    { 21, "zh-TW", "Mandarin Chinese (Taiwan)" },
                    { 22, "yue-HK", "Cantonese (Hong Kong)" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Code", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "AB", "Canada", "Alberta" },
                    { 2, "BC", "Canada", "British Columbia" },
                    { 3, "MB", "Canada", "Manitoba" },
                    { 4, "NB", "Canada", "New Brunswick" },
                    { 5, "NL", "Canada", "Newfoundland and Labrador" },
                    { 6, "NS", "Canada", "Nova Scotia" },
                    { 7, "ON", "Canada", "Ontario" },
                    { 8, "PE", "Canada", "Prince Edward Island" },
                    { 9, "QC", "Canada", "Quebec" },
                    { 10, "SK", "Canada", "Saskatchewan" },
                    { 11, "NT", "Canada", "Northwest Territories" },
                    { 12, "NU", "Canada", "Nunavut" },
                    { 13, "YT", "Canada", "Yukon" },
                    { 14, "AL", "United States", "Alabama" },
                    { 15, "AK", "United States", "Alaska" },
                    { 16, "AZ", "United States", "Arizona" },
                    { 17, "AR", "United States", "Arkansas" },
                    { 18, "CA", "United States", "California" },
                    { 19, "CO", "United States", "Colorado" },
                    { 20, "CT", "United States", "Connecticut" },
                    { 21, "DE", "United States", "Delaware" },
                    { 22, "FL", "United States", "Florida" },
                    { 23, "GA", "United States", "Georgia" },
                    { 24, "HI", "United States", "Hawaii" },
                    { 25, "ID", "United States", "Idaho" },
                    { 26, "IL", "United States", "Illinois" },
                    { 27, "IN", "United States", "Indiana" },
                    { 28, "IA", "United States", "Iowa" },
                    { 29, "KS", "United States", "Kansas" },
                    { 30, "KY", "United States", "Kentucky" },
                    { 31, "LA", "United States", "Louisiana" },
                    { 32, "ME", "United States", "Maine" },
                    { 33, "MD", "United States", "Maryland" },
                    { 34, "MA", "United States", "Massachusetts" },
                    { 35, "MI", "United States", "Michigan" },
                    { 36, "MN", "United States", "Minnesota" },
                    { 37, "MS", "United States", "Mississippi" },
                    { 38, "MO", "United States", "Missouri" },
                    { 39, "MT", "United States", "Montana" },
                    { 40, "NE", "United States", "Nebraska" },
                    { 41, "NV", "United States", "Nevada" },
                    { 42, "NH", "United States", "New Hampshire" },
                    { 43, "NJ", "United States", "New Jersey" },
                    { 44, "NM", "United States", "New Mexico" },
                    { 45, "NY", "United States", "New York" },
                    { 46, "NC", "United States", "North Carolina" },
                    { 47, "ND", "United States", "North Dakota" },
                    { 48, "OH", "United States", "Ohio" },
                    { 49, "OK", "United States", "Oklahoma" },
                    { 50, "OR", "United States", "Oregon" },
                    { 51, "PA", "United States", "Pennsylvania" },
                    { 52, "RI", "United States", "Rhode Island" },
                    { 53, "SC", "United States", "South Carolina" },
                    { 54, "SD", "United States", "South Dakota" },
                    { 55, "TN", "United States", "Tennessee" },
                    { 56, "TX", "United States", "Texas" },
                    { 57, "UT", "United States", "Utah" },
                    { 58, "VT", "United States", "Vermont" },
                    { 59, "VA", "United States", "Virginia" },
                    { 60, "WA", "United States", "Washington" },
                    { 61, "WV", "United States", "West Virginia" },
                    { 62, "WI", "United States", "Wisconsin" },
                    { 63, "WY", "United States", "Wyoming" },
                    { 64, "DC", "United States", "District of Columbia" }
                });

            migrationBuilder.InsertData(
                table: "QuestionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SingleChoice" },
                    { 2, "MultipleChoice" },
                    { 3, "TrueFalse" },
                    { 4, "FillBlank" },
                    { 5, "Matching" },
                    { 6, "DragDrop" },
                    { 7, "Ordering" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Science" },
                    { 2, "Social Studies" },
                    { 3, "Mathematics" },
                    { 4, "English Language Arts" }
                });

            migrationBuilder.InsertData(
                table: "Vocabulary",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    8,
                    9,
                    10,
                    11,
                    12,
                    13,
                    14,
                    15,
                    16,
                    17,
                    18,
                    19,
                    20,
                    21,
                    22,
                    23,
                    24,
                    25,
                    26,
                    27,
                    28,
                    29,
                    30,
                    31,
                    32,
                    33,
                    34,
                    35,
                    36,
                    37,
                    38
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Name", "ParentTopicId", "SubjectId" },
                values: new object[,]
                {
                    { 1, "The study of living things and life processes", "Biology", null, 1 },
                    { 8, "Weather conditions and long-term climate patterns", "Weather & Climate", null, 1 },
                    { 12, "The properties and changes of matter", "Matter", null, 1 },
                    { 13, "Different forms of energy and how energy changes or moves", "Energy", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "VocabularyLanguages",
                columns: new[] { "Id", "Definition", "LanguageId", "VocabularyId", "Word" },
                values: new object[,]
                {
                    { 1, "What the air and sky are like at a particular time and place.", 1, 1, "Weather" },
                    { 2, "How hot or cold something is.", 1, 2, "Temperature" },
                    { 3, "Water that falls from the sky, such as rain, snow, sleet, or hail.", 1, 3, "Precipitation" },
                    { 4, "Water that falls from clouds as drops.", 1, 4, "Rain" },
                    { 5, "Frozen water that falls from clouds as soft white flakes.", 1, 5, "Snow" },
                    { 6, "Small pieces of ice that fall from the sky.", 1, 6, "Sleet" },
                    { 7, "Balls or pieces of ice that fall from clouds.", 1, 7, "Hail" },
                    { 8, "Moving air.", 1, 8, "Wind" },
                    { 9, "An instrument used to measure wind speed.", 1, 9, "Anemometer" },
                    { 10, "The amount of water vapor in the air.", 1, 10, "Humidity" },
                    { 11, "An instrument used to measure humidity.", 1, 11, "Hygrometer" },
                    { 12, "How many clouds are in the sky.", 1, 12, "Cloudiness" },
                    { 13, "A group of tiny water droplets or ice crystals in the sky.", 1, 13, "Cloud" },
                    { 14, "The force caused by the weight of air pressing down on an area.", 1, 14, "Atmospheric Pressure" },
                    { 15, "Light from the Sun reaching Earth.", 1, 15, "Sunshine" },
                    { 16, "Light and energy that come from the Sun.", 1, 16, "Sunlight" },
                    { 17, "An instrument used to measure the amount of sunshine.", 1, 17, "Sunshine Recorder" },
                    { 18, "A prediction of what the weather will be like.", 1, 18, "Forecast" },
                    { 19, "The system that moves blood around the body.", 1, 19, "Circulatory System" },
                    { 20, "A fluid that carries oxygen and nutrients through the body.", 1, 20, "Blood" },
                    { 21, "A substance that the body needs to grow and stay healthy.", 1, 21, "Nutrient" },
                    { 22, "The smallest basic unit that makes up a living thing.", 1, 22, "Cell" },
                    { 23, "A tube that carries blood through the body.", 1, 23, "Blood Vessel" },
                    { 24, "A muscular organ that pumps blood through the body.", 1, 24, "Heart" },
                    { 25, "A blood vessel that carries blood away from the heart.", 1, 25, "Artery" },
                    { 26, "A blood vessel that carries blood back to the heart.", 1, 26, "Vein" },
                    { 27, "A tiny blood vessel that connects arteries and veins.", 1, 27, "Capillary" },
                    { 28, "A gas that cells need to survive.", 1, 28, "Oxygen" },
                    { 29, "Blood that contains oxygen.", 1, 29, "Oxygenated Blood" },
                    { 30, "Blood that has given up much of its oxygen.", 1, 30, "Oxygen-depleted Blood" },
                    { 31, "An organ where oxygen enters the blood and carbon dioxide leaves it.", 1, 31, "Lung" },
                    { 32, "A device or action that moves a fluid from one place to another.", 1, 32, "Pump" },
                    { 33, "An upper chamber of the heart where blood enters.", 1, 33, "Atrium" },
                    { 34, "A lower chamber of the heart that pumps blood out.", 1, 34, "Ventricle" },
                    { 35, "The main artery that carries blood away from the heart.", 1, 35, "Aorta" },
                    { 36, "A heart valve between the right atrium and right ventricle.", 1, 36, "Tricuspid Valve" },
                    { 37, "A blood vessel that carries oxygen-rich blood from the lungs to the heart.", 1, 37, "Pulmonary Vein" },
                    { 38, "A blood vessel that carries blood from the heart to the lungs.", 1, 38, "Pulmonary Artery" },
                    { 39, "특정 시간과 장소에서의 공기와 하늘의 상태", 2, 1, "날씨" },
                    { 40, "Cómo están el aire y el cielo en un momento y lugar determinados.", 3, 1, "Tiempo" },
                    { 41, "某个时间和地点的空气和天空状况。", 4, 1, "天气" },
                    { 42, "어떤 것이 얼마나 덥거나 추운지를 나타내는 것", 2, 2, "온도" },
                    { 43, "Qué tan caliente o frío está algo.", 3, 2, "Temperatura" },
                    { 44, "表示某物有多热或多冷。", 4, 2, "温度" },
                    { 45, "하늘에서 떨어지는 물", 2, 3, "강수" },
                    { 46, "Agua que cae del cielo.", 3, 3, "Precipitación" },
                    { 47, "从天空中落下的水。", 4, 3, "降水" },
                    { 48, "구름에서 물방울 형태로 떨어지는 물", 2, 4, "비" },
                    { 49, "Agua que cae de las nubes en forma de gotas.", 3, 4, "Lluvia" },
                    { 50, "以水滴形式从云中落下的水。", 4, 4, "雨" },
                    { 51, "구름에서 내리는 얼어붙은 물의 결정", 2, 5, "눈" },
                    { 52, "Agua congelada que cae de las nubes en forma de copos.", 3, 5, "Nieve" },
                    { 53, "以雪花形式从云中落下的冰冻水。", 4, 5, "雪" },
                    { 54, "비와 얼음 알갱이가 섞여 내리는 강수", 2, 6, "진눈깨비" },
                    { 55, "Precipitación que cae como una mezcla de lluvia y hielo.", 3, 6, "Aguanieve" },
                    { 56, "雨和冰粒混合落下的降水。", 4, 6, "雨夹雪" },
                    { 57, "구름에서 떨어지는 얼음 덩어리", 2, 7, "우박" },
                    { 58, "Bolas o trozos de hielo que caen de las nubes.", 3, 7, "Granizo" },
                    { 59, "从云中落下的冰块或冰粒。", 4, 7, "冰雹" },
                    { 60, "움직이는 공기", 2, 8, "바람" },
                    { 61, "Aire en movimiento.", 3, 8, "Viento" },
                    { 62, "流动的空气。", 4, 8, "风" },
                    { 63, "바람의 속도를 측정하는 도구", 2, 9, "풍속계" },
                    { 64, "Instrumento que se usa para medir la velocidad del viento.", 3, 9, "Anemómetro" },
                    { 65, "用来测量风速的仪器。", 4, 9, "风速计" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Name", "ParentTopicId", "SubjectId" },
                values: new object[,]
                {
                    { 2, "Systems that work together to support the human body", "Body Systems", 1, 1 },
                    { 9, "Conditions of the atmosphere at a particular time and place", "Weather", 8, 1 },
                    { 10, "Long-term patterns of weather in a region", "Climate", 8, 1 },
                    { 11, "Temperature, precipitation, wind, humidity, clouds, air pressure, and sunshine", "Atmospheric Conditions", 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "IsPublished", "TopicId", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, 9, new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Name", "ParentTopicId", "SubjectId" },
                values: new object[,]
                {
                    { 3, "The system that moves blood, oxygen, and nutrients through the body", "Circulatory System", 2, 1 },
                    { 4, "Major organs and their functions in the human body", "Organs", 2, 1 },
                    { 5, "The system that controls and coordinates body functions", "Nervous System", 2, 1 },
                    { 6, "The system responsible for taking in oxygen and removing carbon dioxide", "Respiratory System", 2, 1 },
                    { 7, "The system that breaks down food and absorbs nutrients", "Digestive System", 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "LessonContents",
                columns: new[] { "Id", "LessonId", "SortOrder" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 1, 7 },
                    { 8, 1, 8 },
                    { 9, 1, 9 },
                    { 10, 1, 10 },
                    { 11, 1, 11 },
                    { 12, 1, 12 },
                    { 13, 1, 13 },
                    { 14, 1, 14 },
                    { 15, 1, 15 },
                    { 16, 1, 16 },
                    { 17, 1, 17 },
                    { 18, 1, 18 }
                });

            migrationBuilder.InsertData(
                table: "LessonLanguages",
                columns: new[] { "Id", "Description", "LanguageId", "LessonId", "Name" },
                values: new object[] { 1, "An introduction to weather and the factors that make up weather", 1, 1, "Weather" });

            migrationBuilder.InsertData(
                table: "LessonLocationGrades",
                columns: new[] { "Id", "GradeId", "LessonId", "LocationId" },
                values: new object[,]
                {
                    { 1, 5, 1, 1 },
                    { 2, 6, 1, 2 },
                    { 3, 5, 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "CreatedAt", "IsPublished", "TopicId", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, 3, new DateTime(2026, 9, 26, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "LessonId", "QuestionTypeId", "SortOrder" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 3, 2 },
                    { 3, 1, 1, 3 },
                    { 4, 1, 2, 4 },
                    { 5, 1, 1, 5 },
                    { 6, 1, 3, 6 },
                    { 7, 1, 1, 7 },
                    { 8, 1, 1, 8 },
                    { 9, 1, 3, 9 },
                    { 10, 1, 1, 10 },
                    { 11, 1, 1, 11 }
                });

            migrationBuilder.InsertData(
                table: "LessonContentLanguages",
                columns: new[] { "Id", "LanguageId", "LessonContentId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 1, "Weather is what we feel when we go outside." },
                    { 2, 1, 2, "It includes things like temperature, precipitation, wind, humidity, cloudiness, atmospheric pressure, and sunshine." },
                    { 3, 1, 3, "Temperature is how hot or cold it is." },
                    { 4, 1, 4, "We use thermometers to measure it." },
                    { 5, 1, 5, "Precipitation is water that falls from the sky." },
                    { 6, 1, 6, "This includes rain, snow, sleet, and hail." },
                    { 7, 1, 7, "Wind is moving air." },
                    { 8, 1, 8, "We measure wind speed with an instrument called an anemometer." },
                    { 9, 1, 9, "Humidity tells us how much water is in the air." },
                    { 10, 1, 10, "A hygrometer is used to measure it." },
                    { 11, 1, 11, "Cloudiness tells us how many clouds are in the sky." },
                    { 12, 1, 12, "Atmospheric pressure is how heavy the air is." },
                    { 13, 1, 13, "Low pressure can mean bad weather, and high pressure can mean good weather." },
                    { 14, 1, 14, "Sunshine is how much sunlight is reaching us." },
                    { 15, 1, 15, "It can change temperature and is measured with a sunshine recorder." },
                    { 16, 1, 16, "All these things work together to make our weather." },
                    { 17, 1, 17, "Weather can change quickly." },
                    { 18, 1, 18, "It is good to check the forecast before planning your day." },
                    { 33, 2, 1, "날씨는 우리가 밖에 나갔을 때 느끼는 것입니다." },
                    { 34, 3, 1, "El tiempo es lo que sentimos cuando salimos." },
                    { 35, 4, 1, "天气是我们外出时感受到的情况。" },
                    { 36, 2, 2, "날씨에는 온도, 강수량, 바람, 습도, 구름의 양, 대기압, 일조량 등이 포함됩니다." },
                    { 37, 3, 2, "Incluye la temperatura, la precipitación, el viento, la humedad, la nubosidad, la presión atmosférica y la luz solar." },
                    { 38, 4, 2, "天气包括温度、降水、风、湿度、云量、大气压和日照等。" },
                    { 39, 2, 3, "온도는 얼마나 덥거나 추운지를 나타냅니다." },
                    { 40, 3, 3, "La temperatura indica qué tan caliente o frío está." },
                    { 41, 4, 3, "温度表示天气有多热或多冷。" },
                    { 42, 2, 4, "온도를 측정할 때는 온도계를 사용합니다." },
                    { 43, 3, 4, "Usamos termómetros para medirla." },
                    { 44, 4, 4, "我们用温度计来测量温度。" },
                    { 45, 2, 5, "강수는 하늘에서 떨어지는 물입니다." },
                    { 46, 3, 5, "La precipitación es el agua que cae del cielo." },
                    { 47, 4, 5, "降水是从天空中落下的水。" },
                    { 48, 2, 6, "여기에는 비, 눈, 진눈깨비, 우박이 포함됩니다." },
                    { 49, 3, 6, "Incluye lluvia, nieve, aguanieve y granizo." },
                    { 50, 4, 6, "降水包括雨、雪、雨夹雪和冰雹。" },
                    { 51, 2, 7, "바람은 움직이는 공기입니다." },
                    { 52, 3, 7, "El viento es aire en movimiento." },
                    { 53, 4, 7, "风是流动的空气。" },
                    { 54, 2, 8, "풍속은 풍속계라는 도구로 측정합니다." },
                    { 55, 3, 8, "Medimos la velocidad del viento con un instrumento llamado anemómetro." },
                    { 56, 4, 8, "我们用一种叫风速计的仪器来测量风速。" },
                    { 57, 2, 9, "습도는 공기 중에 물이 얼마나 많이 들어 있는지를 나타냅니다." },
                    { 58, 3, 9, "La humedad indica cuánta agua hay en el aire." },
                    { 59, 4, 9, "湿度表示空气中含有多少水分。" },
                    { 60, 2, 10, "습도는 습도계로 측정합니다." },
                    { 61, 3, 10, "Usamos un higrómetro para medirla." },
                    { 62, 4, 10, "我们用湿度计来测量湿度。" },
                    { 63, 2, 11, "운량은 하늘에 구름이 얼마나 많이 있는지를 나타냅니다." },
                    { 64, 3, 11, "La nubosidad indica cuántas nubes hay en el cielo." },
                    { 65, 4, 11, "云量表示天空中有多少云。" },
                    { 66, 2, 12, "대기압은 공기가 누르는 힘입니다." },
                    { 67, 3, 12, "La presión atmosférica es la fuerza que ejerce el aire." },
                    { 68, 4, 12, "大气压是空气产生的压力。" },
                    { 69, 2, 13, "저기압은 나쁜 날씨를 가져올 수 있고, 고기압은 좋은 날씨를 가져올 수 있습니다." },
                    { 70, 3, 13, "La baja presión puede traer mal tiempo, y la alta presión puede traer buen tiempo." },
                    { 71, 4, 13, "低气压可能带来坏天气，高气压可能带来好天气。" },
                    { 72, 2, 14, "일조량은 우리에게 도달하는 햇빛의 양입니다." },
                    { 73, 3, 14, "La luz solar es la cantidad de luz del sol que llega hasta nosotros." },
                    { 74, 4, 14, "日照是到达我们这里的阳光量。" },
                    { 75, 2, 15, "햇빛은 온도를 변화시킬 수 있으며 일조계로 측정합니다." },
                    { 76, 3, 15, "La luz solar puede cambiar la temperatura y se mide con un registrador de horas de sol." },
                    { 77, 4, 15, "阳光可以改变温度，并可以用日照记录仪进行测量。" },
                    { 78, 2, 16, "이러한 모든 요소가 함께 작용하여 날씨를 만듭니다." },
                    { 79, 3, 16, "Todos estos elementos trabajan juntos para formar nuestro tiempo." },
                    { 80, 4, 16, "所有这些因素共同形成了我们的天气。" },
                    { 81, 2, 17, "날씨는 빠르게 변할 수 있습니다." },
                    { 82, 3, 17, "El tiempo puede cambiar rápidamente." },
                    { 83, 4, 17, "天气可能会迅速变化。" },
                    { 84, 2, 18, "하루 계획을 세우기 전에 일기 예보를 확인하는 것이 좋습니다." },
                    { 85, 3, 18, "Es bueno consultar el pronóstico del tiempo antes de planificar el día." },
                    { 86, 4, 18, "在安排一天的计划之前，最好查看天气预报。" }
                });

            migrationBuilder.InsertData(
                table: "LessonContentVocabulary",
                columns: new[] { "Id", "LessonContentId", "VocabularyId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 2, 3 },
                    { 5, 5, 3 },
                    { 6, 6, 4 },
                    { 7, 6, 5 },
                    { 8, 6, 6 },
                    { 9, 6, 7 },
                    { 10, 7, 8 },
                    { 11, 8, 9 }
                });

            migrationBuilder.InsertData(
                table: "LessonContents",
                columns: new[] { "Id", "LessonId", "SortOrder" },
                values: new object[,]
                {
                    { 19, 2, 1 },
                    { 20, 2, 2 },
                    { 21, 2, 3 },
                    { 22, 2, 4 },
                    { 23, 2, 5 },
                    { 24, 2, 6 },
                    { 25, 2, 7 },
                    { 26, 2, 8 },
                    { 27, 2, 9 },
                    { 28, 2, 10 },
                    { 29, 2, 11 },
                    { 30, 2, 12 },
                    { 31, 2, 13 },
                    { 32, 2, 14 }
                });

            migrationBuilder.InsertData(
                table: "LessonLanguages",
                columns: new[] { "Id", "Description", "LanguageId", "LessonId", "Name" },
                values: new object[] { 2, "An introduction to the circulatory system, its organs, and blood flow", 1, 2, "Circulatory System" });

            migrationBuilder.InsertData(
                table: "LessonLocationGrades",
                columns: new[] { "Id", "GradeId", "LessonId", "LocationId" },
                values: new object[,]
                {
                    { 4, 5, 2, 1 },
                    { 5, 6, 2, 2 },
                    { 6, 5, 2, 7 }
                });

            migrationBuilder.InsertData(
                table: "QuizOptions",
                columns: new[] { "Id", "IsCorrect", "QuizQuestionId", "SortOrder" },
                values: new object[,]
                {
                    { 1, true, 1, 1 },
                    { 2, false, 1, 2 },
                    { 3, false, 1, 3 },
                    { 4, true, 2, 1 },
                    { 5, false, 2, 2 },
                    { 6, true, 3, 1 },
                    { 7, false, 3, 2 },
                    { 8, false, 3, 3 },
                    { 9, true, 4, 1 },
                    { 10, true, 4, 2 },
                    { 11, true, 4, 3 },
                    { 12, true, 4, 4 },
                    { 13, true, 5, 1 },
                    { 14, false, 5, 2 },
                    { 15, false, 5, 3 },
                    { 16, true, 6, 1 },
                    { 17, false, 6, 2 },
                    { 18, true, 7, 1 },
                    { 19, false, 7, 2 },
                    { 20, false, 7, 3 },
                    { 21, true, 8, 1 },
                    { 22, false, 8, 2 },
                    { 23, false, 8, 3 },
                    { 24, true, 9, 1 },
                    { 25, false, 9, 2 },
                    { 26, true, 10, 1 },
                    { 27, false, 10, 2 },
                    { 28, false, 10, 3 }
                });

            migrationBuilder.InsertData(
                table: "QuizQuestionLanguages",
                columns: new[] { "Id", "LanguageId", "QuestionText", "QuizQuestionId" },
                values: new object[,]
                {
                    { 1, 1, "What is weather?", 1 },
                    { 2, 1, "Temperature tells us how hot or cold it is.", 2 },
                    { 3, 1, "What measures temperature?", 3 },
                    { 4, 1, "Which are types of precipitation?", 4 },
                    { 5, 1, "What is wind?", 5 },
                    { 6, 1, "A hygrometer measures humidity.", 6 },
                    { 7, 1, "What does cloudiness tell us?", 7 },
                    { 8, 1, "What is atmospheric pressure?", 8 },
                    { 9, 1, "Weather can change quickly.", 9 },
                    { 10, 1, "What should you check before planning your day?", 10 },
                    { 11, 2, "날씨란 무엇인가?", 1 },
                    { 12, 3, "¿Qué es el tiempo?", 1 },
                    { 13, 1, "What tool measures temperature?", 11 },
                    { 14, 2, "기온을 측정하는 도구는 무엇인가?", 11 },
                    { 15, 3, "¿Qué instrumento mide la temperatura?", 11 }
                });

            migrationBuilder.InsertData(
                table: "LessonContentLanguages",
                columns: new[] { "Id", "LanguageId", "LessonContentId", "Text" },
                values: new object[,]
                {
                    { 19, 1, 19, "The circulatory system is the movement of blood through the body." },
                    { 20, 1, 20, "Blood carries nutrients to the cells in our body." },
                    { 21, 1, 21, "The main organs in the circulatory system are blood vessels and the heart." },
                    { 22, 1, 22, "There are three types of blood vessels: arteries, veins, and capillaries." },
                    { 23, 1, 23, "Arteries carry oxygenated blood away from the heart to the rest of the body." },
                    { 24, 1, 24, "Veins carry oxygen-depleted blood back to the heart." },
                    { 25, 1, 25, "Capillaries are tiny blood vessels that connect arteries to veins." },
                    { 26, 1, 26, "The cells in our body need oxygen to survive." },
                    { 27, 1, 27, "The heart pumps blood through the lungs, where oxygen is added to the blood." },
                    { 28, 1, 28, "Oxygen-rich blood travels away from the heart through arteries." },
                    { 29, 1, 29, "Used blood travels back to the heart through veins." },
                    { 30, 1, 30, "The heart is a muscle that acts like two pumps." },
                    { 31, 1, 31, "The right side pumps blood to the lungs to get oxygen." },
                    { 32, 1, 32, "The left side pumps oxygen-rich blood to the body." },
                    { 87, 2, 19, "순환계는 몸 전체를 통해 혈액이 이동하는 시스템입니다." },
                    { 88, 3, 19, "El sistema circulatorio es el movimiento de la sangre por todo el cuerpo." },
                    { 89, 4, 19, "循环系统是血液在全身流动的系统。" },
                    { 90, 2, 20, "혈액은 우리 몸의 세포에 영양분을 운반합니다." },
                    { 91, 3, 20, "La sangre transporta nutrientes a las células de nuestro cuerpo." },
                    { 92, 4, 20, "血液将营养物质输送到我们身体的细胞。" },
                    { 93, 2, 21, "순환계의 주요 기관은 혈관과 심장입니다." },
                    { 94, 3, 21, "Los principales órganos del sistema circulatorio son los vasos sanguíneos y el corazón." },
                    { 95, 4, 21, "循环系统的主要器官是血管和心脏。" },
                    { 96, 2, 22, "혈관에는 동맥, 정맥, 모세혈관의 세 가지 종류가 있습니다." },
                    { 97, 3, 22, "Hay tres tipos de vasos sanguíneos: arterias, venas y capilares." },
                    { 98, 4, 22, "血管有三种：动脉、静脉和毛细血管。" },
                    { 99, 2, 23, "동맥은 산소가 들어 있는 혈액을 심장에서 몸의 다른 부분으로 운반합니다." },
                    { 100, 3, 23, "Las arterias llevan sangre oxigenada desde el corazón al resto del cuerpo." },
                    { 101, 4, 23, "动脉将含氧血液从心脏输送到身体的其他部位。" },
                    { 102, 2, 24, "정맥은 산소가 부족해진 혈액을 심장으로 다시 운반합니다." },
                    { 103, 3, 24, "Las venas llevan la sangre con poco oxígeno de vuelta al corazón." },
                    { 104, 4, 24, "静脉将缺氧的血液输送回心脏。" },
                    { 105, 2, 25, "모세혈관은 동맥과 정맥을 연결하는 아주 작은 혈관입니다." },
                    { 106, 3, 25, "Los capilares son vasos sanguíneos muy pequeños que conectan las arterias con las venas." },
                    { 107, 4, 25, "毛细血管是连接动脉和静脉的非常细小的血管。" },
                    { 108, 2, 26, "우리 몸의 세포는 살아가기 위해 산소가 필요합니다." },
                    { 109, 3, 26, "Las células de nuestro cuerpo necesitan oxígeno para sobrevivir." },
                    { 110, 4, 26, "我们身体的细胞需要氧气才能生存。" },
                    { 111, 2, 27, "심장은 혈액을 폐로 보내고, 폐에서 혈액에 산소가 들어갑니다." },
                    { 112, 3, 27, "El corazón bombea sangre a los pulmones, donde la sangre recibe oxígeno." },
                    { 113, 4, 27, "心脏将血液泵入肺部，血液在那里获得氧气。" },
                    { 114, 2, 28, "산소가 풍부한 혈액은 동맥을 통해 심장에서 몸으로 이동합니다." },
                    { 115, 3, 28, "La sangre rica en oxígeno viaja desde el corazón al cuerpo a través de las arterias." },
                    { 116, 4, 28, "富含氧气的血液通过动脉从心脏流向身体。" },
                    { 117, 2, 29, "사용된 혈액은 정맥을 통해 심장으로 돌아옵니다." },
                    { 118, 3, 29, "La sangre que ha sido utilizada regresa al corazón a través de las venas." },
                    { 119, 4, 29, "使用过的血液通过静脉返回心脏。" },
                    { 120, 2, 30, "심장은 두 개의 펌프처럼 작동하는 근육입니다." },
                    { 121, 3, 30, "El corazón es un músculo que funciona como dos bombas." },
                    { 122, 4, 30, "心脏是一块像两个泵一样工作的肌肉。" },
                    { 123, 2, 31, "심장의 오른쪽은 혈액을 폐로 보내 산소를 얻도록 합니다." },
                    { 124, 3, 31, "El lado derecho bombea sangre a los pulmones para obtener oxígeno." },
                    { 125, 4, 31, "心脏的右侧将血液泵入肺部以获得氧气。" },
                    { 126, 2, 32, "심장의 왼쪽은 산소가 풍부한 혈액을 몸 전체로 보냅니다." },
                    { 127, 3, 32, "El lado izquierdo bombea sangre rica en oxígeno al cuerpo." },
                    { 128, 4, 32, "心脏的左侧将富含氧气的血液泵送到全身。" }
                });

            migrationBuilder.InsertData(
                table: "QuizOptionLanguages",
                columns: new[] { "Id", "LanguageId", "QuizOptionId", "Text" },
                values: new object[,]
                {
                    { 1, 1, 1, "What the air and sky are like" },
                    { 2, 1, 2, "How much sunlight there is" },
                    { 3, 1, 3, "How fast the wind moves" },
                    { 4, 1, 4, "True" },
                    { 5, 1, 5, "False" },
                    { 6, 1, 6, "Thermometer" },
                    { 7, 1, 7, "Hygrometer" },
                    { 8, 1, 8, "Anemometer" },
                    { 9, 1, 9, "Rain" },
                    { 10, 1, 10, "Snow" },
                    { 11, 1, 11, "Sleet" },
                    { 12, 1, 12, "Hail" },
                    { 13, 1, 13, "Moving air" },
                    { 14, 1, 14, "Water vapor" },
                    { 15, 1, 15, "Cloud" },
                    { 16, 1, 16, "True" },
                    { 17, 1, 17, "False" },
                    { 18, 1, 18, "How many clouds are in sky" },
                    { 19, 1, 19, "How much rain falls" },
                    { 20, 1, 20, "How fast wind moves" },
                    { 21, 1, 21, "The weight of air pressing down" },
                    { 22, 1, 22, "The amount of sunlight" },
                    { 23, 1, 23, "The amount of water in air" },
                    { 24, 1, 24, "True" },
                    { 25, 1, 25, "False" },
                    { 26, 1, 26, "The weather forecast" },
                    { 27, 1, 27, "A thermometer" },
                    { 28, 1, 28, "A sunshine recorder" },
                    { 29, 2, 1, "공기와 하늘의 상태" },
                    { 30, 3, 1, "Cómo están el aire y el cielo" },
                    { 31, 4, 1, "空气和天空的状态" },
                    { 32, 2, 2, "햇빛의 양" },
                    { 33, 3, 2, "Cuánta luz solar hay" },
                    { 34, 4, 2, "阳光的多少" },
                    { 35, 2, 3, "바람이 얼마나 빠르게 움직이는지" },
                    { 36, 3, 3, "Qué tan rápido se mueve el viento" },
                    { 37, 4, 3, "风移动的速度" },
                    { 38, 2, 4, "참" },
                    { 39, 3, 4, "Verdadero" },
                    { 40, 4, 4, "正确" },
                    { 41, 2, 5, "거짓" },
                    { 42, 3, 5, "Falso" },
                    { 43, 4, 5, "错误" },
                    { 44, 2, 6, "온도계" },
                    { 45, 3, 6, "Termómetro" },
                    { 46, 4, 6, "温度计" },
                    { 47, 2, 7, "습도계" },
                    { 48, 3, 7, "Higrómetro" },
                    { 49, 4, 7, "湿度计" },
                    { 50, 2, 8, "풍속계" },
                    { 51, 3, 8, "Anemómetro" },
                    { 52, 4, 8, "风速计" },
                    { 53, 2, 9, "비" },
                    { 54, 3, 9, "Lluvia" },
                    { 55, 4, 9, "雨" },
                    { 56, 2, 10, "눈" },
                    { 57, 3, 10, "Nieve" },
                    { 58, 4, 10, "雪" },
                    { 59, 2, 11, "진눈깨비" },
                    { 60, 3, 11, "Aguanieve" },
                    { 61, 4, 11, "雨夹雪" },
                    { 62, 2, 12, "우박" },
                    { 63, 3, 12, "Granizo" },
                    { 64, 4, 12, "冰雹" },
                    { 65, 2, 13, "움직이는 공기" },
                    { 66, 3, 13, "Aire en movimiento" },
                    { 67, 4, 13, "流动的空气" },
                    { 68, 2, 14, "수증기" },
                    { 69, 3, 14, "Vapor de agua" },
                    { 70, 4, 14, "水蒸气" },
                    { 71, 2, 15, "구름" },
                    { 72, 3, 15, "Nube" },
                    { 73, 4, 15, "云" },
                    { 74, 2, 16, "참" },
                    { 75, 3, 16, "Verdadero" },
                    { 76, 4, 16, "正确" },
                    { 77, 2, 17, "거짓" },
                    { 78, 3, 17, "Falso" },
                    { 79, 4, 17, "错误" },
                    { 80, 2, 18, "하늘에 있는 구름의 수" },
                    { 81, 3, 18, "Cuántas nubes hay en el cielo" },
                    { 82, 4, 18, "天空中有多少云" },
                    { 83, 2, 19, "내리는 비의 양" },
                    { 84, 3, 19, "Cuánta lluvia cae" },
                    { 85, 4, 19, "降雨量" },
                    { 86, 2, 20, "바람이 얼마나 빠르게 움직이는지" },
                    { 87, 3, 20, "Qué tan rápido se mueve el viento" },
                    { 88, 4, 20, "风移动的速度" },
                    { 89, 2, 21, "공기가 누르는 무게" },
                    { 90, 3, 21, "El peso del aire que presiona hacia abajo" },
                    { 91, 4, 21, "空气向下施加的重量" },
                    { 92, 2, 22, "햇빛의 양" },
                    { 93, 3, 22, "La cantidad de luz solar" },
                    { 94, 4, 22, "阳光的多少" },
                    { 95, 2, 23, "공기 중의 물의 양" },
                    { 96, 3, 23, "La cantidad de agua en el aire" },
                    { 97, 4, 23, "空气中的水量" },
                    { 98, 2, 24, "참" },
                    { 99, 3, 24, "Verdadero" },
                    { 100, 4, 24, "正确" },
                    { 101, 2, 25, "거짓" },
                    { 102, 3, 25, "Falso" },
                    { 103, 4, 25, "错误" },
                    { 104, 2, 26, "일기 예보" },
                    { 105, 3, 26, "El pronóstico del tiempo" },
                    { 106, 4, 26, "天气预报" },
                    { 107, 2, 27, "온도계" },
                    { 108, 3, 27, "Termómetro" },
                    { 109, 4, 27, "温度计" },
                    { 110, 2, 28, "일조계" },
                    { 111, 3, 28, "Registrador de horas de sol" },
                    { 112, 4, 28, "日照记录仪" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Name",
                table: "Grades",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Code",
                table: "Languages",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                table: "Languages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentAudio_LanguageId",
                table: "LessonContentAudio",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentAudio_LessonContentId_LanguageId",
                table: "LessonContentAudio",
                columns: new[] { "LessonContentId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentLanguages_LanguageId",
                table: "LessonContentLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentLanguages_LessonContentId_LanguageId",
                table: "LessonContentLanguages",
                columns: new[] { "LessonContentId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentMedia_MediaId",
                table: "LessonContentMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonContents_LessonId_SortOrder",
                table: "LessonContents",
                columns: new[] { "LessonId", "SortOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentVocabulary_LessonContentId_VocabularyId",
                table: "LessonContentVocabulary",
                columns: new[] { "LessonContentId", "VocabularyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonContentVocabulary_VocabularyId",
                table: "LessonContentVocabulary",
                column: "VocabularyId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonLanguages_LanguageId",
                table: "LessonLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonLanguages_LessonId_LanguageId",
                table: "LessonLanguages",
                columns: new[] { "LessonId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonLocationGrades_GradeId",
                table: "LessonLocationGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonLocationGrades_LessonId_LocationId_GradeId",
                table: "LessonLocationGrades",
                columns: new[] { "LessonId", "LocationId", "GradeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LessonLocationGrades_LocationId",
                table: "LessonLocationGrades",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TopicId",
                table: "Lessons",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Code",
                table: "Locations",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionTypes_Name",
                table: "QuestionTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptionLanguages_LanguageId",
                table: "QuizOptionLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptionLanguages_QuizOptionId_LanguageId",
                table: "QuizOptionLanguages",
                columns: new[] { "QuizOptionId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizOptions_QuizQuestionId_SortOrder",
                table: "QuizOptions",
                columns: new[] { "QuizQuestionId", "SortOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionLanguages_LanguageId",
                table: "QuizQuestionLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionLanguages_QuizQuestionId_LanguageId",
                table: "QuizQuestionLanguages",
                columns: new[] { "QuizQuestionId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_LessonId_SortOrder",
                table: "QuizQuestions",
                columns: new[] { "LessonId", "SortOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_QuestionTypeId",
                table: "QuizQuestions",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ParentTopicId",
                table: "Topics",
                column: "ParentTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_SubjectId_Name",
                table: "Topics",
                columns: new[] { "SubjectId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyAudio_LanguageId",
                table: "VocabularyAudio",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyAudio_VocabularyId_LanguageId",
                table: "VocabularyAudio",
                columns: new[] { "VocabularyId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyLanguages_LanguageId",
                table: "VocabularyLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyLanguages_VocabularyId_LanguageId",
                table: "VocabularyLanguages",
                columns: new[] { "VocabularyId", "LanguageId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VocabularyMedia_MediaId",
                table: "VocabularyMedia",
                column: "MediaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonContentAudio");

            migrationBuilder.DropTable(
                name: "LessonContentLanguages");

            migrationBuilder.DropTable(
                name: "LessonContentMedia");

            migrationBuilder.DropTable(
                name: "LessonContentVocabulary");

            migrationBuilder.DropTable(
                name: "LessonLanguages");

            migrationBuilder.DropTable(
                name: "LessonLocationGrades");

            migrationBuilder.DropTable(
                name: "QuizOptionLanguages");

            migrationBuilder.DropTable(
                name: "QuizQuestionLanguages");

            migrationBuilder.DropTable(
                name: "VocabularyAudio");

            migrationBuilder.DropTable(
                name: "VocabularyLanguages");

            migrationBuilder.DropTable(
                name: "VocabularyMedia");

            migrationBuilder.DropTable(
                name: "LessonContents");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "QuizOptions");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "Vocabulary");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "QuestionTypes");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
