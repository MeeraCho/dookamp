using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DooKamp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTopicRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonLocationGrades");

            migrationBuilder.DropTable(
                name: "LessonTopics");

            migrationBuilder.CreateTable(
                name: "TopicLessons",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicLessons", x => new { x.LessonId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_TopicLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicLessons_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicLocationGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TopicId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicLocationGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicLocationGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopicLocationGrades_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TopicLocationGrades_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TopicLessons_TopicId",
                table: "TopicLessons",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicLocationGrades_GradeId",
                table: "TopicLocationGrades",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicLocationGrades_LocationId",
                table: "TopicLocationGrades",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicLocationGrades_TopicId_LocationId_GradeId",
                table: "TopicLocationGrades",
                columns: new[] { "TopicId", "LocationId", "GradeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TopicLessons");

            migrationBuilder.DropTable(
                name: "TopicLocationGrades");

            migrationBuilder.CreateTable(
                name: "LessonLocationGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GradeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonLocationGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonLocationGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LessonTopics",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    TopicId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonTopics", x => new { x.LessonId, x.TopicId });
                    table.ForeignKey(
                        name: "FK_LessonTopics_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonTopics_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_LessonTopics_TopicId",
                table: "LessonTopics",
                column: "TopicId");
        }
    }
}
