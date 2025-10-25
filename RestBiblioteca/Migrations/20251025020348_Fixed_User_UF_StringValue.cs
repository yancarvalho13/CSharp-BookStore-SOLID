using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_User_UF_StringValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "uf",
                table: "users",
                type: "character varying(2)",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "uf",
                table: "users",
                type: "integer",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(2)",
                oldMaxLength: 2);
        }
    }
}
