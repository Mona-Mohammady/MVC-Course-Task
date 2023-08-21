using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab_2.Migrations
{
    /// <inheritdoc />
    public partial class dayf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Courses_crs_id",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_dept_id",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Department_dept_id",
                table: "Trainee");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Trainee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "Trainee",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "crs_id",
                table: "Instructor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "crs_id",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ins_id",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "trainee_id",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Department_crs_id",
                table: "Department",
                column: "crs_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Courses_crs_id",
                table: "Department",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Courses_crs_id",
                table: "Instructor",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_dept_id",
                table: "Instructor",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Department_dept_id",
                table: "Trainee",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Courses_crs_id",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Courses_crs_id",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Department_dept_id",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Department_dept_id",
                table: "Trainee");

            migrationBuilder.DropIndex(
                name: "IX_Department_crs_id",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "Trainee");

            migrationBuilder.DropColumn(
                name: "crs_id",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "ins_id",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "trainee_id",
                table: "Department");

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Trainee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "dept_id",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "crs_id",
                table: "Instructor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Courses_crs_id",
                table: "Instructor",
                column: "crs_id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Department_dept_id",
                table: "Instructor",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Department_dept_id",
                table: "Trainee",
                column: "dept_id",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
