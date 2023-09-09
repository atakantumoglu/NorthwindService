﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryService.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToPersonelEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personels");
        }
    }
}