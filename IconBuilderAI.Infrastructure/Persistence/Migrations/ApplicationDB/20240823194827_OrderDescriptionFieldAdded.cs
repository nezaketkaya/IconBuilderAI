using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IconBuilderAI.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class OrderDescriptionFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b28e33ee-a729-4d3d-a7b4-4f33ba03418e", "AQAAAAIAAYagAAAAEMU1WZFr76NF4kWE09ZvUBX16Krpoc7J2FcS/U1D0OJ44G82QH2rA7BNtXuwqHTSsQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cbe48d20-61fc-4006-aa55-0a9ea2be3c68", "AQAAAAIAAYagAAAAECBvTUPhmkbJTb/9WRihPG2PTnFGgJR6f8I60ah5iZItXPM9z/K4hUE25sRg+XvczQ==" });
        }
    }
}
