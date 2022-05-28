using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportApp.Migrations
{
    public partial class InitModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    County = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Tall = table.Column<int>(type: "int", nullable: false),
                    MaxHeartRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trainings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PauseBetweenReps = table.Column<int>(type: "int", nullable: false),
                    BreakTimeBetweenEx = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfExercises = table.Column<int>(type: "int", nullable: false),
                    NumberOfRepeat = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_exercises_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    ParametersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_parameters_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "parameters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_users_trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "trainings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_exercises_TrainingId",
                table: "exercises",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_users_ParametersId",
                table: "users",
                column: "ParametersId");

            migrationBuilder.CreateIndex(
                name: "IX_users_TrainingId",
                table: "users",
                column: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "exercises");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "parameters");

            migrationBuilder.DropTable(
                name: "trainings");
        }
    }
}
