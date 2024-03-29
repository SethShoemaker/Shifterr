﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "char(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShiftPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(275)", maxLength: 275, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftPositions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nickname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailIsConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordSalt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationRole = table.Column<string>(type: "ENUM('Crew','Manager','Administrator')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    ShiftPositionId = table.Column<int>(type: "int", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shifts_ShiftPositions_ShiftPositionId",
                        column: x => x.ShiftPositionId,
                        principalTable: "ShiftPositions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shifts_Users_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserConfirmationKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConfirmationKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConfirmationKeys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTokens_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Demo Organization" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "EmailIsConfirmed", "Nickname", "OrganizationId", "OrganizationRole", "PasswordHash", "PasswordSalt", "UserName" },
                values: new object[,]
                {
                    { 1, "JohnAdmin@demo.com", true, "John Admin", 1, "Administrator", "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==", "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=", "DemoAdmin" },
                    { 2, "AmyManager@demo.com", true, "Amy Manager", 1, "Manager", "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==", "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=", "DemoManager1" },
                    { 3, "AdamManager@demo.com", true, "Adam Manager", 1, "Manager", "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==", "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=", "DemoManager2" },
                    { 4, "GeorgeCrew@demo.com", true, "George Crew", 1, "Crew", "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==", "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=", "DemoCrew1" },
                    { 5, "JamieCrew@demo.com", true, "Jamie Crew", 1, "Crew", "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==", "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=", "DemoCrew2" },
                    { 6, "RebeccaCrew@demo.com", true, "Rebecca Crew", 1, "Crew", "xz0rpXQA20GApgQN1mbzGB2k0cPZon6pqj27QlMT9FusR0qivML/6ZpeP+8vPiZ++2ojmdN0PWUZKdFNEsizXA==", "Y1kTl8HvHA4dRuD95FEXNLWhqkUwREWmSwefPg+cVLCRVfJ2ZxFWyDq9SCNm1EdpIDkrTlFQsbJCcd7t7G8wk6JHDcG9u7Db6+/xAOngNSGfzZnb7y5QpFCQ79WnEBl888hjQsvDBFFeLkORNThF6I3allb0ilSEPzgkNo2pr1s=", "DemoCrew3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShiftPositions_OrganizationId",
                table: "ShiftPositions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_OrganizationId",
                table: "Shifts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ShiftPositionId",
                table: "Shifts",
                column: "ShiftPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_WorkerId",
                table: "Shifts",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserConfirmationKeys_UserId",
                table: "UserConfirmationKeys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_OrganizationId",
                table: "UserTokens",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "UserConfirmationKeys");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "ShiftPositions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
