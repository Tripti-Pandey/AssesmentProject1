using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculationApplication.Migrations
{
    public partial class Initialtablescreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "municipal",
                columns: table => new
                {
                    MunicipalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Municipality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipal", x => x.MunicipalId);
                });

            migrationBuilder.CreateTable(
                name: "rule",
                columns: table => new
                {
                    RuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rule", x => x.RuleId);
                });

            migrationBuilder.CreateTable(
                name: "municipalRules",
                columns: table => new
                {
                    MunicipalRulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipalRules", x => x.MunicipalRulesId);
                    table.ForeignKey(
                        name: "FK_municipalRules_municipal_MunicipalId",
                        column: x => x.MunicipalId,
                        principalTable: "municipal",
                        principalColumn: "MunicipalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_municipalRules_rule_RuleId",
                        column: x => x.RuleId,
                        principalTable: "rule",
                        principalColumn: "RuleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taxSchedule",
                columns: table => new
                {
                    TaxScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalRulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxPeriodName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecificDates = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_taxSchedule", x => x.TaxScheduleId);
                    table.ForeignKey(
                        name: "FK_taxSchedule_municipalRules_MunicipalRulesId",
                        column: x => x.MunicipalRulesId,
                        principalTable: "municipalRules",
                        principalColumn: "MunicipalRulesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_municipalRules_MunicipalId",
                table: "municipalRules",
                column: "MunicipalId");

            migrationBuilder.CreateIndex(
                name: "IX_municipalRules_RuleId",
                table: "municipalRules",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_taxSchedule_MunicipalRulesId",
                table: "taxSchedule",
                column: "MunicipalRulesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "taxSchedule");

            migrationBuilder.DropTable(
                name: "municipalRules");

            migrationBuilder.DropTable(
                name: "municipal");

            migrationBuilder.DropTable(
                name: "rule");
        }
    }
}
