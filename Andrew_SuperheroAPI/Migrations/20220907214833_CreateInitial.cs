﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Andrew_SuperheroAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    HoursWorked = table.Column<decimal>(type: "decimal(18,0)", nullable: false),  
                    HourlyRate = table.Column<decimal>(type: "decimal(18,0)", nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "characters");
        }
    }
}
