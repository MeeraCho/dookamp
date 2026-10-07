using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DooKamp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizQuestionAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizQuestionAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuizQuestionId = table.Column<int>(type: "INTEGER", nullable: false),
                    LanguageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Answer = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizQuestionAnswers_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizQuestionAnswers_QuizQuestions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "QuizQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionAnswers_LanguageId",
                table: "QuizQuestionAnswers",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestionAnswers_QuizQuestionId_LanguageId_Answer",
                table: "QuizQuestionAnswers",
                columns: new[] { "QuizQuestionId", "LanguageId", "Answer" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizQuestionAnswers");
        }
    }
}
