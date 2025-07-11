﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity_framework.Migrations
{
    /// <inheritdoc />
    public partial class EnitiyFreameworkAddClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Standard",
                table: "Students_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Standard",
                table: "Students_Details");
        }
    }
}
