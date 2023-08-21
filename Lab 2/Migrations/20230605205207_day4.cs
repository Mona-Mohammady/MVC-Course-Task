using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2.Migrations
{
    /// <inheritdoc />
    public partial class day4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Department_dept_id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Courses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ins_id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Department_dept_id",
                table: "Courses",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Department_dept_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ins_id",
                table: "Courses");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Department_dept_id",
                table: "Courses",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
