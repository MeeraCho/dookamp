using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DooKamp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeQuizQuestionRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_LessonContents_LessonContentId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Lessons_LessonId",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_LessonId_Order",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_LessonId",
                table: "QuizQuestions",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_LessonContents_LessonContentId",
                table: "QuizQuestions",
                column: "LessonContentId",
                principalTable: "LessonContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Lessons_LessonId",
                table: "QuizQuestions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_LessonContents_LessonContentId",
                table: "QuizQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizQuestions_Lessons_LessonId",
                table: "QuizQuestions");

            migrationBuilder.DropIndex(
                name: "IX_QuizQuestions_LessonId",
                table: "QuizQuestions");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LessonId",
                table: "QuizQuestions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizQuestions_LessonId_Order",
                table: "QuizQuestions",
                columns: new[] { "LessonId", "Order" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_LessonContents_LessonContentId",
                table: "QuizQuestions",
                column: "LessonContentId",
                principalTable: "LessonContents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizQuestions_Lessons_LessonId",
                table: "QuizQuestions",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
