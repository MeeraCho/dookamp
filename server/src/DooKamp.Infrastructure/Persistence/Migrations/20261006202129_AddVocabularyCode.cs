using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DooKamp.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVocabularyCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Vocabularies",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Vocabularies_Code",
                table: "Vocabularies",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vocabularies_Code",
                table: "Vocabularies");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Vocabularies");
        }
    }
}
